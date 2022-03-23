import { Ansambl } from "./Ansambl.js";
import { Kud } from "./Kud.js";
var listaansambala =[];
var listaansambala2=[];
pocetna();
export function pocetna()
{
    let h1 = document.createElement("h1");
    h1.innerHTML="Dobrodosli!";
    let divuvod = document.createElement("div");
    divuvod.className="uvod";
    document.body.appendChild(divuvod);
    divuvod.appendChild(h1);
    let button = document.createElement("button");
    button.innerHTML="AFA ORO";
    divuvod.appendChild(button);
    let buttonn =document.createElement("button");
    buttonn.innerHTML="KUD KOLO";
    divuvod.appendChild(buttonn);
    button.onclick=ev=>{
        listaansambala=[];
        fecuj(button.innerHTML);
    }
    

    buttonn.onclick=(ev)=>{
        listaansambala=[];
        fecuj(buttonn.innerHTML);
    }
    
    //console.log(kud1);

}
function fecuj(naziv)
{
    fetch("https://localhost:5001/Ansambl/PreuzmiAnsambl/"+naziv)
    .then(p=>{
    p.json().then(ansambli=>{
        //console.log(ansambli);
        ansambli.forEach(ansambl => {
            var a = new Ansambl(ansambl.id, ansambl.naziv, ansambl.probemes, ansambl.rukovodilac, ansambl.count);
            //console.log(a);
            listaansambala.push(a);
        });
        const kud1 = new Kud(naziv, "Sumatovacka bb - Banovina", "Grad Nis", listaansambala);
    //console.log(kud1);
        obrisi();
        kud1.crtajKud(document.body);
    })
    
})
}
function obrisi()
{
    let selektuj = document.querySelector(".uvod");
    document.body.removeChild(selektuj);
}
