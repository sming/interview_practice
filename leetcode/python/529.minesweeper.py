import copy
import queue
from typing import List


class Solution(object):
    """
    'M' represents an unrevealed mine,
    'E' represents an unrevealed empty square,
    'B' represents a revealed blank square that has no adjacent mines (i.e., above, below, left, right, and all 4 diagonals),
    digit ('1' to '8') represents how many mines are adjacent to this revealed square, and
    'X' represents a revealed mine.

    If a mine 'M' is revealed, then the game is over. You should change it to 'X'.
    If an empty square 'E' with no adjacent mines is revealed, then change it to a revealed blank 'B' and all of its adjacent unrevealed squares should be revealed recursively.
    If an empty square 'E' with at least one adjacent mine is revealed, then change it to a digit ('1' to '8') representing the number of adjacent mines.
    Return the board when no more squares will be revealed.

    NOTE this fails the first test by 1 cell ATM.
    """

    def __init__(self):
        self.q = queue.Queue()

    def updateBoard(self, board: List[List[str]], click: List[int]) -> List[List[str]]:
        self.board = board
        self.q.put(click)
        self.set = set()
        self.set.add(click)

        self.updateBoardImpl()

        return self.board

    def enqueue(self, cell: List[int]) -> bool:
        val = self.board[cell[0]][cell[1]]
        if val != "M" and val != "E":
            print(f"Not recursing into {cell[0]},{cell[1]} as is already revealed")
            return False

        if not cell in self.set:
            self.q.put(cell)
            self.set.add(cell)
        else:
            print(f"{cell[0]},{cell[1]} is already enqueued")

        return True

    def updateBoardImpl(self):
        """
        So the algorithm is as follows:

        reveal the square S at x and y
        if S == M
          result[x][y] = 'X'
          coord_queue.reset() # clear the queue
          return result

        TODO
        """
        if self.q.empty():
            print("queue is empty")
            return

        coord = self.q.get()

        self.enqueue(coord)

        val = self.board[coord[0]][coord[1]]
        if val == "M":
            print("found mine, exiting")
            self.board[coord[0]][coord[1]] = "X"
            self.q.reset()
            return

        self.update_coord(coord)
        self.updateBoardImpl()

    def update_coord(self, coord: List[int]):
        print(f"updating coord {coord[0]},{coord[1]}")
        num_mines = 0
        for i in range(-1, 2):
            for j in range(-1, 2):
                if i == 0 and j == 0:
                    continue

                if (
                    coord[0] + i < 0
                    or coord[0] + i >= len(self.board)
                    or coord[1] + j < 0
                    or coord[1] + j >= len(self.board[0])
                ):
                    print(f"OOB: {coord[0] + i},{coord[1] + j}")
                    continue

                val = self.board[coord[0] + i][coord[1] + j]
                if val == "M":
                    print("found a mine")
                    num_mines += 1
                else:
                    print(f"enqueuing {coord[0] + i},{coord[1] + j}")
                    self.enqueue((coord[0] + i, coord[1] + j))

        if num_mines == 0:
            self.board[coord[0]][coord[1]] = "B"
            print(f"Found blank at {coord[0]},{coord[1]}")
        else:
            print(f"Found neighboring mine(s) at {coord[0]},{coord[1]}")

            self.board[coord[0]][coord[1]] = str(num_mines)
