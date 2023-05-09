import unittest

from maximal_rectangle import Solution


class TestMaximalRectangle(unittest.TestCase):
    def setup(self):
        pass

    def test_basic(self):
        input = [
            ["1", "0", "1", "0", "0"],
            ["1", "0", "1", "1", "1"],
            ["1", "1", "1", "1", "1"],
            ["1", "0", "0", "1", "0"],
        ]

        s = Solution()
        self.assertEqual(6, s.maximalRectangle(input))


if __name__ == "__main__":
    unittest.main()
