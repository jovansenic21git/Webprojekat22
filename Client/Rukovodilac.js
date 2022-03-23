export class Rukovodilac
{
    constructor(id, ime, prezime, godine)
    {
        this.id=id;
        this.ime=ime;
        this.prezime=prezime;
        this.godine=godine;
        this.kont=null;
    }
    crtajrukovodilac(host)
    {
        let div = document.createElement("div");
        div.className="slika";
        host.appendChild(div);

        let img = document.createElement("img");
        img.src="slike/"+this.id+".jpg";
        div.appendChild(img);

        let labelime= document.createElement("label");
        labelime.innerHTML="Ime koreografa: "+this.ime;
        host.appendChild(labelime);

        labelime= document.createElement("label");
        labelime.innerHTML="Prezime koreografa: "+this.prezime;
        host.appendChild(labelime);
    }

}