import React, { Component } from 'react';
import './employeeDashboard.css'
import { Grid, Row, Col, Button, Jumbotron, Modal, Form, FormControl, ControlLabel } from 'react-bootstrap';
import { EmployeeGrid } from './employeeGrid'
import { createEmployee, createSkill, deleteAll } from '../api/calls'

class EmployeeDashboard extends Component {

    constructor(props) {
        super(props);
        this.state = {
            showModal: false,
            firstName: '',
            lastName: '',
            email: '',
            address: '',
            birthDate: new Date(),

            showSkillModal: false,
            Name: '',
            Category: '',
            employeeId: '',

            showAddSkillModal: false
        };

        this.handleCreateSkillClick = this.handleCreateSkillClick.bind(this);
    }

    handleCreateSkillClick = (employeeId) => {
        
        this.setState({ showAddSkillModal: true })
        this.setState({employeeId: employeeId})
        };

    _createEmployee = async () => {
        const request = {
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            email: this.state.email,
            address: this.state.address,
            birthDate: this.state.birthDate,

        };

        const response = await createEmployee(request);

        const skillRequest = {

            Name: this.state.Name,
            Category: this.state.Category,
            employeeId: response.employeeId
        };
        await createSkill(skillRequest)
        .then(alert('Employee with skills was successfully created!!'));
        this.setState({ showModal: false });
        //     .then(
        //         this.setState({ employeeId: response.employeeId}
        //     ))
        //     .then(await createSkill(skillRequest))
        //     .then(alert('Employee with skills was successfully created!!'));
        // this.setState({ showModal: false });


        // this.setState({ employeeId: body.employeeId });
        // await createSkill(skillRequest);
        // alert('Employee with skills was successfully created!!');
        // this.setState({ showModal: false });
    }

    _deleteAllEmployees = async () => {
        await deleteAll();
        await this.refreshGrid;
    }

    _createSkill = async () => {
        const skillRequest = {
            Name: this.state.Name,
            Category: this.state.Category,
            employeeId: this.state.employeeId
        };

        await createSkill(skillRequest);
        this.setState({ showSkillModal: false, showModal: true });
    }

    _addSkilltoEmployee = async (employeeId) => {
        const skillRequest = {
            Name: this.state.Name,
            Category: this.state.Category,
            employeeId: this.state.employeeId
        };

        await createSkill(skillRequest);
        this.setState({ showAddSkillModal: false});
    }

    _saveSkill = async () => {
        const skillRequest = {
            Name: this.state.Name,
            Category: this.state.Category,
            employeeId: this.state.employeeId
        }
        this.setState({ showSkillModal: false, showModal: true})
    }

    _Employeemodal = () => <Modal.Dialog>
        <Modal.Header>
            <Modal.Title>Create New Employee</Modal.Title>
        </Modal.Header>

        <Modal.Body>
            <Form>
                <ul>
                    <li><ControlLabel>First Name</ControlLabel>
                        <FormControl
                            type="text"
                            value={this.state.firstName}
                            placeholder="Enter first name"
                            onChange={(e) => this.setState({ firstName: e.target.value })}
                        /></li>
                    <li><ControlLabel>Last Name</ControlLabel>
                        <FormControl
                            type="text"
                            value={this.state.lastName}
                            placeholder="Enter last name"
                            onChange={(e) => this.setState({ lastName: e.target.value })}
                        /></li>
                    <li><ControlLabel>Email</ControlLabel>
                        <FormControl
                            type="email"
                            value={this.state.email}
                            placeholder="Enter valid email"
                            onChange={(e) => this.setState({ email: e.target.value })}
                        /></li>
                    <li><ControlLabel>Address</ControlLabel>
                        <FormControl
                            type="text"
                            value={this.state.address}
                            placeholder="Enter address"
                            onChange={(e) => this.setState({ address: e.target.value })}
                        /></li>
                    <li><ControlLabel>Birth Date</ControlLabel>
                        <FormControl
                            type="date"
                            value={this.state.birthDate}
                            placeholder="Enter birth date"
                            onChange={(e) => this.setState({ birthDate: e.target.value })}
                        /></li>
                </ul>
            </Form>
            <Button bsStyle="warning" onClick={() => this.setState({ showSkillModal: true })}>Add Skill</Button>


        </Modal.Body>

