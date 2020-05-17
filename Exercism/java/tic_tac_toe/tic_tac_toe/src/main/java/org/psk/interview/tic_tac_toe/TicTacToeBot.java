package org.psk.interview.tic_tac_toe;

import org.psk.interview.tic_tac_toe.Board.Square;

public class TicTacToeBot {
	Board board;
	char symbol;
	/*
	 * function findBestMove(board):
		    bestMove = NULL
		    for each move in board :
		        if current move is better than bestMove
		            bestMove = current move
		    return bestMove
		    
		
    */
	public Square findBestMove() {
		return null;
	}

	/**
	 * - if num empty spaces == 0 choose that
	 * - if move means you win, choose that
	 * - if move prevents you losing, choose that
	 * - 
	 * @return
	 */
	public int evaluateMove(Square sq) {
		return 0;
	}
		

}
