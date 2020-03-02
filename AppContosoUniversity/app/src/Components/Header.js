import React, { Component } from 'react'

class Header extends Component {
    constructor(props) {
        super(props);
        this.state = {
            
        }
    }
    render() {
        return (
            <div>
                <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
                    <div className="container">
                        <a className="navbar-brand" href="/">{this.props.name}</a>                        
                        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                            aria-expanded="false" aria-label="Toggle navigation">
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <a href="/">{this.props.date()}</a> 
                        <div className="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                            <ul className="navbar-nav flex-grow-1">
                                <li className="nav-item">
                                    <a className="nav-link text-dark" href="/About">About</a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link text-dark" href="/Students">Students</a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link text-dark" href="/Course">Courses</a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link text-dark" href="">Instructors</a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link text-dark" href="">Departments</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
        )
    }
}

export default Header;
