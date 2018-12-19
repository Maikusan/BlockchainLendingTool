export class Tool {

    private _id:string = "";
    get id():string {
        return this._id;
    }
    set id(pId:string) {
        this._id = pId;
    }

    private _ownerId:string = "";
    get ownerId():string {
        return this._ownerId;
    }
    set ownerId(pOwnerId:string) {
        this._ownerId = pOwnerId;
    }

    private _lendingPrice:number = 0;
    get lendingPrice():number {
        return this._lendingPrice;
    }
    set lendingPrice(pLendingPrice :number) {
        this._lendingPrice = pLendingPrice;
    }

    private _depoPrice:number = 0;
    get depoPrice():number {
        return this._depoPrice;
    }
    set depoPrice(pDepoPrice :number) {
        this._depoPrice = pDepoPrice;
    }

    private _availible:boolean = true;
    get availible():boolean {
        return this._availible;
    }
    set availible(pAvailible :boolean) {
        this._availible = pAvailible;
    }

    private _name:string = "Leer";
    get name():string {
        return this._name;
    }
    set name(pname :string) {
        this._name = pname;
    }

    private _descriptipon:string = "";
    get descriptipon():string {
        return this._descriptipon;
    }
    set descriptipon(pdescriptipon :string) {
        this._descriptipon = pdescriptipon;
    }




}
