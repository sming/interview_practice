package org.psk.interview.tic_tac_toe;

public class MoveCounter {
    public int countWinningRows = 0;
    public String[][] boards;
    private String[] players = new String[] { "O", "X" };

    public MoveCounter(String[][] boards) {
		super();
		this.boards = boards;
	}


	public int countMoves(String[] theBoard, String player) {
        int count = 0;
        for (String row : theBoard)
            count += row.chars().filter(ch -> ch == player.toCharArray()[0]).count();

        return count;
    }

    public void countWinningHorzRows(String[] theBoard, String player) {
        for (String row : theBoard) {
            if (row.equals(player + player + player))
                countWinningRows++;
        }
    }

    public void countWinningRows() {
        for (String[] b : boards)
            for (String player : players)
                countWinningHorzRows(b, player);
    }

    public void countDiagonalWinningRows() {
        for (String[] b : boards)
            for (String player : players)
                if (isWinningDiagonalForPlayer(b, player))
                    countWinningRows++;
    }

    public boolean isWinningDiagonalForPlayer(String[] theBoard, String player) {
        boolean isWinningDiagonal = true;
        for (int i = 0; i < theBoard.length; i++)
            if (!theBoard[i].equals(player))
                isWinningDiagonal = false;

        return isWinningDiagonal;
    }

}
