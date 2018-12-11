import { Vector } from "./vector";
import { GameObject } from "./gameObject";
import { GameEngine } from "./gameEngine";

//Test comment commit """"

export class Ai implements GameObject
{
    public position: Vector;
    public gameEngine: GameEngine;

    public static aiLvl: string;

    public speed:number = 45;
    public height:number = 60;
    public width: number = 10;

    constructor(pos:Vector, eng: GameEngine){
        this.position = pos;
        this.gameEngine = eng;
    }

    moveObject(time: number): void{
        if(Ai.aiLvl == "easy"){
            if(this.gameEngine.ball.position.y<this.position.y)
            {
                this.position.y -= time/1750 * this.speed;
            }
            if(this.gameEngine.ball.position.y>this.position.y)
            {
                this.position.y += time/1750 * this.speed; 
            }
        }
        else if(Ai.aiLvl =="medium"){
            if(this.gameEngine.ball.position.y<this.position.y)
            {
                this.position.y -= time/1100 * this.speed;
            }
            if(this.gameEngine.ball.position.y>this.position.y)
            {
                this.position.y += time/1100 * this.speed; 
            }
        }
        else if(Ai.aiLvl =="hard"){
            if(this.gameEngine.ball.position.y<this.position.y)
            {
                this.position.y -= time/650 * this.speed;
            }
            if(this.gameEngine.ball.position.y>this.position.y)
            {
                this.position.y += time/650 * this.speed; 
            }
        }
        else if(Ai.aiLvl =="mult"){
            if(this.gameEngine.keyPressUp)
            {
                this.position.y -= time/1000 * this.speed;
            }
            if(this.gameEngine.keyPressDown)
            {
                this.position.y += time/1000 * this.speed; 
            }
        }

    }

    onCollision(obj: GameObject): void
    {
        
    }

    drawObject(ctx: CanvasRenderingContext2D): void
    {
        ctx.fillRect(this.position.x-this.width,this.position.y-this.height,this.width,this.height);
    }

}