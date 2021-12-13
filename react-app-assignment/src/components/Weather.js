import React, { Component } from "react"

class Weather extends Component {
    constructor(props) {
        super(props)
        this.state = {
            TempCurrent: ''
        }
        this.fetchData = this.fetchData.bind(this);
    }

    fetchData() {
        fetch("https://api.openweathermap.org/data/2.5/weather?q=halifax&appid=a54a879de726c9905dcb80f4b4440192")
            .then(response => {
                return response.json()
            })
            .then(response => {
                console.log(response);
                this.setState({
                    TempCurrent: Math.round(response.main.temp -273.15,2)
                    
                })
            });
    }

    componentDidMount() {
        this.fetchData()
    }

    render() {
        
        return (
            
            <div className="temp-container">
                 <h1><img src="/Halifax.jfif" alt="Halifax" /></h1>
                <h2>I live in Halifax</h2>
                Halifax is a city situated on the East Coast of 
                <h3></h3>
                Canada in the Maritime province of Nova Scotia
        
                <h4></h4>
                Current weather is as below

               <h5></h5>

               
                <p><b>Current Tempature: </b>{this.state.TempCurrent}&deg;C</p>
            


              {
                  this.state.TempCurrent <10 && <h1><img src="/cold.png" alt="cold" /></h1>
              }     
              {
                  this.state.TempCurrent >10 && <h1><img src="/mild.png" alt="mild" /></h1>
              }      
              {
                  this.state.TempCurrent >20 && <h1><img src="/sunny.png" alt="sunny" /></h1>
              }
             
            
                
            </div>
        )
    }
}

export default Weather;