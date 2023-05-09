from LongestCommonPrefix.longest_common_prefix import Solution
import unittest


class TestLongestCommon(unittest.TestCase):
  def test_longest_common_prefix(self):
    s = Solution()
    words = ['flower', "flow", "flight"]
    self.assertEqual("fl", s.longestCommonPrefix(words))


    self.assertEqual("", s.longestCommonPrefix(["",""]))
    self.assertEqual("d", s.longestCommonPrefix(["d"]))


