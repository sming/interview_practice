package org.psk.interview.tic_tac_toe;

import java.util.ArrayList;

class Solution {
    final String badBoardMsg = "board must be 3x3 grid.";
    final ArrayList<String> legalChars = new ArrayList<String>();
    private String[] board = new String[3];
    private String[] rotatedBoard = new String[3];
    private int countWinningRows = 0;
    private String[][] boards;
    private String[] players = new String[] { "O", "X" };

    public Solution() {
        legalChars.add("O");
        legalChars.add("X");
        legalChars.add(" ");
    }

    public boolean validTicTacToe(String[] board) {
        this.board = board;
        boards = new String[][] { board, rotatedBoard };

        if (!validateBoardContents(board))
            return false;
        if (!checkForFirstMove(board))
            return false;
        if (!checkForCorrectNumberOfTurnsEach())
            return false;

        rotateBoard();

        countWinningRows();
        countDiagonalWinningRows();

        // TODO need to take into account winning rows that overlap e.g.
        // 0 X 0
        // X 0 0
        // X X 0 <- this could have been the last turn

        // X X 0
        // X X 0
        // 0 0 0 <- this could have been the last turn
        // but can't think of of a way to elegantly do it :(

        return countWinningRows < 2;
    }

    private void countWinningRows() {
        for (String[] b : boards)
            for (String player : players)
                countWinningRows(b, player);
    }

    private void countDiagonalWinningRows() {
        for (String[] b : boards)
            for (String player : players)
                if (isWinningDiagonalForPlayer(b, player))
                    countWinningRows++;
    }

    private boolean isWinningDiagonalForPlayer(String[] theBoard, String player) {
        boolean isWinningDiagonal = true;
        for (int i = 0; i < theBoard.length; i++)
            if (!theBoard[i].equals(player))
                isWinningDiagonal = false;

        return isWinningDiagonal;
    }

    private boolean checkForCorrectNumberOfTurnsEach() {
        int numPlayerO = countMoves(board, "O");
        int numPlayerX = countMoves(board, "X");

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
        if (countMoves(theBoard, "X") == 0 && countMoves(theBoard, "O") > 0)
            return false;

        return true;
    }

    private int countMoves(String[] theBoard, String player) {
        int count = 0;
        for (String row : theBoard)
            count += row.chars().filter(ch -> ch == player.toCharArray()[0]).count();

        return count;
    }

    private void countWinningRows(String[] theBoard, String player) {
        for (String row : theBoard) {
            if (row.equals(player + player + player))
                countWinningRows++;
        }
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