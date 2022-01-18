export class Tipovi
{
    constructor(id, naziv){

        this.id = id;
        this.naziv = naziv;
    }
    iscrtajRadioBtn(host){

        let div = document.createElement("div");
        div.className = "divicTip";
        host.appendChild(div);

        let rbt = document.createElement("input");
        rbt.type = "radio";
        rbt.value = this.id;
        rbt.name = "tipovi";
        rbt.className = "radioBtn";
        div.appendChild(rbt);

        let l = document.createElement("label");
        l.innerHTML = this.naziv;
        l.className = "labelaTipovi";
        div.appendChild(l);
    }
}