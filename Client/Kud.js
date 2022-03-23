import { Ansambl } from "./Ansambl.js";
import { Clan } from "./Clan.js";
import { Rukovodilac } from "./Rukovodilac.js";
import {pocetna } from "./main.js";
let listaclanova =[];
export class Kud
{
    constructor(naziv, adresa, mesto, listaansambli)
    {
        this.naziv=naziv;
        this.adresa=adresa;
        this.mesto=mesto;
        this.listaansambli=listaansambli;
        this.kont=null;
    }
    crtajKud(host){

        this.kont=document.createElement("div");
        this.kont.className="kontejner";
        host.appendChild(this.kont);

        let divglavni = document.createElement("div");
        divglavni.className="glavni";
        this.kont.appendChild(divglavni);

        let div = document.createElement("div");
        div.className="dugmad";
        divglavni.appendChild(div);
        //let divizbor =  document.createElement("div");
        //divizbor.className="izbor";
        //divglavni.appendChild(divizbor);
        //let divizbor =  document.createElement("div");
        //divizbor.className="izbor";
        //divglavni.appendChild(divizbor);
        //let l = document.createElement("label");
        //l.innerHTML="Prikaz po ansamblima";
        //divizbor.appendChild(l);
        //let izbor1= document.createElement("input");
        //izbor1.type ="radio";
        //izbor1.name="prikaz";
        //izbor1.value=1;
        //izbor1.checked=true;
        //divizbor.appendChild(izbor1);
        //l = document.createElement("label");
        //l.innerHTML="Prikaz po clanarinama";
        //divizbor.appendChild(l);
        //izbor1=document.createElement("input");
        //izbor1.type="radio";
        //izbor1.name="prikaz";
        //izbor1.value=2;
        //divizbor.appendChild(izbor1);
        let l = document.createElement("input");
        l.type="button";
        l.value="Nazad";
        l.className="dugmenazad";

        let op = document.createElement("input");
        op.type="button";
        op.value="Grafik";
        op.className="dugmegrafik";
            let divv = document.createElement("div");
            divv.className="modal2";
            //div.id="modal";
            let div1 = document.createElement("div");
            div1.className="modal-heder";
            divv.appendChild(div1);
            let div12 = document.createElement("div");
            div12.className="title";
            div12.innerHTML="Graficki prikaz prisustva na probama";
            let zatvori = document.createElement("input");
            zatvori.type="button";
            zatvori.className="close-button";
            //zatvori.id="#data-close-button";
            zatvori.value="X"
            div1.appendChild(zatvori);
            div1.appendChild(div12);
            let div11 = document.createElement("div");
            div11.className="modal-body2";
            let div14 = document.createElement("div");
            div14.className="grafici";
            div11.appendChild(div14);
            //body
            
            //let ln = document.createElement("label");
            //ln.innerHTML="Naziv nove clanarine: ";
            //div11.appendChild(ln);
            //ln = document.createElement("input");
            //ln.type="text";
            //div11.appendChild(ln);
            divv.appendChild(div11);
            //let btn = document.createElement("input");
           //btn.type="button";
            //btn.value="Dodaj";
            //btn.className="dodajcl";
            //div11.appendChild(btn);
            this.listaansambli.forEach( i => 
                {
                    let ansambldiv = document.createElement("div");
                    ansambldiv.classList="ansambldiv";
                    div14.appendChild(ansambldiv);   
                    let imeans= document.createElement("label");
                    imeans.innerHTML=i.naziv+" Max: "+i.mprobe;
                    ansambldiv.appendChild(imeans);
                    //console.log(i.id);
                    this.prosbr(ansambldiv, i.id);
                    
                    
                })
            let div13 = document.createElement("div");
            div13.className="overlay";
            //div13.id="overlay"
            document.body.appendChild(divv);
            document.body.appendChild(div13);
        op.onclick=ev=>{
            divv.classList.add('activem');
            div13.classList.add('activeo');
        }
        zatvori.onclick=ev=>{
            divv.classList.remove('activem');
            div13.classList.remove('activeo');
        
        }
        l.onclick=ev=>{
           pocetna();
           this.obrisiglavni(divglavni);
        }
        div.appendChild(l);
        div.appendChild(op);
        let divcrtaj = document.createElement("div");
        divcrtaj.className="divcrtaj";
        divglavni.appendChild(divcrtaj);
        let ll = document.createElement("div");
        ll.className="donjinaslov";
        //div.appendChild(divizbor);
        this.crtajans(divcrtaj);
    }
    crtajans(host)
    {
        let divravno = document.createElement("div");
        divravno.className="ravno";
        let divzaunos = document.createElement("div");
        divzaunos.className="unos";
        host.appendChild(divzaunos);
        divzaunos.appendChild(divravno);

        let label = document.createElement("label");
        label.innerHTML="Ime:  ";
        divravno.appendChild(label);
        let ime = document.createElement("input");
        ime.type="text";
        ime.className="ime";
        divravno.appendChild(ime);

        divravno = document.createElement("div");
        divravno.className="ravno";
        label = document.createElement("label");
        label.innerHTML="Prezime: ";
        divravno.appendChild(label);
        let prezime = document.createElement("input");
        prezime.type="text";
        prezime.className="prezime";
        divravno.appendChild(prezime);
        divzaunos.appendChild(divravno);

        divravno = document.createElement("div");
        divravno.className="ravno";
        label = document.createElement("label");
        label.innerHTML="Godine: ";
        divravno.appendChild(label);
        let godine = document.createElement("input");
        godine.type="number";
        godine.className="godine";
        divravno.appendChild(godine);
        divzaunos.appendChild(divravno);
        
        divravno = document.createElement("div");
        divravno.className="ravno";
        label = document.createElement("label");
        label.innerHTML="Datum: ";
        divravno.appendChild(label);
        let datum = document.createElement("input");
        datum.type="date";
        datum.className="datum";
        datum.value="2022-03-21";

        divravno.appendChild(datum);
        divzaunos.appendChild(divravno);

        divravno = document.createElement("div");
        divravno.className="ravno";
        /*label = document.createElement("label");
        label.innerHTML="Funkcije: "; 
        divravno.appendChild(label);*/
        let dugme = document.createElement("button");
        dugme.innerHTML="Dodaj";
        divravno.appendChild(dugme);
        divzaunos.appendChild(divravno);
        let dugme2 = document.createElement("button");
        dugme2.innerHTML="Obrisi";
        dugme2.className="dugme2";
        let dugme3 = document.createElement("button");
        dugme3.className="dugme3";
        dugme3.innerHTML="Premesti";
        divravno.appendChild(dugme2);
        divravno.appendChild(dugme3);
        divzaunos.appendChild(divravno);

        //horor
        let divclanovi = document.createElement("div");
        divclanovi.className="divclanovi";
        host.appendChild(divclanovi);
        let ispod= document.createElement("div");
        let divred = document.createElement("div");
        ispod.appendChild(divred);
        divclanovi.appendChild(ispod);
        ispod.className="ispod";
        label= document.createElement("label");
        label.innerHTML="Ansambl: ";
        divred.className="opcije";
        divred.appendChild(label);
        //divclanovi.appendChild(divred);
        let se = document.createElement("select");
        se.className="opcijee";
        divred.appendChild(se);
        //console.log(this.listaansambli);
        let lista2ansambli = this.listaansambli;
        console.log(this.listaansambli.length);
        lista2ansambli.forEach((p) => {
            console.log(p);
            let op = document.createElement("option");
            op.innerHTML=p.naziv;
            op.value=p.id;
            se.appendChild(op);
        });
        let l = document.createElement("input");
        l.type="button";
        l.className="restujdugme";
        l.value="Resetuj";
        divred.appendChild(l);
        l.onclick=ev=>{
            let podatak = divclanovi.querySelector("select");
            var podatak2 = podatak.options[podatak.selectedIndex].value;
            fetch("https://localhost:5001/Clan/Resetuj?ime_kud="+this.naziv+"&ansambl="+podatak2,
            {method : "PUT"}
            )
            .then( s=>
            {
                if(s.ok) {
                    alert("Uspesno ste restovali dolaske na probe");
                    tabeladiv = this.obrisiprethodno2();
                    this.crtajzaglavlje(tabeladiv,divclanovi);
                }
            });
        }
        let lv = document.createElement("input");
        lv.type="button";
        lv.className="dodajclanarainu";
        lv.value="Dodaj clanarinu";
        lv.id="#modal";
        divred.appendChild(lv);
            let div = document.createElement("div");
            div.className="modal";
            //div.id="modal";
            let div1 = document.createElement("div");
            div1.className="modal-heder";
            div.appendChild(div1);
            let div12 = document.createElement("div");
            div12.className="title";
            //div12.innerHTML="Opa";
            let zatvori = document.createElement("input");
            zatvori.type="button";
            zatvori.className="close-button";
            //zatvori.id="#data-close-button";
            zatvori.value="X"
            div1.appendChild(zatvori);
            div1.appendChild(div12);
            let div11 = document.createElement("div");
            div11.className="modal-body";
            let ln = document.createElement("label");
            ln.innerHTML="Naziv nove clanarine: ";
            div11.appendChild(ln);
            ln = document.createElement("input");
            ln.type="text";
            div11.appendChild(ln);
            div.appendChild(div11);
            let btn = document.createElement("input");
            btn.type="button";
            btn.value="Dodaj";
            btn.className="dodajcl";
            let btn2 = document.createElement("input");
            btn2.type="button";
            btn2.value = "Izbrisi";
            btn2.className="izbrisicl";
            div11.appendChild(btn);
            div11.appendChild(btn2);
            let div13 = document.createElement("div");
            div13.className="overlay";
            //div13.id="overlay"
            document.body.appendChild(div);
            document.body.appendChild(div13);
        btn2.onclick=ev=>
        {
            let prob = ln.value;
            if(prob=="") alert("Niste uneli novu clnarainu");
            fetch("https://localhost:5001/Spoj/IzbrisiClanarinu?del="+prob,{
                    method: "DELETE"
                }).then(s=>{
                    if(s.ok) 
                    {
                        alert("Uspesno ste dodali novu clanarinu");
                    }
                    tabeladiv = this.obrisiprethodno2();
                    this.crtajzaglavlje(tabeladiv,divclanovi);
                    tabeladiv.className="tabeladiv";
                    ispod.appendChild(tabeladiv);
                    div.classList.remove('activem');
                    div13.classList.remove('activeo');
                })

        }
        btn.onclick=ev=>{
            let prob = ln.value;
            if(prob=="") alert("Niste uneli novu clnarainu");
            fetch("https://localhost:5001/Spoj/DodajNovuClanarinu?nova="+prob+"&nazivkud="+this.naziv,{
                    method: "POST"
                }).then(s=>{
                    if(s.ok) 
                    {
                        alert("Uspesno ste dodali novu clanarinu");
                    }
                    tabeladiv = this.obrisiprethodno2();
                    this.crtajzaglavlje(tabeladiv,divclanovi);
                    tabeladiv.className="tabeladiv";
                    ispod.appendChild(tabeladiv);
                    div.classList.remove('activem');
                    div13.classList.remove('activeo');

                    //page.location.reload();
                });
        }
        lv.onclick=ev=>{
            div.classList.add('activem');
            div13.classList.add('activeo');
        }
        zatvori.onclick=ev=>{
            div.classList.remove('activem');
            div13.classList.remove('activeo');
        
        }
        
        let rukovodilac =document.createElement("div");
        rukovodilac.className="rukovodilac";
        host.appendChild(rukovodilac);
        this.crtajrukovodioca(rukovodilac);
        let tabeladiv = document.createElement("div");
        tabeladiv.className="tabeladiv";
        ispod.appendChild(tabeladiv);
        this.crtajzaglavlje(tabeladiv, divclanovi);
        se.addEventListener("change", ()=>{
            rukovodilac =this.obrisirukovodioca(rukovodilac);
            this.crtajrukovodioca(rukovodilac);
            tabeladiv = this.obrisiprethodno2();
            this.crtajzaglavlje(tabeladiv, divclanovi);
        });
        dugme2.onclick=ev=>
        {
            let pokupiime = ime.value;
            let pokupiprezime = prezime.value;
            let poukpigodine = godine.value;
            let pokupidatum = datum.value;
            let podatak = divclanovi.querySelector("select");
            var pokupiansambl = podatak.options[podatak.selectedIndex].value;
            if(pokupiime==""||pokupiprezime==""||poukpigodine==""||poukpigodine<0||pokupidatum=="")
            {
                alert("Nisu uneseni adekvatni podaci");
            }
            //IZMENITI ZA IME
            else{
                fetch("https://localhost:5001/Clan/Ukloniclana?ime_kud="+this.naziv+"&ansambl="+pokupiansambl+"&ime="+pokupiime+"&prezime="+pokupiprezime+"&datum="+pokupidatum,{
                    method: "DELETE"
                }).then(s=>{
                    if(s.ok)
                    {
                        ime.value=" ";
                        prezime.value=" ";
                        godine.value=0;
                        datum.value="2022-03-22";
                        alert("Uspesno ste obrisali clana");
                    }
                    tabeladiv = this.obrisiprethodno2();
                    this.crtajzaglavlje(tabeladiv,divclanovi);
                    tabeladiv.className="tabeladiv";
                    ispod.appendChild(tabeladiv);
                    //page.location.reload();
                });
            }
        }
        dugme.onclick=ev=>
        {
            
            let pokupiime = ime.value;
            let pokupiprezime = prezime.value;
            let poukpigodine = godine.value;
            let pokupidatum = datum.value;
            let podatak = divclanovi.querySelector("select");
            var pokupiansambl = podatak.options[podatak.selectedIndex].value;
            if(pokupiime==""||pokupiprezime==""||poukpigodine==""||poukpigodine<0||pokupidatum=="")
            {
                alert("Nisu uneseni adekvatni podaci");
            }
            //IZMENITI ZA IME
            else{
                fetch("https://localhost:5001/Clan/DodajClana?ime_kud="+this.naziv+"&ansambl="+pokupiansambl+"&im="+pokupiime+"&pr="+pokupiprezime+"&god="+poukpigodine+"&datu="+pokupidatum,{
                    method: "POST"
                }).then(s=>{
                    if(s.ok) 
                    {
                        alert("Uspesno ste dodali novog clana");
                    }
                    tabeladiv = this.obrisiprethodno2();
                    this.crtajzaglavlje(tabeladiv,divclanovi);
                    tabeladiv.className="tabeladiv";
                    ispod.appendChild(tabeladiv);

                    //page.location.reload();
                });
            }
        }

        dugme3.onclick=ev=>
        {
            
            let pokupiime = ime.value;
            let pokupiprezime = prezime.value;
            let poukpigodine = godine.value;
            let pokupidatum = datum.value;
            let podatak = divclanovi.querySelector("select");
            var pokupiansambl = podatak.options[podatak.selectedIndex].value;
            if(pokupiime==""||pokupiprezime==""||poukpigodine==""||poukpigodine<0||pokupidatum=="")
            {
                alert("Nisu uneseni adekvatni podaci");
            }
            //IZMENITI ZA IME
            else{
                fetch("https://localhost:5001/Clan/Premesti?ime_kud="+this.naziv+"&ansambl="+pokupiansambl+"&ime="+pokupiime+"&prezime="+pokupiprezime+"&godine="+poukpigodine+"&datum="+pokupidatum, {
                    method: "PUT"
                }).then(s=>{
                    if(s.ok) 
                    {
                        alert("Uspesno ste premestili clana");
                    }
                    tabeladiv = this.obrisiprethodno2();
                    this.crtajzaglavlje(tabeladiv,divclanovi);
                    tabeladiv.className="tabeladiv";
                    ispod.appendChild(tabeladiv);

                    //page.location.reload();
                });
            }
        }
    }
    crtajrukovodioca(host)
    {
        let l = host.parentNode;
        let podatak = l.querySelector("select");
        var podatak2 = podatak.options[podatak.selectedIndex].value;

        fetch("https://localhost:5001/Rukovodilac/PreuzmiRukovodilac?kud="+this.naziv+"&ansambl="+podatak2)
        .then(p=>{
            p.json().then(rukovodilac =>{
                var a = new Rukovodilac(rukovodilac.id,rukovodilac.ime,rukovodilac.prezime, rukovodilac.godine);
                a.crtajrukovodilac(host);
            })
        })
        
    }

