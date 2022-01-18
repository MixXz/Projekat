import { Kategorija } from "./Kategorije.js";
import { ocistiFormu } from "./Recepti.js";

export class Receptic
{
    constructor(id, naziv, opis, kategorija, sastojci, instrukcija, tezina, vreme, tip, slika){
        
        this.id = id;
        this.naziv = naziv;
        this.opis = opis;
        this.kategorija = kategorija;
        this.sastojci = sastojci;
        this.instrukcija = instrukcija;
        this.tezina = tezina;
        this.vreme = vreme;
        this.tip = tip;
        this.slika = slika;

        this.container = null;
        
        this.div = null
    }

    iscrtajRecept(host)
    {

        this.container = document.createElement("div");
        this.container.className = "images";
        host.appendChild(this.container);

        let opisSlika = document.createElement("div")
        opisSlika.className = "opisSlika";
        this.container.appendChild(opisSlika);

        let imageContainer = document.createElement("img");
        imageContainer.src = "/img/" + this.slika;
        imageContainer.className = "item-image-size";
        imageContainer.classList.add("imageContainer" + this.id);
        opisSlika.appendChild(imageContainer);

        let opis = document.createElement("div");
        opis.className = "opis";
        opisSlika.appendChild(opis);

        let nazivContainer = document.createElement("b");
        nazivContainer.innerHTML = "Naziv: " + this.naziv;
        nazivContainer.className = "labelaRecept";
        opis.appendChild(nazivContainer);

        let opisContainer = document.createElement("b");
        opisContainer.innerHTML = "Opis: " + this.opis;
        opisContainer.className = "labelaRecept";
        opis.appendChild(opisContainer);

        let tezinaContainer = document.createElement("b");
        tezinaContainer.innerHTML = "Težina pripreme: " + this.tezina.tezina;
        tezinaContainer.className = "labelaRecept";
        opis.appendChild(tezinaContainer);

        let vremePripreme = document.createElement("b");
        vremePripreme.innerHTML = "Vreme pripreme: " + this.vreme;
        vremePripreme.className = "labelaRecept";
        opis.appendChild(vremePripreme);

        let tipJela = document.createElement("b");
        tipJela.innerHTML = "Tip jela: " + this.tip.tipJela;
        tipJela.className = "labelaRecept";
        opis.appendChild(tipJela);

        let ostalo = document.createElement("div");
        ostalo.className = "ostalo";
        this.container.appendChild(ostalo);

        let containerSast = document.createElement("div");
        containerSast.className = "containerSast";
        ostalo.appendChild(containerSast);

        let labela = document.createElement("label")
        labela.innerHTML = "Sastojci:";
        labela.className = "labelaRecept";
        containerSast.appendChild(labela);

        let boxSastojci = document.createElement("div");
        boxSastojci.className = "zaSastojkeBox";
        containerSast.appendChild(boxSastojci);

        let sastojciContainer = document.createElement("b");
        sastojciContainer.className = "prev";
        sastojciContainer.innerHTML = this.sastojci;
        boxSastojci.appendChild(sastojciContainer);

        let containerInstr = document.createElement("div");
        containerInstr.className = "containerInstr";
        ostalo.appendChild(containerInstr);

        labela = document.createElement("label")
        labela.innerHTML = "Instrukcije:";
        labela.className = "labelaRecept";
        containerInstr.appendChild(labela);

        let boxInstr = document.createElement("div");
        boxInstr.className = "zaSastojkeBox";
        containerInstr.appendChild(boxInstr);

        let instrContainer = document.createElement("b");
        instrContainer.className = "prev";
        instrContainer.innerHTML = this.instrukcija;
        boxInstr.appendChild(instrContainer);

        let buttonBox = document.createElement("div");
        buttonBox.className = "ButtonBoxRecept";
        opisSlika.appendChild(buttonBox);

        let btnIzbrisi = document.createElement("button");
        btnIzbrisi.innerHTML = "Izbriši";
        buttonBox.appendChild(btnIzbrisi);
        btnIzbrisi.onclick = (ev) =>{

            this.izbrisiRecept(this.id);
        }

        let btnIzmeni = document.createElement("button");
        btnIzmeni.innerHTML = "Izmeni";
        buttonBox.appendChild(btnIzmeni);
        btnIzmeni.onclick = (ev) =>{

            let p = this.container.parentNode;
            p = p.parentNode;
            p = p.querySelector(".forma");
            p = p.querySelector(".buttonBox");
            let b = p.querySelector(".btnSacuvaj");
            if(b != null)
                p.removeChild(b);

            this.izmeniRecept(this.id);
        }


    }

