import { PieceType } from "./PieceType";

interface PieceCells {
	[type: string]: number[][][]
}

let cells: PieceCells = {
	"I": 
	[
		[
			[ 0, 0, 0, 0 ],
            [ 1, 1, 1, 1 ],
            [ 0, 0, 0, 0 ],
            [ 0, 0, 0, 0 ]
		], [
			[ 0, 0, 1, 0 ],
			[ 0, 0, 1, 0 ],
			[ 0, 0, 1, 0 ],
			[ 0, 0, 1, 0 ]
		], [
			[ 0, 0, 0, 0 ],
			[ 0, 0, 0, 0 ],
			[ 1, 1, 1, 1 ],
			[ 0, 0, 0, 0 ]
		], [
			[ 0, 1, 0, 0 ],
			[ 0, 1, 0, 0 ],
			[ 0, 1, 0, 0 ],
			[ 0, 1, 0, 0 ] 
		]
	],
	
	"J":
	[
		[
			[ 1, 0, 0 ],
			[ 1, 1, 1 ],
			[ 0, 0, 0 ]
		], [
			[ 0, 1, 1 ],
			[ 0, 1, 0 ],
			[ 0, 1, 0 ]
		], [
			[ 0, 0, 0 ],
			[ 1, 1, 1 ],
			[ 0, 0, 1 ]
		], [
			[ 0, 1, 0 ],
			[ 0, 1, 0 ],
			[ 1, 1, 0 ] 
		]
	],
	
	"L":
	[
		[
			[ 0, 0, 1 ],
			[ 1, 1, 1 ],
			[ 0, 0, 0 ]
		], [
			[ 0, 1, 0 ],
			[ 0, 1, 0 ],
			[ 0, 1, 1 ]
		], [
			[ 1, 1, 1 ],
			[ 1, 0, 0 ],
			[ 0, 0, 0 ]
		], [
			[ 1, 1, 0 ],
			[ 0, 1, 0 ],
			[ 0, 1, 0 ]
		]
	],
	
	"O":
	[
		[
			[ 1, 1 ],
			[ 1, 1 ]
		]
	],
	
	"S":
	[
		[
			[ 0, 1, 1 ],
			[ 1, 1, 0 ],
			[ 0, 0, 0 ]
		], [
			[ 1, 0, 0 ],
			[ 1, 1, 1 ],
			[ 0, 0, 1 ] 
		]
	],
	
	"T":
	[
		[
			[ 0, 1, 0 ],
			[ 1, 1, 1 ],
			[ 0, 0, 0 ]
		], [
			[ 0, 1, 0 ],
			[ 0, 1, 1 ],
			[ 0, 1, 0 ]
		], [
			[ 0, 0, 0 ],
			[ 1, 1, 1 ],
			[ 0, 1, 0 ]
		], [
			[ 0, 1, 0 ],
			[ 1, 1, 0 ],
			[ 0, 1, 0 ]
		]
	],
	
	"Z":
	[
		[
			[ 1, 1, 0 ],
			[ 0, 1, 1 ],
			[ 0, 0, 0 ]
		], [
			[ 0, 0, 1 ],
			[ 0, 1, 1 ],
			[ 0, 1, 0 ]
		]
	]
};

export class Piece {
	public pieceType: PieceType;
	private _rotations: number;
	
	constructor(type: PieceType, rotations:number = 0) {
		this.pieceType = type;
		this.rotations = rotations;
	}
	
	public get maxRotations(): number {
		let type: string = PieceType[this.pieceType];
		
		return cells[type].length;
	}
	
	public set rotations(rotations: number) {
		if (rotations >= this.maxRotations) {
			rotations = rotations % this.maxRotations;
		}
		
		this._rotations = rotations;
	}
	
	public get cells(): number[][] {
		let type: string = PieceType[this.pieceType];
		
		return cells[type][this._rotations];
	}
}