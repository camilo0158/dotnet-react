import React, { Component } from 'react'
import {GetApi, ViewApi, ViewInfoApi} from '../funtionalComponents'
import Api from 'axios'

export default class Course extends Component {    
    constructor(props){
        super(props);
        this.state = {
            rows:[],
            message:""
        }
        this.getStudents = this.getStudents.bind(this);
    }
    render() {      
        let Lista;
        if(this.state.rows.length > 0){
            Lista = this.state.rows.map((item, i) => 
                <ViewInfoApi name={item.lastName}/>)
            ;
            
        }
        
        return (
            <div>
                <GetApi nameText="Api Student" nameButton="GET" nameFunction={this.getStudents}/>
                <ViewApi nameText={this.state.message}/>
                {
                    Lista
                }
            </div>
        )
    }   
    
    async getStudents() {
        try {
            var response = await Api.get("https://localhost:5001/Api/Students");

            console.log(response.data);            
            
            this.setState({message:"ok", rows:response.data});
        } catch (error) {
            
            console.log(error);
            this.setState({message:"error"});
        }
    }

}
