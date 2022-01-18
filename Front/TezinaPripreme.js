export class TezinaPripreme
{
    constructor(id, naziv){

        this.id = id;
        this.naziv = naziv;
    }

    pupuniSelect(host){
        let op = document.createElement("option");
        op.innerHTML = this.naziv;
        op.value = this.id;
        host.appendChild(op);
        host.value = "";
    }
}