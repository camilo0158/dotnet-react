import React, { Component } from 'react'
import Api from 'axios'

class About extends Component {
    render() {
        return (
            <div>
                <h2>Student Body Statistics</h2>

                <table>
                    <tbody>
                        <tr>
                            <th>Enrollment Date</th>
                            <th>Students</th>
                        </tr>
                    </tbody>
                </table>
                
            </div>
        )
    }

componentDidMount(){
    this.getAbout();
}

async getAbout(){
    try{
        var response = await Api.get("https://localhost:5001/Api/About");
        console.log(response);
    }catch(error){
        console.log(error);
    }
}
}

export default About;
