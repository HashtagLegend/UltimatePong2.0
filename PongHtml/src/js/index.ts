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
/*
let saveEditButton = document.getElementById('SaveEditButton') as HTMLButtonElement;
let brugernavnEdit = document.getElementById('BrugernavnEdit') as HTMLInputElement;
let descriptionEdit = document.getElementById('DescriptionEdit') as HTMLInputElement;
saveEditButton.addEventListener('click', saveEdit);
function saveEdit(){
    axios.put("https://ponghighscorewebservice.azurewebsites.net/api/bruger/" + profile.getId(), {brugernavn : brugernavnEdit, description : descriptionEdit})
    .then(function (response) {
        console.log(response);
        location.href="http://localhost:3000/ProfileEdit.html";
        })
        .catch(function (error) {
        console.log(error);
        } );
}
*/