    obrisirukovodioca(host)
    {
        var ceoprikaz = host
        var roditelj = ceoprikaz.parentNode;
        roditelj.removeChild(ceoprikaz);

        ceoprikaz=document.createElement("div");
        ceoprikaz.className="rukovodilac";
        roditelj.appendChild(ceoprikaz);
        return ceoprikaz;
    }
    crtajzaglavlje(host, divclanovi)
    {

        var tabella = document.createElement("table");
        tabella.className="tabella";
        host.appendChild(tabella);

        var tabellahead = document.createElement("thead");
        tabella.appendChild(tabellahead);

        var tr = document.createElement("tr");
        tabellahead.appendChild(tr);

        var tabelabody= document.createElement("tbody");
        tabelabody.className="TabelaPodaci";
        tabella.appendChild(tabelabody);

        let th;
        var zag=["Ime","Prezime","Godine","Datum Upisa","Dolasci"];
        zag.forEach(el => {
            th=document.createElement("th");
            th.innerHTML=el;
            tr.appendChild(th);
        })
        this.crtajclanoveansambl(tabelabody, divclanovi);
        
    }


    crtajclanoveansambl(host, divclanovi)
    {
        listaclanova = [];
        let podatak = divclanovi.querySelector("select");
        var podatak2 = podatak.options[podatak.selectedIndex].value;
        //console.log(podatak2);
        fetch("https://localhost:5001/Clan/PreuzmiClanove/"+podatak2+"?kud="+this.naziv)
        .then(p=>{
            
            p.json().then(clanovi=>
                {
                    
                    clanovi.forEach(clann=>
                    {
                        var clan = new Clan(clann.id,clann.ime,clann.prezime, clann.godine, clann.dolasci, clann.datumUpis, clann.maxdolasci);
                        //console.log(clan);
                        clan.crtajtabelu(host);
                        
                    });
                    
                })
        })
    }
    obrisi()
    {
        let brisanje = document.querySelector(".cclan");
        let roditelj = brisanje.parentNode;
        roditelj.removeChild(brisanje);
    }
    obrisiprethodno2()
    {
        var ceoprikaz = document.querySelector(".tabeladiv");
        var roditelj = ceoprikaz.parentNode;
        roditelj.removeChild(ceoprikaz);

        ceoprikaz=document.createElement("div");
        ceoprikaz.className="tabeladiv";
        roditelj.appendChild(ceoprikaz);
        let brisanje = document.querySelector(".cclan");
        if(brisanje!=null) this.obrisi();
        return ceoprikaz;
    }
    obrisiprethodno()
    {
        var ceoprikaz = document.querySelector(".divcrtaj");
        var roditelj = ceoprikaz.parentNode;
        roditelj.removeChild(ceoprikaz);

        ceoprikaz=document.createElement("div");
        ceoprikaz.className="divcrtaj";
        roditelj.appendChild(ceoprikaz);
        return ceoprikaz;
    }
    obrisiglavni(host)
    {
        let roditelj=host.parentNode;
        roditelj.removeChild(host);

    }
    prosbr(host, ans)
    {
        let prikupi;
        fetch("https://localhost:5001/Ansambl/Preuzmiprosekposeta?anasambl="+ans,)
        .then(p=>
            {
                p.json().then(ans=>
                    {
                        for(let i=0; i<ans.prob;i++)
                        {
                            let crnidiv = document.createElement("div");
                            crnidiv.className="crnidiv";
                            host.appendChild(crnidiv);
                        }
                        let imamo = document.createElement("label");
                        imamo.innerHTML="Imamo: "+ans.prob;
                        host.appendChild(imamo);
                    })
            })
   
    }
}