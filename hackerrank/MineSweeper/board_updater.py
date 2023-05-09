from collections import defaultdict
from enum import Enum
from queue import Queue
from typing import List


class Coord:
    def __init__(self, coords: List[int], board: "Board"):
        self.x = coords[0]
        self.y = coords[1]
        self.board = board

    def get_val(self) -> str:
        return self.board.board[self.x][self.y]

    def set_val(self, val: str):
        self.board.board[self.x][self.y] = val

    def is_unrevealed(self) -> bool:
        val: str = self.get_val()
        return val == SqType.MINE_U.value or val == SqType.EMPTY_U.value


class SqType(Enum):
    MINE_U = "M"  # _U ~ unrevealed
    EMPTY_U = "E"  # _U ~ unrevealed
    BLANK = "B"  # no surrounding mines
    BOOM = "X"  # stepped on a boomer


class Board:
    board: List[List[str]]

    def __init__(self, board: List[List[str]]):
        self.board = board
        self.i_len = len(board)
        self.j_len = len(board[0])

    # Let's try a BFS. So, what's python's queue class
    def click(self, coords: Coord) -> List[List[str]]:
        q = Queue()
        q.put(coords)

        while q.qsize() > 0:
            square: Coord = q.get()
            sq_val: str = square.get_val()

            if not square.is_unrevealed():
                continue

            if sq_val == SqType.MINE_U.value:
                square.set_val(SqType.BOOM.value)
                return self.board

            # So we need to go 1 NSEW, or -1 x -1, excluding ourselves
            mine_count: int = 0
            for i in range(-1, 2):
                for j in range(-1, 2):
                    if i == 0 and j == 0:
                        continue

                    new_i = square.x + i
                    new_j = square.y + j
                    if (
                        new_i < 0
                        or new_i >= self.i_len
                        or new_j < 0
                        or new_j >= self.j_len
                    ):
                        continue

                    coord = Coord([new_i, new_j], self)
                    if coord.get_val() == SqType.MINE_U.value:
                        mine_count += 1

            if mine_count > 0:
                square.set_val(str(mine_count))
            else:
                square.set_val(SqType.BLANK.value)

                # OOH. Looks like we found a square with no neighboring mines,
                # we now recurse.
                for i in range(-1, 2):
                    for j in range(-1, 2):
                        if i == 0 and j == 0:
                            continue

                        new_i = square.x + i
                        new_j = square.y + j
                        if (
                            new_i < 0
                            or new_i >= self.i_len
                            or new_j < 0
                            or new_j >= self.j_len
                        ):
                            continue

                        coord = Coord([new_i, new_j], self)
                        if coord.is_unrevealed():
                            q.put(coord)

        return self.board


class Solution:
    def updateBoard(self, board: List[List[str]], click: List[int]) -> List[List[str]]:
        board = Board(board)
        coord = Coord(click, board)
        clickedboard = board.click(coord)
        return clickedboard
