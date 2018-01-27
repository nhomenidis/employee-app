import React, { Component } from 'react';
import { Button, Grid, Row, Col } from 'react-bootstrap'
import ReactDataGrid from 'react-data-grid'
import { getEmployees, deleteEmployee, createSkill } from '../api/calls'
import {SkillModal} from './SkillModal'
import {SkillsGrid} from './skillsGrid'

class EmployeeGrid extends Component {

    constructor(props) {
        super(props);
        this.state = {
            skillRows: [],
        };       
    }
 
    _columns = [ // id column hidden
        { key: 'firstName', name: 'First Name', resizable: true },
        { key: 'lastName', name: 'Last Name', resizable: true },
        { key: 'dateOfBirth', name: 'Birthdate', resizable: true },
        { key: 'address', name: 'Address', resizable: true },
        { key: 'email', name: 'Email', resizable: true },
        { key: 'skills', name: 'Skills', resizable: true},
        { key: 'actions', name: '', resizable: true },
    ];

    _onRowSelect = (event) => {
        alert(event);
        // event => row employee ID
        // api call getskillsbyEmployeeId
        // this.setState {skillRows: result}
    }

    onRowsSelected = (rows) => {
        this.setState({selectedIndexes: this.state.selectedIndexes.concat(rows.map(r => r.rowIdx))});
      };
    
    onRowsDeselected = (rows) => {
        let rowIndexes = rows.map(r => r.rowIdx);
        this.setState({selectedIndexes: this.state.selectedIndexes.filter(i => rowIndexes.indexOf(i) === -1 )});
      };

    render() {
        return (
            <div>
            <ReactDataGrid
                columns={this._columns}
                rowGetter={(i) => this.props.rows[i]}
                rowsCount={this.props.rows.length}
                minHeight={500}
                rowSelection={
                    {
                    showCheckbox: true,
                    onRowsSelected: this._onRowsSelected,
                    onRowsDeselected: this.onRowsDeselected,
                    selectBy: {
                      indexes: this.state.selectedIndexes
                    }}
                    }
                    //this._onRowSelect,

            />
            <SkillsGrid
                rows={this.state.skillRows}
            />
            </div>
        )
    }
}

export { EmployeeGrid };