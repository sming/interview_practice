"""
Minesweeper class design
"""
import enum
from typing import List


# Using enum class create enumerations
class SquareVisualState(enum.Enum):
    Covered = 1
    Uncovered = 2
    Flagged = 3


class Square:
    _squareState: SquareVisualState

    def __init__(self, board: "Board"):
        self._board = board

    def uncover(self):
        # update SquareVisualState, call _Update, Display
        pass

    def _update(self):
        pass

    def flag(self):
        # update SquareVisualState, call _Update, Display
        pass

    def display(self):
        # print the correct char. Correct char to show is combo of _square (mine/not mine) and _squareCoveredState
        pass


class MineSquare(Square):
    def uncover(self):
        self._boom()

    def _boom(self):
        print(f"BOOM!")
        pass

    def __str__(self):
        return "X"


class NormalSquare(Square):
    # recursively displays neighbor's mine count
    def uncover(self):
        pass

    def __str__(self):
        return "0"


BoardRow = List[Square]
BoardSquares = List[BoardRow]


class Board:
    _squares: BoardSquares
    _n: int

    def __init__(self, n: int, num_mines: int = -1):
        self._n = n

        num_mines_f: float = num_mines
        if num_mines == -1:
            num_mines_f = n * 5 / 100

        # mine_prob: float = num_mines_f / n

        self._squares = [[NormalSquare(self)] * n for i in range(n)]

        # HACK
        self._squares[1][1] = MineSquare(self)
        self._squares[3][1] = MineSquare(self)

    def start(self):
        """
        _ClearBoard // just delete _squares and re-allocate
        _FillBoard
        _LayMines
        _CoverSquares
        """
        self._squares = []
        self._fill_board()

    def _fill_board(self):
        pass

    def __str__(self):
        result: str = ""
        for i in range(self._n):  # rows
            result = result + "\n"
            for j in range(self._n):
                result = result + " " + str(self._squares[i][j])

        return result
