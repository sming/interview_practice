import unittest

from board_builder import Board


class TestMineSweeperBuilder(unittest.TestCase):
    def test_sum(self):
        b = Board(4)
        print(f"Board: {b}.")
        # self.assertEqual(expected, result)


if __name__ == "__main__":
    unittest.main()
