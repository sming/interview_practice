package org.psk.interview.tic_tac_toe;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;

import org.junit.Test;

/**
 * Unit test for simple App.
 */
public class BoardValidatorTest {
    @Test
    public void testGappyBoard() {
        testBoard(new String[] { "XOX", "O O", "XOX" });
    }

    @Test
    public void testEmptyBoard() {
        testBoard(new String[] { "   ", "   ", "   " });
    }

    @Test
    public void testLegalStart() {
        testBoard(new String[] { "  X", "   ", "   " });
    }

    @Test
    public void testIllegalStart() {
        testBadBoard(new String[] { "   ", " O ", "   " });
    }

    @Test
    public void testMultipleWinners() {
        testBadBoard(new String[] { "   ", "OOO", "XXX" });
    }

    @Test
    public void testSingleWinner() {
        testBoard(new String[] { "XOO", "X O", " XO" });
    }

    private void testBoard(String[] board) {
        BoardValidator s = new BoardValidator();
        assertTrue(s.validTicTacToe(board));
    }

    private void testBadBoard(String[] board) {
        BoardValidator s = new BoardValidator();
        assertFalse(s.validTicTacToe(board));
    }
}
