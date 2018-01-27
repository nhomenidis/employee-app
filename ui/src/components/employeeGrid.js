import React, { Component } from 'react';
import { Button, Grid, Row, Col } from 'react-bootstrap'
import ReactDataGrid from 'react-data-grid'
import { getEmployees, deleteEmployee, createSkill } from '../api/calls'
import {SkillModal} from './SkillModal'
import {SkillsGrid} from './skillsGrid'

class EmployeeGrid extends Component {

    constructor(props) {
        super(props);
    }
 
    _columns = [ // id column hidden
        { key: 'firstName', name: 'First Name', resizable: true },
        { key: 'lastName', name: 'Last Name', resizable: true },
        { key: 'dateOfBirth', name: 'Birthdate', resizable: true },
        { key: 'address', name: 'Address', resizable: true },
        { key: 'email', name: 'Email', resizable: true },
        { key: 'skills', name: 'Skills', resizable: true},
        { key: 'actions', name: '', resizable: true, width: 220 },
    ];

    _onRowSelect = (event) => {
        alert(event);
        // event => row employee ID
        // api call getskillsbyEmployeeId
        // this.setState {skillRows: result}
    }


    render() {
        return (
            <div>
            <ReactDataGrid
                columns={this._columns}
                rowGetter={(i) => this.props.rows[i]}
                rowsCount={this.props.rows.length}
                minHeight={300}
                //rowSelection= {this._onRowSelect}

            />
            <SkillsGrid
                rows={this.props.skillRows}
            />
            </div>
        )
    }
}

export { EmployeeGrid };