import React, { Component } from 'react';
import { Button, Grid, Row, Col } from 'react-bootstrap'
import ReactDataGrid from 'react-data-grid'
import { getEmployees, deleteEmployee, createSkill, getSkillsByEmployeeId } from '../api/calls'

class SkillsGrid extends Component {

    constructor(props) {
        super(props);
             
    }

    _columns = [
        { key: 'Name', name: 'Skill Name', resizable: true },
        { key: 'Category', name: 'Skill Category', resizable: true },
        { key: 'actions', name: '', resizable: true },
    ];

    _handleEditClick(employeeId) {
        this.props.onEditClick(employeeId);
    }

    _handleSkillClick(employeeId) {
        this.props.onCreateSkillClick(employeeId);
    }

    _deleteEmployee = async (employeeId) => {
        await deleteEmployee(employeeId);
        await this.refreshGrid();
    }

    _actions = (employeeId) => <Row>
        <Col sm={3}>
            <Button bsStyle="primary" onClick={async () => await this._handleEditClick(employeeId)}>Edit</Button>
        </Col>
        <Col sm={3}>
            <Button bsStyle="danger" onClick={async () => await this._deleteEmployee(employeeId)}>Delete</Button>
        </Col>
    </Row>


    render() {
        return (
            <div>
                <ReactDataGrid
                    columns={this._columns}
                    rowGetter={(i) => this.props.rows[i]}
                    rowsCount={this.props.rows.length}
                    minHeight={500}
                />
            </div>
        )
    }
}

export { SkillsGrid };