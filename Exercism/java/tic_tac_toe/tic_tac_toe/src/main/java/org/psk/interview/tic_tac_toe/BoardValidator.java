package org.psk.interview.tic_tac_toe;

import java.util.ArrayList;

class BoardValidator {
    final String badBoardMsg = "board must be 3x3 grid.";
    final ArrayList<String> legalChars = new ArrayList<String>();
    private String[] board = new String[3];
    private String[] rotatedBoard = new String[3];
    /**
     * Boards because we have a rotated + normal board. 
     */
    private String[][] boards;
	private MoveCounter moveCounter;

    public BoardValidator() {
        legalChars.add("O");
        legalChars.add("X");
        legalChars.add(" ");
    }

    public boolean validTicTacToe(String[] board) {
        this.board = board;
        boards = new String[][] { board, rotatedBoard };
        
        this.moveCounter = new MoveCounter(boards);
        if (!validateBoardContents(board))
            return false;
        if (!checkForFirstMove(board))
            return false;
        if (!checkForCorrectNumberOfTurnsEach())
            return false;

        rotateBoard();

        moveCounter.countWinningRows();
        moveCounter.countDiagonalWinningRows();

        // TODO need to take into account winning rows that overlap e.g.
        // 0 X 0
        // X 0 0
        // X X 0 <- this could have been the last turn

        // X X 0
        // X X 0
        // 0 0 0 <- this could have been the last turn
        // but can't think of of a way to elegantly do it :(

        return moveCounter.countWinningRows < 2;
    }

    private boolean checkForCorrectNumberOfTurnsEach() {
        int numPlayerO = moveCounter.countMoves(board, "O");
        int numPlayerX = moveCounter.countMoves(board, "X");

        return Math.abs(numPlayerO - numPlayerX) < 2;
    }

    private void rotateBoard() {
        for (int i = 0; i < board.length; i++) {
            rotatedBoard[i] = "";
            for (String string : board) {
                rotatedBoard[i] = rotatedBoard[i] + string.charAt(i);
            }
        }
    }

    private boolean checkForFirstMove(String[] theBoard) {
        if (moveCounter.countMoves(theBoard, "X") == 0 && moveCounter.countMoves(theBoard, "O") > 0)
            return false;

        return true;
    }

    private boolean validateBoardContents(String[] board) {
        if (board == null || (board.length != 3))
            return false;

        for (String row : board) {
            if (row.length() != 3)
                return false;

            for (char c : row.toCharArray()) {
                String strC = Character.toString(c);
                if (!legalChars.contains(strC))
                    return false;
            }
        }

        return true;
    }
}