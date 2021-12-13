import React, { Component } from "react"
import Aboutme from './components/Aboutme'
import Weather from './components/Weather'




import './App.css';


class App extends Component {
  constructor(props) {
    super(props)
    this.state = {
      selectedMenu: 'p'
    }
  }

  render() {
    return (
      <div className="App">
        

        <div className="menu">
          <h1 className="menu-item" onClick={() => this.setState({ selectedMenu: 'p' })}>About Me</h1>
          <h2 className="menu-item" onClick={() => this.setState({ selectedMenu: 't' })}>My City</h2>
          
        </div>

   
        {this.state.selectedMenu === 'p' ?
          <Aboutme />
          :
          this.state.selectedMenu === 't' ?
            <Weather />
            :
            <h1></h1>
        }
      </div>
    );
  }
}


export default App;
