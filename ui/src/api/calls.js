function getEmployees() {
    return fetch(`http://localhost:49513/employee`, {
        method: 'get',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
        .then(checkStatus);
}

function getAllSkills() {
    return fetch(`http://localhost:49513/skill`, {
        method: 'get',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
        .then(checkStatus);
}

function getEmployeeById(employeeId) {
    return fetch(`http://localhost:49513/employee/${employeeId}`, {
        method: 'get',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
        .then(checkStatus);
}

function getSkillById(skillId) {
    return fetch(`http://localhost:49513/skill/${skillId}`, {
        method: 'get',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
        .then(checkStatus);
}

function deleteEmployee(employeeId) {
    return fetch(`http://localhost:49513/employee/${employeeId}`, {
        method: 'delete',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
        .then(checkStatus);
}

function deleteSkill(skillId) {
    return fetch(`http://localhost:49513/skill/${skillId}`, {
        method: 'delete',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
        .then(checkStatus);
}


function deleteAll() {
    return fetch(`http://localhost:49513/employee`, {
        method: 'delete',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
        .then(checkStatus);
}

function createEmployee(request) {
    return fetch(`http://localhost:49513/employee`, {
        method: 'post',
        body: JSON.stringify(request),
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
        .then(checkStatus);
}

function updateEmployee(employeeId, request) {
    return fetch(`http://localhost:49513/employee/${employeeId}`, {
        method: 'put',
        body: JSON.stringify(request),
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
        .then(checkStatus);
}

function updateSkill(SkillId, request) {
    return fetch(`http://localhost:49513/skill/${SkillId}`, {
        method: 'put',
        body: JSON.stringify(request),
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
        .then(checkStatus);
}

function createSkill(request) {
    return fetch(`http://localhost:49513/skill/create`, {
        method: 'post',
        body: JSON.stringify(request),
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
        .then(checkStatus);
}

function getSkillsByEmployeeId(employeeId) {
    return fetch(`http://localhost:49513/employee/${employeeId}/skills`, {
        method: 'get',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    })
        .then(checkStatus);
}


function checkStatus(response) {
    if (response.status >= 200 && response.status < 300) {
        return response.json();
    } else {
        const error = new Error(`HTTP Error ${response.statusText}`);
        error.status = response.statusText;
        error.response = response;
        console.log(error);
        if (response.status === 400) {
            response.json()
                .then((body) => alert(JSON.stringify(body)));
        }
        //throw error;
    }
}

export {
    getEmployees, deleteEmployee, createEmployee, createSkill, deleteAll, getEmployeeById, updateEmployee,
    getSkillsByEmployeeId, deleteSkill, updateSkill, getSkillById, getAllSkills
}