#
# @lc app=leetcode id=85 lang=python3
#
# [85] Maximal Rectangle
#
# https://leetcode.com/problems/maximal-rectangle/description/
#
# algorithms
# Hard (36.45%)
# Total Accepted:    167.6K
# Total Submissions: 455.5K
#
# Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle
# containing only 1's and return its area.
#
# Example:
#
#
# Input:
# [
# ⁠ ["1","0","1","0","0"],
# ⁠ ["1","0","1","1","1"],
# ⁠ ["1","1","1","1","1"],
# ⁠ ["1","0","0","1","0"]
# ]
# Output: 6
#
# ————————————
""" PSK
0 == 0
1 == 1

01
01 == 2

01
10 == 1

01
11 == 2 (2 of them)

11
11 == 4

111
000 == 3

111 == 3
001

111 == 4
011

111 == 6
111

1) must be a rectangle
    - for each x,y,
        for each of NSEW
            go as far as you can in that direction, stopping if you see a 0
(assume starting top left - 0,0 and it's all 1's)
        then for each combo of lengths of N+E,N+W and S+E,S+W (in this case, S+E)
1??     111
??? =>  1??
???     1??

————————————
1) must be a rectangle
    find all the 1's coords. foreach coord, walk as far as you can EW as long as you're seeing 1's
        foreach E, W
            see if you can
1100
0110 == 2
0011
————————————
1) must be a rectangle
    what is a rectangle? well, it's 4 coords with the property:
    KEY: TL = Top Left, TR = Top Right, BL = Bottom LEft, BR = Bottom right

    TL.x = BL.x
    TL.y = TR.y [TR.y = TL.y]
    TR.x = BR.x
    BR.y = BL.y

    TL       TR

    BL       BR

    So, we have TL.
    TR.x = TL.x + W[idth]
    TR.y = TL.y

    BR.x = TL.x + W
    BR.y = TL.y + H[eight]

    BL.x = TL.x
    BL.y = TL.y + H

    so if we always check that our "shape" is rectangular, we register that area.
        how do we get the extents of an area? we could store ...

 ————————————
1) must be a rectangle
    just walk and get max rectangular area?
01000
11110
01100

11111
11111   ^
11111   |
·1111 ->

0100
0101
0101
1111

    assume BL start.
    walk as far as you can east, then as far as you can north.
        then for each step North, down to 1:
            a) then check that the contained coords are 1's
                b) if so, calc area and store if max
    then go one back (west), then go as far as you can north
    ==> horrible performance
————————————
0000
0111 == 1, 11, 11, 11, 11, 11, 11, 11, 111, 111, 11, 11, 111
0111    1                                        11  11  111
0000
    can you find all 1's and start combining them into rectangles?
so for starting BL:
0000
1110
1100
    foreach 1
        find all 1 neighbors
????
1???
11??
        then find all their neighbors, etc
        keep a list of coords seen?
        keep x,y in dictionary? ah fuck it.
????
111?
11??






2) must only contain 1's.


PSK """
from typing import List


class Solution:
    def maximalRectangle(self, matrix: List[List[str]]) -> int:
        pass
