import { PieceType } from "./PieceType";
import { Position } from "./Position";

export class Round {
	public number: number;
	public piece: PieceType;
	public nextPiece: PieceType;
	public startPosition: Position; 
}