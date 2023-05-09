from typing import List


"""
Given a square matrix, turn it by 90 degrees in anti-clockwise direction without using any extra space.
Input:
Matrix:
 1  2  3
 4  5  6
 7  8  9
Output:
 3  6  9
 2  5  8
 1  4  7
"""


class MatrixRotater:
    def __init__(self, input: List[int]):
        self.input = input
        self.len = len(input)
        self.output: Array[int][int] = []

    def rotate(self):
        for i in list(reversed(list(range(self.len)))):
            self.output.append([])
            for row in self.input:
                self.output[self.len - i - 1].append(row[i])

        return self.output
