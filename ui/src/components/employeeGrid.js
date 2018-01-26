import React, { Component } from 'react';
import { Button, Grid, Row, Col } from 'react-bootstrap'
import ReactDataGrid from 'react-data-grid'
import { getEmployees, deleteEmployee, createSkill } from '../api/calls'
import {SkillModal} from './SkillModal'

class EmployeeGrid extends Component {

    constructor(props) {
        super(props);
        this.state = {
            rows: [],
        };
        this._handleSkillClick = this._handleSkillClick.bind(this);
        this._handleEditClick = this._handleEditClick.bind(this);        
    }

    _columns = [
        { key: 'firstName', name: 'First Name', resizable: true },
        { key: 'lastName', name: 'Last Name', resizable: true },
        { key: 'dateOfBirth', name: 'Birthdate', resizable: true },
        { key: 'address', name: 'Address', resizable: true },
        { key: 'email', name: 'Email', resizable: true },
        { key: 'skills', name: 'Skills', resizable: true},
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
        <Col sm={6}>
            <Button bsStyle="warning" onClick={async () => await this._handleSkillClick(employeeId)}>Add Skill</Button>
        </Col>
    </Row>

    refreshGrid = async () => {
        var response = await getEmployees();
        response.forEach(element => {
            element.actions = this._actions(element.employeeId);
        });
        this.setState({
            rows: response
        })
    }

    async componentDidMount() {
        await this.refreshGrid();
    }

    render() {
        return (
            <div>
            <ReactDataGrid
                columns={this._columns}
                rowGetter={(i) => this.state.rows[i]}
                rowsCount={this.state.rows.length}
                minHeight={500}
            />
            </div>
        )
    }
}

export { EmployeeGrid };