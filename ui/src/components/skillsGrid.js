import React, { Component } from 'react';
import { Button, Grid, Row, Col } from 'react-bootstrap'
import ReactDataGrid from 'react-data-grid'
import { getEmployees, deleteEmployee, createSkill, getSkillsByEmployeeId } from '../api/calls'

class SkillsGrid extends Component {

    constructor(props) {
        super(props);
             
    }

    _columns = [
        { key: 'name', name: 'Skill Name', resizable: true },
        { key: 'category', name: 'Skill Category', resizable: true },
        { key: 'Skillactions', name: '', resizable: true },
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



    render() {
        return (
            <div>
                <ReactDataGrid
                    columns={this._columns}
                    rowGetter={(i) => this.props.rows[i]}
                    rowsCount={this.props.rows.length}
                    minHeight={200}
                />
            </div>
        )
    }
}

export { SkillsGrid };