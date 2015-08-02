export enum PieceType {
	I,
	J,
	L,
	O,
	S,
	T,
	Z
}

export function parse(shape: string): PieceType {
	switch (shape) {
		case "I":
			return PieceType.I;
		case "J":
			return PieceType.J;
		case "L":
			return PieceType.L;
		case "O":
			return PieceType.O;
		case "S":
			return PieceType.S;
		case "T":
			return PieceType.T;
		case "Z":
			return PieceType.Z;
	}
}