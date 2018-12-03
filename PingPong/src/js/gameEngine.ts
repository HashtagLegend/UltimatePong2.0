import { GameObject } from "./gameObject";
import { Vector } from "./vector";
import { Player } from "./player";
import { Ball } from "./ball";
import { Ai } from "./ai";
import axios, { AxiosResponse, AxiosError } from "../../node_modules/axios/index";

export class GameEngine
{
    public ball: Ball;
    public player1:Player
    public ai: Ai
    public gameStatus: string = "started";

    public playerScore : number = 0;
    public aiScore: number = 0;

    /*public keyPressUp: boolean;*/
    /*public keyPressDown: boolean;*/

    public cwidth: number;
    public cheight: number;

    public direction: string;

    public objects: GameObject[] = new Array<GameObject>();

    private canvas:HTMLCanvasElement;
    private ctx:CanvasRenderingContext2D;

    private scoreTag: HTMLParagraphElement;
    private aiScoreTag: HTMLParagraphElement;
    public static currentLVL: HTMLParagraphElement;

    public speed: HTMLParagraphElement;

    private buttenEasy :HTMLButtonElement;
    private buttenMedium :HTMLButtonElement;
    private buttenHard :HTMLButtonElement;


    constructor(){
        this.canvas = <HTMLCanvasElement> document.getElementById("gameCanvas");
        this.ctx = this.canvas.getContext("2d");
        this.scoreTag = document.getElementById("pScore") as HTMLParagraphElement;
        this.aiScoreTag = document.getElementById("aScore") as HTMLParagraphElement;
        this.speed = document.getElementById("moveSpeed") as HTMLParagraphElement;
        GameEngine.currentLVL = document.getElementById("current") as HTMLParagraphElement;


        this.buttenEasy = document.getElementById("easy") as HTMLButtonElement;
        this.buttenEasy.addEventListener("click", this.EasyPush);
        this.buttenMedium = document.getElementById("medium") as HTMLButtonElement;
        this.buttenMedium.addEventListener("click", this.MediumPush);
        this.buttenHard = document.getElementById("hard") as HTMLButtonElement;
        this.buttenHard.addEventListener("click", this.HardPush);

        this.cwidth = this.canvas.width;
        this.cheight = this.canvas.height;

        /*document.addEventListener('keyup', this.KeyUp.bind(this));*/
       /* document.addEventListener('keydown', this.KeyDown.bind(this));*/

        this.player1 = new Player(new Vector(25,150),this);
        this.objects.push(this.player1);

        this.ai = new Ai(new Vector(785,150),this);
        this.objects.push(this.ai);
        Ai.aiLvl = "easy";
        GameEngine.currentLVL.innerHTML = "Current lvl: Easy";
       
     

        this.ball = new Ball(new Vector(250,100), this);
        this.objects.push(this.ball);

        this.gameLoop();
    }

    private Collision(a: GameObject, b:GameObject): boolean{
        if (a.position.x < (b.position.x+b.width) &&
        (a.position.x+a.width) > b.position.x &&
        a.position.y < (b.position.y+a.height) &&
        a.position.y+b.height > b.position.y)
        {
            return true;
        }

    }

    private UpdateScore():void{
        this.scoreTag.innerHTML = this.playerScore.toString();
        this.aiScoreTag.innerHTML = this.aiScore.toString();
    }

    /*private KeyDown(event: KeyboardEvent):void{
        if(event.repeat) {return};
        if(event.key == "a"){
            console.log("a");
            this.keyPressUp = true;
        }else if(event.key == "z"){
            this.keyPressDown = true;
            console.log("z");
        }
        
    }*/

    
    /*private KeyUp(event: KeyboardEvent):void{
        if(event.repeat) {return};
        if(event.key == "a"){
            this.keyPressUp = false;
        }else if(event.key == "z"){
            this.keyPressDown = false;
        }
        
    }*/

    public gameLoop(): void{

        console.log(this.direction)

        this.ctx.clearRect(0,0,this.canvas.width,this.canvas.height);
        this.getDirections();
        this.speed.innerHTML = "Current speed: "+this.player1.speedShow.toString(); 

        this.objects.forEach(element => {
            this.objects.forEach(obj => {
                if(element !== obj)
                {
                    if(this.Collision(element,obj)){
                        element.onCollision(obj);
                    }
                }
            });

            element.moveObject(50);
            element.drawObject(this.ctx)
            this.UpdateScore();
        });
        window.requestAnimationFrame(this.gameLoop.bind(this));
    }

    public getDirections(){
    
        const uri: string = "https://ultimatepongcontrols.azurewebsites.net/api/direction/";

        axios.get(uri)
            .then((response) => {
                    
                if (response.data == "up") {
                    if (this.gameStatus = "started") {
                        this.direction = "up";

                    }
                    
                }
    
                else if (response.data == "down") {
                    if (this.gameStatus = "started") {
                        this.direction = "down";

                    }
                }
                else if (response.data == "not moving") {
                    if (this.gameStatus = "started") {
                        this.direction = "not moving";

                    }
                }
    
        });
    
    }

    public EasyPush(): void{
        Ai.aiLvl = "easy";
        GameEngine.currentLVL.innerHTML = "Current lvl: Easy";

    }

    public MediumPush(): void{
        Ai.aiLvl = "medium";
        GameEngine.currentLVL.innerHTML = "Current lvl: Medium";
    }

    public HardPush(): void{
        Ai.aiLvl = "hard";
        GameEngine.currentLVL.innerHTML = "Current lvl: Hard";
    }
}    
