import React, { Component } from 'react';
import ReactDataGrid from 'react-data-grid'

class SkillsGrid extends Component {

    constructor(props) {
        super(props);
             
    }

    _columns = [
        { key: 'name', name: 'Skill Name', resizable: true },
        { key: 'category', name: 'Skill Category', resizable: true },
        { key: 'Skillactions', name: '', resizable: true },
    ];


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