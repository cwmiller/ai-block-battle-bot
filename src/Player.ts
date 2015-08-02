import { Field } from "./Field";

export class Player {
	public points: number;
	public combo: number;
	
	private _field: Field;
	
	constructor() {
		this._field = new Field(0, 0);
	}
	
	public get field(): Field {
		return this._field;
	}
}