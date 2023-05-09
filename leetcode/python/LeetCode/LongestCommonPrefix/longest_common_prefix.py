import typing


class Solution:
  def __init__(self):
    pass

  def isLowerAlpha(self, text: str) -> bool:
    return text.isalpha() and text.islower()

  def longestCommonPrefix(self, strs: typing.List[str]) -> str:
    longest:str = None

    if len(strs) == 1:
      return strs[0] if self.isLowerAlpha(strs[0]) else ""
    elif len(strs) == 0:
      return ""

    prev_str = ""
    for s in strs:
      if not self.isLowerAlpha(s):
        return ""

      if prev_str == "":
        prev_str = s
        continue

      min_len = min(len(prev_str), len(s))
      commonCount = 0
      for i in range(min_len):
        s_char = s[i]
        prev_chaar = prev_str[i]

        if s_char == prev_chaar:
          commonCount += 1
        else:
          break

      prev_str = s

      if longest == None:
        longest = s[0:commonCount]
      else:
        longest = min(s[0:commonCount], longest)

    return longest if longest != None else ""