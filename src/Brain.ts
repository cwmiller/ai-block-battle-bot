import { Game } from "./Game";
import { Move } from "./Move";

export class Brain {
	private _game: Game;
	
	constructor(game: Game) {
		this._game = game;
	}
	
	public moves(time: number): Array<Move> {
		return [Move.Drop];
	}
}