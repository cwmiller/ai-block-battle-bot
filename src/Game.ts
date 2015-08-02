import { Round } from "./Round";
import { Player } from "./Player";
import { Settings } from "./Settings";

interface Players {
	[name: string]: Player
}

export class Game {
	public settings: Settings;
	public playerName: string;
	private _players: Players;
	public round: Round;
	
	constructor() {
		this.settings = new Settings();
		this.round = new Round();
		this._players = {};
	}
	
	public get players(): Players {
		return this._players;
	}
	
	public addPlayer(name: string) {
		this._players[name] = new Player();
	}
}