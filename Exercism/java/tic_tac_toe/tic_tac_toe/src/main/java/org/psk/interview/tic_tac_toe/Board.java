package org.psk.interview.tic_tac_toe;

public class Board {
	public class Player {
		String name;
		char symbol;
	}
	
	public class Square {
		public int row;
		public int col;
		public int val;	// 0 or 1 (X)
		public Square(int row, int col, int val) {
			super();
			this.row = row;
			this.col = col;
			this.val = val;
		}
		
	}
	
	int[][] board;
	boolean xIsNext = false;
	
	public Board() {
		super();
		board =  new int[3][];
		for (int[] row : board) {
			row = new int[3];
		}
	}
	
	
}
