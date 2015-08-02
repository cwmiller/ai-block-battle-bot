import { Brain } from "./Brain";
import { CellStatus } from "./CellStatus";
import { Game } from "./Game";
import { Move } from "./Move";
import { PieceType, parse as parsePieceType } from "./PieceType";
import { Position } from "./Position";

export class Parser {
	private _game: Game;
	private _brain: Brain;
	
	constructor(game: Game, brain: Brain) {
		this._game = game;
		this._brain = brain;
	}
	
	public parse(line: string): Array<Move> {
		let response: any = null;
		
		line = line.trim();
		
		if (line.length > 0) {
			let segments: Array<string> = line.split(" ");
			
			switch (segments[0]) {
				case "settings":
					if (segments.length < 3) {
						throw new Error("Settings command requires 2 arguments.");
					}
				
					this.handleSettings(segments[1], segments[2]);
					break;
				case "update":
					if (segments.length < 4) {
						throw new Error("Update command requires 3 arguments.");
					}
				
					this.handleUpdate(segments[1], segments[2], segments[3]);
					break;
				case "action":
					if (segments.length < 2) {
						throw new Error("Action command requires 1 argument.");
					}
				
					if (segments[1] == "moves") {
						response = this._brain.moves(parseInt(segments[2]));
					}
					break;
			}
		}
		
		return response;
	}
	
	private handleSettings(setting: string, value: string): void {
		switch (setting) {
            case "timebank":
				this._game.settings.maxTimeBank = parseInt(value);
                break;
            case "time_per_move":
				this._game.settings.timePerMove = parseInt(value);
                break;
            case "player_names":
				let playerNames: string[] = value.split(",");
				playerNames.forEach((name: string) => {
					this._game.addPlayer(name);
				});
                break;
            case "your_bot":
				this._game.playerName = value;
                break;
            case "field_width":
				this._game.settings.fieldWidth = parseInt(value);
                break;
            case "field_height":
				this._game.settings.fieldHeight = parseInt(value);
                break;
        }
	}
	
	private handleUpdate(entity: string, field: string, value: string): void {
		if (entity == "game") {
			switch (field) {
                case "round":
					this._game.round.number = parseInt(value);
                    break;
                case "this_piece_type":
					this._game.round.piece = parsePieceType(value);
                    break;
                case "next_piece_type":
					this._game.round.nextPiece = parsePieceType(value);
                    break;
                case "this_piece_position":
					let points = value.split(",");
					this._game.round.startPosition = new Position(parseInt(points[0]), parseInt(points[1]));
                    break;
            }
		} else {
			switch (field) {
				case "row_points":
					this._game.players[entity].points = parseInt(value);
                    break;
                case "combo":
					this._game.players[entity].combo = parseInt(value);
                    break;
                case "field":
					this._game.players[entity].field.reset(this._game.settings.fieldWidth, this._game.settings.fieldHeight);
				
					let rows = value.replace(/;$/, "").split(";");
					
					for (let y = 0; y < rows.length; y++) {
						let columns= rows[y].split(",");
						
						for (let x = 0; x < columns.length; x++) {
							let cellStatus = <CellStatus>parseInt(columns[x])
							this._game.players[entity].field.setCell(x, y, cellStatus);
						}
					}
                    break;
			}
		}
	}
}