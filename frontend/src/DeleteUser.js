import React, {Component} from "react";

export function DeleteUser() {
  return (
    <div>
      <br/>

      <p className="warning-message"><b>DELETE USER</b></p>

      <GetIDForm />


    </div>
  )
}

function DeleteUserMethod(id) {
  const method = "DELETE";
  const url = "http://localhost:5000/users/"+id;
  let request = new XMLHttpRequest();
  request.open(method, url, true);
  request.setRequestHeader('Content-type', 'application/json');
  request.onload = function(){
    console.log(request.responseText);
    let data = JSON.parse(this.response);
    console.log("DATA: ",data);

  };
  request.send();
}


class GetIDForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      userID: '',
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({ [event.target.name]: event.target.value});
    /*this.setState({value1: event.target.value1});*/ // KEEP ME FOR REFERENCE
  }

  handleSubmit(event) {
    console.log("username: " + this.state.userID);

    // TODO password stuff when added to API
    let valid = true;
    if (this.state.userID.length === 0) {
      window.alert("Please fill in all fields");
      valid = false;
    }

    event.preventDefault();
    if (valid) {
      DeleteUserMethod(this.state.userID)
    }

  }

  render() {
    return (
      <div>
        <p className="warning-message"><b>WARNING: THIS CANNOT BE UNDONE - BE SURE YOU MEAN TO DELETE A USER PERMANENTLY</b></p>
        <form onSubmit={this.handleSubmit}>
          <input type="number" name="userID" className="Input-box" placeholder="ID" value={this.state.username} onChange={this.handleChange}/> <br/><br/>
          {/*<input type="password" name="password" className="Input-box" placeholder="Password" value={this.state.password} onChange={this.handleChange}/> <br/> <br/>*/}
          <button type="submit" value="Submit" className="Login-button-red">DELETE</button>
        </form>
      </div>
    );
  }

}