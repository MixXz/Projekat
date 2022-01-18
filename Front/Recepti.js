import { Kategorija } from "./Kategorije.js";
import { TezinaPripreme } from "./TezinaPripreme.js";
import { Tipovi } from "./Tipovi.js";

export class Recepti
{
    constructor(){

        this.kategorije = [];
        this.listaTipova = [];
        this.div = null; 
    }
    
    iscrtaj(host){
        if(!host)
            throw new Error("Host nije definisan!");
        
        const pozadina = document.createElement("div");
        pozadina.className = "pozadina";
        host.appendChild(pozadina);

        const naslov = document.createElement("div");
        naslov.className = "naslov";
        naslov.innerHTML = "ONLINE KNJIGA RECEPATA";
        pozadina.appendChild(naslov);

        const meni = document.createElement("div");
        meni.className = "meni";
        host.appendChild(meni);

        const lista = document.createElement("ul");
        lista.className = "lista";
        meni.appendChild(lista);

        const meniDodaj = document.createElement("div");
        meniDodaj.className = "meniDodaj";
        host.appendChild(meniDodaj);

        const ls = document.createElement("ul");
        ls.className = "lista";
        meniDodaj.appendChild(ls);

        const showForm = document.createElement("li");
        showForm.innerHTML = "Dodaj novi recept"
        showForm.className = "liDodaj";
        showForm.addEventListener("click", () => {
            pocetnaStranica.querySelector(".forma").style.visibility = "visible";
            let btn = pocetnaStranica.querySelector(".btnDodaj");
            if(window.getComputedStyle(btn).visibility === "hidden")
                btn.style.visibility = "visible";
        });
        ls.appendChild(showForm);

        let pocetnaStranica = document.createElement("div");
        pocetnaStranica.className = "pocetnaStranica";
        host.appendChild(pocetnaStranica);

        let zaRecepte = document.createElement("div");
        zaRecepte.className = "zaRecepte";
        pocetnaStranica.appendChild(zaRecepte);
        
        this.iscrtajFormu(pocetnaStranica);
        pocetnaStranica.querySelector(".forma").style.visibility="hidden";

        this.kategorije.forEach(kategorija => {

            kategorija.iscrtajKategoriju(lista, zaRecepte, this.div);
        });

    }

    iscrtajFormu(pocetnaStranica){

        const forma = document.createElement("div");
        forma.className = "forma";
        pocetnaStranica.appendChild(forma);

        let elContainer = document.createElement("div");
        elContainer.className = "elContainer";
        forma.appendChild(elContainer);

        let labela = document.createElement("label");
        labela.innerHTML = "Naziv: ";
        labela.className = "labela";
        elContainer.appendChild(labela);

        let el = document.createElement("input");
        el.type = "text";
        el.className = "naziv";
        elContainer.appendChild(el);

        labela = document.createElement("label");
        labela.innerHTML = "Opis: ";
        labela.className = "labela";
        elContainer.appendChild(labela);

        el = document.createElement("textarea");
        el.cols = "30";
        el.rows = "3"
        el.className = "textareaOpis";
        elContainer.appendChild(el);

        labela = document.createElement("label");
        labela.innerHTML = "Kategorija: ";
        labela.className = "labela";
        elContainer.appendChild(labela);

        let el1 = document.createElement("select");
        el1.className = "selectKategorija";
        elContainer.appendChild(el1);

        labela = document.createElement("label");
        labela.innerHTML = "Tip: ";
        labela.className = "labela";
        elContainer.appendChild(labela);

        let tipDiv = document.createElement("div");
        tipDiv.className = "tipDiv";
        elContainer.appendChild(tipDiv);
        this.preuzmiTipove(tipDiv);

        labela = document.createElement("label");
        labela.innerHTML = "Sastojci: ";
        labela.className = "labela";
        elContainer.appendChild(labela);

        el = document.createElement("textarea");
        el.cols = "30";
        el.rows = "10"
        el.className = "textareaSastojci"
        elContainer.appendChild(el);

        labela = document.createElement("label");
        labela.innerHTML = "Instrukcija: ";
        labela.className = "labela";
        elContainer.appendChild(labela);

        el = document.createElement("textarea");
        el.cols = "30";
        el.rows = "10"
        el.className = "textareaInstrukcija"
        elContainer.appendChild(el);

        labela = document.createElement("label");
        labela.innerHTML = "Težina pripreme: ";
        labela.className = "labela";
        elContainer.appendChild(labela);

        let selectTezina = document.createElement("select");
        selectTezina.className = "selectTezina";
        elContainer.appendChild(selectTezina);
        this.preuzmiTezine(selectTezina);

        labela = document.createElement("label");
        labela.innerHTML = "Vreme potrebno za pripremu: ";
        labela.className = "labela";
        elContainer.appendChild(labela);

        el = document.createElement("input");
        el.type = "text";
        el.className = "vreme";
        elContainer.appendChild(el);

        labela = document.createElement("label");
        labela.innerHTML = "Slika: ";
        labela.className = "labela";
        elContainer.appendChild(labela);

        el = document.createElement("input");
        el.type = "text";
        el.className = "slikaInput";
        elContainer.appendChild(el);

        let buttonBox = document.createElement("div");
        buttonBox.className = "buttonBox";
        forma.appendChild(buttonBox);

        let button = document.createElement("button");
        button.innerHTML = "Dodaj Recept";
        button.classList.add("button");
        button.className = "btnDodaj";
        buttonBox.appendChild(button);
        button.onclick = (ev)=>{
            this.dodajNoviRecept();
        } 

        this.div = elContainer;
    }

