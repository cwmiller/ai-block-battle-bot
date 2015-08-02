// __main__
import { Brain } from "./Brain";
import { Game } from "./Game";
import { Move } from "./Move";
import { Parser } from "./Parser";

let game = new Game();
let brain = new Brain(game);
let parser = new Parser(game, brain);

process.stdin.on('readable', () => {
	var input = process.stdin.read();

	if (input !== null) {
		input.toString().split("\n").forEach((command) => {
			if (command.trim().length > 0) {	
				let response = parser.parse(command);
				
				if (response != null) {
					console.log(response.map((move, idx) => {
						let str = Move[move];
						return str.charAt(0).toLowerCase() + str.slice(1);
					}).join(","));
				}
			}
		});
	}
});