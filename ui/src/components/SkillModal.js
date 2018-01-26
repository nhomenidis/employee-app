import React, { Component } from 'react';
import { Grid, Row, Col, Button, Jumbotron, Modal, Form, FormControl, ControlLabel } from 'react-bootstrap';

class SkillModal extends Component {

    constructor(props) {
        super(props);
        this.state = {
            showSkillModal: false,
            skillName: '',
            skillType: '',
            employeeId: ''
        };
    }

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
                            value={this.state.skillName}
                            placeholder="Enter skill name"
                            onChange={(e) => this.setState({ skillName: e.target.value })}
                        /></li>
                    <li><ControlLabel>Type</ControlLabel>
                        <FormControl
                            type="text"
                            value={this.state.skillType}
                            placeholder="Enter skill type"
                            onChange={(e) => this.setState({ skillType: e.target.value })}
                        /></li>
                </ul>
            </Form>

        </Modal.Body>

        <Modal.Footer>
            {/* <Button onClick={async () => await this._createSkill()}>Submit</Button> */}
            <Button onClick={async () => await this._saveSkill()}>Submit</Button>
            <Button onClick={() => this.setState({ showSkillModal: false})}>Cancel</Button>
        </Modal.Footer>

    </Modal.Dialog>

    render() {
        return (null
            // <div>
            //     {this.state.showSkillModal === true ? this._Skillmodal() : null}
            //     <SkillModal
            //     />
            // </div>
        )
    }
}

export { SkillModal };