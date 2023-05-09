import unittest

from subdomain_visit_count import Solution


class TestSubdomainCounts(unittest.TestCase):
    def test_basic(self):
        input = ["9001 discuss.leetcode.com"]
        output = ["9001 discuss.leetcode.com", "9001 leetcode.com", "9001 com"]

        s = Solution()
        self.assertEqual(output, s.subdomainVisits(input))

    def test_medium(self):
        input = [
            "900 google.mail.com",
            "50 yahoo.com",
            "1 intel.mail.com",
            "5 wiki.org",
        ]

        output = [
            "901 mail.com",
            "50 yahoo.com",
            "900 google.mail.com",
            "5 wiki.org",
            "5 org",
            "1 intel.mail.com",
            "951 com",
        ]

        s = Solution()
        self.assertEqual(output.sort(), s.subdomainVisits(input).sort())


if __name__ == "__main__":
    unittest.main()