    izbrisiRecept(receptID){

        
        if (confirm("Da li ste sigurni da zelite da obrisete ovaj recept?"))
        {
            fetch("https://localhost:5001/Recept/IzbrisatiRecept/" + receptID,
            {
                method: "DELETE"
            })

            var parent = this.container.parentNode;
            parent.removeChild(this.container);

            console.log("Uspesno obrisan recept sa id-em: " + receptID);
        }
        else
        {
            console.log("Recept nije obrisan");
        }

    }

    izmeniRecept(receptID){
        let parent = this.container.parentNode;
        let forma = parent.parentNode;
        let buttonBoxx = forma.querySelector(".buttonBox");
        let poljeRecept = forma.querySelector(".zaRecepte");
        forma.querySelector(".btnDodaj").style.visibility="hidden";
        forma.querySelector(".forma").style.visibility="visible";
        
        this.popuniFormu(forma, this);

        let btnSacuvaj = document.createElement("button");
        btnSacuvaj.className = "btnSacuvaj";
        btnSacuvaj.classList.add("button");
        btnSacuvaj.innerHTML = "Sačuvaj izmene";
        buttonBoxx.appendChild(btnSacuvaj);

        btnSacuvaj.onclick = (ev) =>{

            let naziv = forma.querySelector(".naziv").value;
            let opis = forma.querySelector(".textareaOpis").value;
            let kategorija = forma.querySelector(".selectKategorija").value;
            let tip = forma.querySelector("input[type='radio']:checked").value;
            let sastojci = forma.querySelector(".textareaSastojci").value;
            let instrukcija = forma.querySelector(".textareaInstrukcija").value;
            let tezina = forma.querySelector(".selectTezina").value;
            let vreme = forma.querySelector(".vreme").value;
            let slikica = forma.querySelector(".slikaInput").value;

            if(naziv == ""){
                alert("Polje Naziv ne sme ostati prazno!");
                return;
            }
            if(sastojci == ""){
                alert("Polje Sastojci ne sme ostati prazno!");
                return;
            }
            if(sastojci.length > 1000){
                alert("Sastojci ne smeju biti duzi od 1000 karaktera!");
                return;
            }
            if(instrukcija == ""){
                alert("Polje Instrukcija ne sme ostati prazno!");
                return;
            }
            if(instrukcija.length > 1000){
                alert("Instrukcija ne sme biti duza od 1000 karaktera!");
                return;
            }
            if(vreme == ""){
                alert("Unesite vreme potrebno za pripremu jela!");
                return;
            }
            if(slikica == ""){
                alert("Unesite sliku jela!");
                return;
            }

            if (confirm("Da li ste sigurni da želite da sačuvate izmene?"))
            {
                fetch("https://localhost:5001/Recept/PromenitiRecept/" + receptID + "/" + naziv + "/" + opis + "/" + kategorija + "/" + sastojci + "/" + instrukcija + "/" + tezina + "/" + vreme + "/" + slikica + "/" + tip,
                {
                    method:"PUT"
                }).then(r => {
        
                if(r.ok){

                    ocistiFormu(forma);
                    
                    buttonBoxx.removeChild(btnSacuvaj);

                    var kat = new Kategorija(this.kategorija.id, this.kategorija.naziv)
                    kat.ucitajRecepte(this.kategorija.id, poljeRecept);

                    forma.querySelector(".forma").style.visibility="hidden";
                    console.log("Izmena uspesna");
                    
                }
                else{
                    alert("Izmena recepta nije uspela!");
                }
                })
             }
             else{
                 console.log("Izmena otkazana");
             }
        }
    }

    popuniFormu(forma, el){

        forma.querySelector(".naziv").value = el.naziv;
        forma.querySelector(".textareaOpis").value = el.opis;
        forma.querySelector(".selectKategorija").value = el.kategorija.id;

        let nest = forma.querySelectorAll("input[name='tipovi']");
        nest.forEach(p =>{
            if(p.value == el.tip.id){
                p.checked = true;
            }
        })
        forma.querySelector(".textareaSastojci").value = el.sastojci;
        forma.querySelector(".textareaInstrukcija").value = el.instrukcija;
        forma.querySelector(".selectTezina").value = el.tezina.id;
        forma.querySelector(".vreme").value = el.vreme;
        forma.querySelector(".slikaInput").value = el.slika;
    }

}