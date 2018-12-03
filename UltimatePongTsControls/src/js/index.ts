import axios, { AxiosResponse, AxiosError } from "../../node_modules/axios/index";

interface IDirection{
    action: string
}

const uri: string = "https://ultimatepongcontrols.azurewebsites.net/api/direction/";
let gameStatus: string = "started"

let outputfield: HTMLParagraphElement = document.getElementById("direction") as HTMLParagraphElement
let startButton: HTMLButtonElement = document.getElementById("start") as HTMLButtonElement
let stopButton: HTMLButtonElement = document.getElementById("stop") as HTMLButtonElement

startButton.addEventListener("click", getDirections)
stopButton.addEventListener("click", stopGame)

function getDirections(){
    
    
    axios.get(uri)
        .then((response) => {
        console.log(response.data)
        let result: string = "not moving";
                    
            console.log("function started")
            
            if (response.data == "up") {
                result = "up";
                outputfield.innerHTML = result;
                if (gameStatus = "started") {
                    getDirections()
                }
                
            }

            else if (response.data == "down") {
                result = "down";
                outputfield.innerHTML = result;
                if (gameStatus = "started") {
                    getDirections()
                }
            }
            else if (response.data == "not moving") {
                result = "stop";
                outputfield.innerHTML = result;
                if (gameStatus = "started") {
                    getDirections()
                }
            }
            else outputfield.innerHTML = result;

    });

}
    

function stopGame(){
    gameStatus = "stopped"
    console.log("game stopped")
}

var Thread = {
	sleep: function(ms: number) {
		var start = Date.now();
		
		while (true) {
			var clock = (Date.now() - start);
			if (clock >= ms) break;
		}
		
	}
};


