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
                <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
                    <div class="container">
                        <a class="navbar-brand" href="/">{this.props.name}</a>
                        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                            aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                            <ul class="navbar-nav flex-grow-1">
                                <li class="nav-item">
                                    <a class="nav-link text-dark" href="/About">About</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link text-dark" href="/Students">Students</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link text-dark" href="/Courses">Courses</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link text-dark" href="">Instructors</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link text-dark" href="">Departments</a>
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
