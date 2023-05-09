import unittest

from board_updater_v2 import Board


class TestMineSweeperUpdaterV2(unittest.TestCase):
    def test_sum(self):
        # self.assertEqual(sum([1, 2, 3]), 6, "Should be 6")
        example = [
            ["E", "E", "E", "E", "E"],
            ["E", "E", "M", "E", "E"],
            ["E", "E", "E", "E", "E"],
            ["E", "E", "E", "E", "E"],
        ]
        coord = [3, 0]

        b = Board(example)
        result = b.click(coord)

        expected = [
            ["B", "1", "E", "1", "B"],
            ["B", "1", "M", "1", "B"],
            ["B", "1", "1", "1", "B"],
            ["B", "B", "B", "B", "B"],
        ]
        self.assertEqual(expected, result)


if __name__ == "__main__":
    unittest.main()
