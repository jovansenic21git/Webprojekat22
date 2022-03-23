var listaclanova =[];
export class Clan{
    constructor(id, ime, prezime, godine, dolasci, datumupis, maxdolasci)
    {
        this.id=id;
        this.ime=ime;
        this.prezime=prezime;
        this.godine=godine;
        this.dolasci=dolasci;
        this.datumupis=datumupis;
        this.maxdolasci=maxdolasci;
        this.kont=null;
    }
    crtajtabelu(host)
    {
        var tr = document.createElement("tr");
        host.appendChild(tr);
        tr.className="red";
        //tr.className=this.id;
        this.kont=tr;

        let el = document.createElement("td");
        el.className=this.id;
        el.innerHTML=this.ime;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.prezime;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.godine;
        tr.appendChild(el);

        el=document.createElement("td");
        el.innerHTML=this.datumupis;
        el.className="datumm";
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.dolasci;
        el.className="dola";
        tr.appendChild(el);

        el = document.createElement("button");
        el.innerHTML="+";
        tr.appendChild(el);
        el.onclick=(ev)=>
        {
            this.operacija(1);
        }

        let el1 = document.createElement("button");
        el1.innerHTML="-";
        tr.appendChild(el1);
        el1.onclick=(ev)=>
        {
            this.operacija(0);
        }

        tr.onclick=(ev)=>{
            let ime = document.querySelector(".ime");
            let prezime = document.querySelector(".prezime");
            let godine = document.querySelector(".godine");
            let datumm = document.querySelector(".datum");
            ime.value = this.ime;
            prezime.value = this.prezime;
            godine.value = this.godine;
            let nasdatum = this.kont.querySelector(".datumm").innerHTML;
            datumm.value = nasdatum;
            let provera = document.querySelector(".sel");
            //console.log(provera);
            if(provera!=null)
            {
                provera.className="red";
                tr.className="sel";
            }
            else tr.className="sel";
            let divclanarine=this.obrisi();
            this.crtajclnaraine(divclanarine);
            //console.log(nasdatum);
        }
        
    }
    obrisi()
    {
        let ceoprikaz = document.querySelector(".cclan");
        //let roditelj = ceoprikaz.parentNode;
        //roditelj.removeChild(ceoprikaz);
        let roditelj = document.querySelector(".unos");
        if(ceoprikaz!=null)
        {
            let roditelj = ceoprikaz.parentNode;
            roditelj.removeChild(ceoprikaz);
        }
        
        ceoprikaz= document.createElement("div");
        ceoprikaz.className="cclan";
        roditelj.appendChild(ceoprikaz);
        return ceoprikaz;
    }
    crtajclnaraine(host)
    {
        let se = document.createElement("select")
        se.className="clanarineopcije";
        host.appendChild(se);
        let op = document.createElement("option");
        op.innerHTML="Placene";
        op.value = true;
        se.appendChild(op);
        op = document.createElement("option");
        op.innerHTML="Neplacene";
        op.value = false;
        se.appendChild(op);
        let divravno= document.createElement("div");
        divravno.className="ravno";
        divravno.appendChild(se);
        
        let buttom = document.createElement("button");
        buttom.innerHTML="Pormeni";
        divravno.appendChild(buttom);
        host.appendChild(divravno);
        let divcb = document.createElement("div");
        divcb.className="divcb";
        host.appendChild(divcb);
        this.crtajclanarine2(divcb);
        se.addEventListener("change",()=>
        {
            divcb=this.obrisi3(divcb);
            this.crtajclanarine2(divcb);
        })
        buttom.onclick=ev=>
        {
            let selektovano = divcb.querySelectorAll("input[type='checkbox']:checked");
            if(selektovano == null)
            {
                alert("Niste selektovali ni jednu clanarinu");
                return;
            }
            let nizclnaraina ="";
            for(let i=0;i<selektovano.length;i++)
            {
                nizclnaraina = nizclnaraina.concat(selektovano[i].value, "a");
            }
            let id = document.querySelector(".sel");
            let id2 = id.querySelector("td");
            let id3=id2.className;
            this.izmeni(id3, nizclnaraina,divcb);
        }
    }

    izmeni(idclan, promene, host)
    {
        fetch("https://localhost:5001/Spoj/PromeniUplate?clana="+idclan+"&promene="+promene,
            {method : "PUT"}
        )
        .then( s=>
        {
            if(s.ok) {
                alert("Cestitke!");
                host = this.obrisi3(host);
                this.crtajclanarine2(host);
            }
        });
    }
    obrisi3(host)
    {
        let ceoprikaz = document.querySelector(".divcb");
        console.log("Izmenjeni:",ceoprikaz);
        let roditelj = ceoprikaz.parentNode;
        console.log("Roditelj:",roditelj);
        roditelj.removeChild(ceoprikaz);

        ceoprikaz= document.createElement("div");
        ceoprikaz.className="divcb";
        roditelj.appendChild(ceoprikaz);
        return ceoprikaz;
    }
    obrisi2(host)
    {
        let ceoprikaz = host;
        console.log(ceoprikaz);
        let roditelj = ceoprikaz.parentNode;
        console.log(roditelj);
        roditelj.removeChild(ceoprikaz);

        ceoprikaz= document.createElement("div");
        ceoprikaz.className="divcb";
        roditelj.appendChild(ceoprikaz);
        return ceoprikaz;
    }
    crtajclanarine2(host)
    {   
        let roditelj = host.parentNode;
        let l, cb;
        let pod1 = roditelj.querySelector("select");
        var pod2= pod1.options[pod1.selectedIndex].value;
        fetch("https://localhost:5001/Spoj/VratiSveUplateClana?vrstauplate=+"+pod2+"&clan="+this.id)
            .then(p=>{
                p.json().then(spojevi =>
                    {
                        if(spojevi==null){host.className="bomm";}
                        else{
                            host.className="divcb";
                            spojevi.forEach(element => {
                            let divravno = document.createElement("div");
                            divravno.className="ravno2";
                            l = document.createElement("label");
                            l.innerHTML=element.naziv;
                            cb = document.createElement("input");
                            cb.type="checkbox";
                            cb.value = element.id;
                            divravno.appendChild(l);
                            divravno.appendChild(cb);
                            host.appendChild(divravno);
                        });
                    }
                    })
            })
    }
    operacija(prom)
    {
        let dol = this.kont.querySelector(".dola");
        //console.log(dol);
        if(prom==1)
        {
            this.dolasci++;
            if(this.dolasci>this.maxdolasci)
            {
                alert("Opet ga pretera");
                this.dolasci=this.maxdolasci;
            }
            else{
                fetch("https://localhost:5001/Clan/PromeniDolazak?clan="+this.id+"&dolazak=1",
                {
                    method: "PUT"
                }).then(s=>
                    {
                        if(s.ok) {}
                    });
            }
            
        }
        else 
        {
            this.dolasci--;
            if(this.dolasci<0)
            {
                alert("Pretera ga");
                this.dolasci=0;
            }
            else
            {
                fetch("https://localhost:5001/Clan/PromeniDolazak?clan="+this.id+"&dolazak=0",
                {
                    method: "PUT"
                }).then(s=>
                    {
                        if(s.ok) {}
                    });
            }
            
        }
        dol.innerHTML=this.dolasci;
        
    }
}
