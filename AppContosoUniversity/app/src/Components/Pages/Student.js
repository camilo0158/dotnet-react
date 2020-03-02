import React, { Component } from 'react'
import Api from 'axios';



class Student extends Component {
    constructor(props) {
        super(props);
        this.state = {
            pageNumber: 0
        }
        this.nextPage = this.nextPage.bind(this);
    }
    render() {
        return (
            <div>
                Students
                    <div className="alert alert-primary">
                        <button onClick={this.nextPage}>Incrementar</button>
                        <label>Contador: {this.state.pageNumber}</label>
                    </div>
                </div>
            
        )
    }

    componentDidMount() {
        this.getStudents();
        this.setState({ pageNumber: 1 });
    }

    async getStudents() {
        try {
            var response = await Api.get("https://localhost:5001/Api/Students");

            console.log(response);
        } catch (error) {
            console.log(error);
        }
    }

    nextPage() {
        this.setState({ pageNumber: this.state.pageNumber + 1 });
    }
}

export default Student;
