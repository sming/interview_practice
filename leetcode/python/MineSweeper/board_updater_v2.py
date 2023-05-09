from collections import defaultdict
from enum import Enum
from queue import Queue
from typing import List


class Board:
    board: List[List[str]]

    def __init__(self, board: List[List[str]]):
        self.board = board
        self.i_len = len(board)
        self.j_len = len(board[0])

    # Let's try a BFS.
    def click(self, coords: List[int]) -> List[List[str]]:
        q = Queue()
        q.put(coords)

        while q.qsize() > 0:
            square: List[int] = q.get()
            x, y = square[0], square[1]
            sq_val: str = self.board[x][y]

            if sq_val != "M" and sq_val != "E":
                continue

            if sq_val == "M":
                self.board[x][y] = "X"
                return self.board

            # So we need to go 1 NSEW, or -1 x -1, excluding ourselves
            mine_count: int = 0
            for i in range(-1, 2):
                for j in range(-1, 2):
                    if i == 0 and j == 0:
                        continue

                    new_i = x + i
                    new_j = y + j
                    if (
                        new_i < 0
                        or new_i >= self.i_len
                        or new_j < 0
                        or new_j >= self.j_len
                    ):
                        continue

                    if self.board[new_i][new_j] == "M":
                        mine_count += 1

            if mine_count > 0:
                self.board[x][y] = str(mine_count)
            else:
                self.board[x][y] = "B"

                # OOH. Looks like we found a square with no neighboring mines,
                # we now recurse.
                for i in range(-1, 2):
                    for j in range(-1, 2):
                        if i == 0 and j == 0:
                            continue

                        new_i = x + i
                        new_j = y + j
                        if (
                            new_i < 0
                            or new_i >= self.i_len
                            or new_j < 0
                            or new_j >= self.j_len
                        ):
                            continue

                        if (
                            self.board[new_i][new_j] == "M"
                            or self.board[new_i][new_j] == "E"
                        ):
                            q.put([new_i, new_j])

        return self.board


class Solution_V2:
    def updateBoard(self, board: List[List[str]], click: List[int]) -> List[List[str]]:
        board = Board(board)
        clickedboard = board.click(click)
        return clickedboard.board
