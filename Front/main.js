import { Kategorija } from "./Kategorije.js";
import { Recepti } from "./Recepti.js";

var recept = new Recepti();


fetch("https://localhost:5001/Kategorija/PreuzmiKategorije")
.then(p => {

    p.json().then(kategorije => {

        kategorije.forEach(kategorija => {
            
            var k = new Kategorija(kategorija.id, kategorija.naziv);
            recept.dodajKategoriju(k);
        });
        
        recept.iscrtaj(document.body);
    })
})