    dodajNoviRecept(){

        let naziv = this.div.querySelector(".naziv").value;
        let opis = this.div.querySelector(".textareaOpis").value;
        let kategorija = this.div.querySelector(".selectKategorija").value;
        let nest = this.div.querySelectorAll("input[type='radio']");
        let br = 0;
        nest.forEach(p =>{
            if(p.checked == false)
                br++
        })
        if(br > 2){
            alert("Izaberite tip!");
            return;
        }
        let tip = this.div.querySelector("input[type='radio']:checked").value;
        let sastojci = this.div.querySelector(".textareaSastojci").value;
        let instrukcija = this.div.querySelector(".textareaInstrukcija").value;
        let tezina = this.div.querySelector(".selectTezina").value;
        let vreme = this.div.querySelector(".vreme").value;
        let slikica = this.div.querySelector(".slikaInput").value;

        if(naziv == ""){
            alert("Polje Naziv ne sme ostati prazno!");
            return;
        }
        if(kategorija == ""){
            alert("Izaberite kategoriju!");
            return;
        }
        if(sastojci == ""){
            alert("Polje Sastojci ne sme ostati prazno!");
            return;
        }
        if(instrukcija == ""){
            alert("Polje Instrukcija ne sme ostati prazno!");
            return;
        }
        if(vreme == ""){
            alert("Unesite vreme potrebno za pripremu jela!");
            return;
        }
        if(tezina == ""){
            alert("Izaberite tezinu!");
            return;
        }
        if(slikica == ""){
            alert("Unesite sliku jela!");
            return;
        }

        if (confirm("Da li ste sigurni da želite da dodate recept?"))
        {
            fetch("https://localhost:5001/Recept/DodajRecept/" + naziv +"/" + opis + "/" + kategorija + "/" + sastojci + "/" + instrukcija + "/" + tezina + "/" + vreme + "/" + slikica + "/" + tip,{

                method: "POST"

            }).then(r => {
                if(r.ok){

                    var kat = new Kategorija(kategorija, "naziv");
                    kat.ucitajRecepte(kategorija, document.querySelector(".zaRecepte"));
                    let f = this.div.parentElement;
                    f.style.visibility = "hidden";
                }
                else{
                    alert("Dodavanje recepta nije uspelo!");
                }
            })
        }
        else{
            console.log("Otkazano dodavanje recepta");
        }

        ocistiFormu(this.div);
    }

    preuzmiTipove(host){
        fetch("https://localhost:5001/Kategorija/PreuzmiTip")
        .then(p => {

            p.json().then(tipovi => {
        
                tipovi.forEach(tip => {
                    
                    var t = new Tipovi(tip.id, tip.naziv);
                    t.iscrtajRadioBtn(host);
                    this.listaTipova.push(t);
                });
            })
        })
    }
    preuzmiTezine(host){
        fetch("https://localhost:5001/Kategorija/PreuzmiTezinu")
        .then(p => {

            p.json().then(tezine => {
        
                tezine.forEach(tezina => {
                    
                    var t = new TezinaPripreme(tezina.id, tezina.naziv)
                    t.pupuniSelect(host)
                });
            })
        })
    }

    dodajKategoriju(kat){

        this.kategorije.push(kat);
    }
    dodajTipove(tip){
        this.listaTipova.push(tip);
    }

}

export function ocistiFormu(host){

    host.querySelector(".naziv").value = "";
    host.querySelector(".textareaOpis").value = "";
    host.querySelector(".selectKategorija").value = "";
    let nest = host.querySelector("input[type='radio']:checked");
    if(nest != null)
        nest.checked = false;
    host.querySelector(".textareaSastojci").value = "";
    host.querySelector(".textareaInstrukcija").value = "";
    host.querySelector(".selectTezina").value = "";
    host.querySelector(".vreme").value = "";
    host.querySelector(".slikaInput").value = "";
}