        <Modal.Footer>
            <Button onClick={async () => await this._createEmployee()}>Submit</Button>
            <Button onClick={() => this.setState({ showModal: false })}>Cancel</Button>
        </Modal.Footer>

    </Modal.Dialog>

    _Skillmodal = () => <Modal.Dialog>
        <Modal.Header>
            <Modal.Title>Create New Skill</Modal.Title>
        </Modal.Header>

        <Modal.Body>
            <Form>
                <ul>
                    <li><ControlLabel>Name</ControlLabel>
                        <FormControl
                            type="text"
                            value={this.state.Name}
                            placeholder="Enter skill name"
                            onChange={(e) => this.setState({ Name: e.target.value })}
                        /></li>
                    <li><ControlLabel>Category</ControlLabel>
                        <FormControl
                            type="text"
                            value={this.state.Category}
                            placeholder="Enter skill type"
                            onChange={(e) => this.setState({ Category: e.target.value })}
                        /></li>
                    {/* <li><ControlLabel>Employee Id</ControlLabel>
                        <FormControl
                            type="text"
                            value={this.state.employeeId}
                            placeholder="Enter Id"
                            onChange={(e) => this.setState({ employeeId: e.target.value })}
                        /></li> */}
                </ul>
            </Form>

        </Modal.Body>

        <Modal.Footer>
            {/* <Button onClick={async () => await this._createSkill()}>Submit</Button> */}
            <Button onClick={async () => await this._saveSkill()}>Submit</Button>
            <Button onClick={() => this.setState({ showSkillModal: false})}>Cancel</Button>
        </Modal.Footer>

    </Modal.Dialog>

_AddSkillmodal = () => <Modal.Dialog>
<Modal.Header>
    <Modal.Title>Add Skill to Employee</Modal.Title>
</Modal.Header>

<Modal.Body>
    <Form>
        <ul>
            <li><ControlLabel>Name</ControlLabel>
                <FormControl
                    type="text"
                    value={this.state.Name}
                    placeholder="Enter skill name"
                    onChange={(e) => this.setState({ Name: e.target.value })}
                /></li>
            <li><ControlLabel>Category</ControlLabel>
                <FormControl
                    type="text"
                    value={this.state.Category}
                    placeholder="Enter skill type"
                    onChange={(e) => this.setState({ Category: e.target.value })}
                /></li>
            {/* <li><ControlLabel>Employee Id</ControlLabel>
                <FormControl
                    type="text"
                    value={this.state.employeeId}
                    placeholder="Enter Id"
                    onChange={(e) => this.setState({ employeeId: e.target.value })}
                /></li> */}
        </ul>
    </Form>

</Modal.Body>

<Modal.Footer>
    {/* <Button onClick={async () => await this._createSkill()}>Submit</Button> */}
    <Button onClick={async () => await this._addSkilltoEmployee()}>Submit</Button>
    <Button onClick={() => this.setState({ showAddSkillModal: false})}>Cancel</Button>
</Modal.Footer>

</Modal.Dialog>

    render() {
        return (
            <div>
                {this.state.showModal === true ? this._Employeemodal() : null}
                {this.state.showSkillModal === true ? this._Skillmodal() : null}
                {this.state.showAddSkillModal === true ? this._AddSkillmodal() : null}
                <Grid>
                    <Row className='show-grid'>
                        <Col md={12}>
                            <Jumbotron>
                                <h1>Hello, User!</h1>
                                <p>
                                    You can manage Employees and add skills to each one!
                                    Give it a try.
                                </p>
                                <p>
                                    <Button bsStyle="primary" onClick={() => this.setState({ showModal: true })}>Create Employee</Button>
                                </p>
                            </Jumbotron>
                        </Col>
                    </Row>
                    <Row className='show-grid'>
                        <Col md={12}>
                            <EmployeeGrid 
                            onCreateSkillClick={this.handleCreateSkillClick}
                            />
                        </Col>
                    </Row>
                    <Row className='other-functions'>
                        <Col md={10}>
                            <Button bsStyle="primary" onClick={async () => await this._deleteAllEmployees()}>Delete All Employees</Button>
                            <Button bsStyle="primary" >Find skills by Employee</Button>
                            <Button bsStyle="primary" >Show all skills</Button>
                        </Col>
                    </Row>
                </Grid>
            </div>
        )
    }
}

export { EmployeeDashboard };
