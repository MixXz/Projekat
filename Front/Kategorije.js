import { Receptic } from "./Receptic.js";
import { ocistiFormu } from "./Recepti.js";

export class Kategorija
{
    constructor(id, naziv){

        this.id = id;
        this.naziv = naziv;

        this.container = null; 
    }

    ucitajRecepte(idKategorije, hostRecepti){
      fetch("https://localhost:5001/Recept/PreuzmiRecepte/" + idKategorije,
      {
          method:"GET"
      }).then(r => {

        if(r.ok){
            this.obrisiPrethodno(hostRecepti);
            r.json().then(data => {;
                data.forEach(r => {
                    let recept = new Receptic(r.id, r.naziv, r.opis, r.kategorija, r.sastojci, r.instrukcija, r.tezinaPripreme, r.vremePripreme, r.tip, r.slika);
                    recept.iscrtajRecept(hostRecepti);
                });
            })
        }
      })

    }

    obrisiPrethodno(host){
        var p = host.querySelectorAll(".images");
        p.forEach(el => {
            el.remove();
        })
    }

    iscrtajKategoriju(hostLista, hostRecepti, elContainer){

        this.iscrtajStavku(hostLista, hostRecepti);

        let op = document.createElement("option");
        op.innerHTML = this.naziv;
        op.value = this.id;
        let cont = elContainer.querySelector(".selectKategorija");
        cont.appendChild(op);
        cont.value = "";

    }

    iscrtajStavku(host, hostRecepti){
        const pocetna = document.createElement("li");
        pocetna.innerHTML = this.naziv;
        pocetna.className = "li"
        pocetna.addEventListener("click", () => {
            
            let forma = hostRecepti.parentNode;
            let p = forma.querySelector(".buttonBox");
            let b = forma.querySelector(".btnSacuvaj");
            if(b != null)
                p.removeChild(b);
            forma.querySelector(".btnDodaj").style.visibility = "hidden";
            forma.querySelector(".forma").style.visibility = "hidden";
            this.iscrtajPodnaslov(hostRecepti);
            this.ucitajRecepte(this.id, hostRecepti);
            ocistiFormu(forma);
        });
        host.appendChild(pocetna);
    }

    iscrtajPodnaslov(host){
        var p = host.querySelectorAll(".podnaslov");

        p.forEach(el => {
            el.remove();
        })

        let podnaslov = document.createElement("div");
        podnaslov.className = "podnaslov";
        if(this.id == 3)
        {
            podnaslov.innerHTML = "RECEPTI ZA VEČERU";
        }
        else
        {
            podnaslov.innerHTML = "RECEPTI ZA " + this.naziv.toUpperCase();
        }
        host.appendChild(podnaslov);
    }
}