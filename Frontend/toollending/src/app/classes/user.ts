export class User {
    private _vorname:string = "";
    get vorname():string {
        return this._vorname;
    }
    set vorname(pvorname:string) {
        this._vorname = pvorname;
    }

    private _nachname:string = "";
    get nachname():string {
        return this._nachname;
    }
    set nachname(pnachname:string) {
        this._nachname = pnachname;
    }
}
