import React, { Component } from 'react';
import ReactDataGrid from 'react-data-grid'
import {SkillsGrid} from './skillsGrid'

class EmployeeGrid extends Component {

    constructor(props) {
        super(props);
    }
 
    _columns = [
        { key: 'firstName', name: 'First Name', resizable: true },
        { key: 'lastName', name: 'Last Name', resizable: true },
        { key: 'dateOfBirth', name: 'Birthdate', resizable: true },
        { key: 'address', name: 'Address', resizable: true },
        { key: 'email', name: 'Email', resizable: true },
        { key: 'skills', name: 'Skills', resizable: true},
        { key: 'actions', name: '', resizable: true, width: 220 },
    ];

    render() {
        return (
            <div>
            <ReactDataGrid
                columns={this._columns}
                rowGetter={(i) => this.props.rows[i]}
                rowsCount={this.props.rows.length}
                minHeight={300}
            />
            <SkillsGrid
                rows={this.props.skillRows}
            />
            </div>
        )
    }
}

export { EmployeeGrid };