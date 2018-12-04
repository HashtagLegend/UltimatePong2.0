import axios, {AxiosResponse, AxiosError} from "../../node_modules/axios/index";

interface IBruger{
    id : number
    brugernavn : string
    description : string
    wins : number
    loses : number
    aI_Wins : number
    aI_Loses : number
}



