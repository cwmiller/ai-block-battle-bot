import { CellStatus } from "./CellStatus";
import { Piece } from "./Piece";
import { Position } from "./Position";

export class Field {
	private _width: number = 0;
	private _height: number = 0;
	private _cells: CellStatus[][];
	
	constructor(width: number, height: number) {
		this.reset(width, height);
	}
	
	public get height(): number {
		return this._height;
	}
	
	public get width(): number {
		return this._width;
	}
	
	public reset(width: number, height: number) {
		this._width = width;
		this._height = height;
		this._cells = new Array<CellStatus[]>();
        
        for (let y = 0; y < height; y++) {
            this._cells[y] = [];
            
            for (let x = 0; x < width; x++) {
                this._cells[y][x] = CellStatus.Empty;
            }
        }
	}
	
	public setCell(x: number, y: number, status: CellStatus) {
		if (this._cells[y] == undefined) {
			this._cells[y] = [];
		}
		
		this._cells[y][x] = status == CellStatus.Shape ? CellStatus.Empty : status;
	}
	
	public getCell(x: number, y: number): CellStatus {
        if (x < 0 || x >= this._width) {
            return CellStatus.Solid;
        }

        if (y < 0 || y >= this._height) {
            return CellStatus.Solid;
        }

        return this._cells[y][x];
    }
	
	public canFit(piece: Piece, position: Position): boolean {
        let pieceCells = piece.cells;
        let pieceHeight = pieceCells.length;
        let pieceWidth = pieceHeight > 0 ? pieceCells[0].length : 0;

        for (let pieceY = 0; pieceY < pieceHeight; pieceY++) {
            for (let pieceX = 0; pieceX < pieceWidth; pieceX++) {
                let gridY = pieceY + position.y;
                let gridX = pieceX + position.x;

                if ((pieceCells[pieceY][pieceX] == 1) && (this.getCell(gridX, gridY) != CellStatus.Empty)) {
                    return false;
                }
            }
        }

        return true;
    }

	public addPiece(piece: Piece, position: Position) {
        let pieceCells = piece.cells;
        let pieceHeight = pieceCells.length;
        let pieceWidth = pieceHeight > 0 ? pieceCells[0].length : 0;
        
        for (let pieceY = 0; pieceY < pieceHeight; pieceY++) {
            for (let pieceX = 0; pieceX < pieceWidth; pieceX++) {
                let gridY = pieceY + position.y;
                let gridX = pieceX + position.x;

                if (pieceCells[pieceY][pieceX] == 1) {
                    this._cells[gridY][gridX] = CellStatus.Block;
                }
            }
        }
    }
	
	public output() {
        let output = "";
        
        for (let y = 0; y < this._height; y++) {
            for (let x = 0; x < this._width; x++) {
				output = output + this._cells[y][x];
            }
            output = output + "\n";
        }
        
        return output;
    }
}