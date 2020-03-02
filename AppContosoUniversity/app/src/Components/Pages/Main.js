import React, { Component } from 'react'
import { Route, BrowserRouter as Router } from 'react-router-dom'
import Student from './Student'
import About from './About'
import Course from './Course'

const navegation = (
    <Router>
        <Route path="/Students" component={Student} />
        <Route path="/About" component={About}/>
        <Route path="/Course" component={Course}/>
    </Router>
)

export default class Main extends Component {
    render() {
        return (
            <div className="container">
            <div className="main-container">
                <main role="main" className="pb-3">
                    {
                        navegation
                    }                       
                </main>
            </div>
            </div>
        )
    }
}
