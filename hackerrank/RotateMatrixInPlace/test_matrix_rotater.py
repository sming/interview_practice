import unittest

from matrix_rotater import MatrixRotater


class TestMatrixRotater(unittest.TestCase):
    def test_given_example(self):
        input = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
        r = MatrixRotater(input)
        self.assertEqual([[3, 6, 9], [2, 5, 8], [1, 4, 7]], r.rotate())
