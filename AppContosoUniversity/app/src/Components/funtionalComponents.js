import React from 'react'



export const GetApi = (props) => {
    return (
        <div className="form-card">
            <div>
                <label>{props.nameText}</label>
            </div>
            <button onClick={props.nameFunction} type="button" class="btn btn-primary">{props.nameButton}</button>
        </div>

    );
}

export const ViewApi = (props) => {
    return (
        <div className="alert alert-primary" role="alert">
            <label>{props.nameText}</label>

        </div>
    );
}

export const ViewInfoApi = (props) => {
    
    return (
               
                    <tr>                       
                        <th >{props.name}</th>
                        <th >{props.firstName}</th>
                        <th>{props.enrollmentDate}</th>
                    </tr>           
        
    );
}
