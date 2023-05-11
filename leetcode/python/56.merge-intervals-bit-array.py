from typing import List


class Solution(object):
    def merge(self, intervals: List[List[int]]) -> List[List[int]]:
        """Attempt to "flaten" the intervals into a bit array. Doesn't *quite* work and
        I'm not convinced that the extra effort is worth it as I don't think it'll be
        much faster.
        """
        intervals.sort()

        max_end = max([x[1] for x in intervals])

        bit_array = [0] * (max_end + 1)

        print(f"PSK: len bit_array: {len(bit_array)}")
        for _, val in enumerate(intervals):
            start, end = val[0], val[1]
            for i in range(start, end):
                bit_array[i] = 1

            if bit_array[end] == 0:
                bit_array[end] = 2

            # H4X0R
            if end == 0:
                bit_array[0] = 1

        result = []
        first_bit = bit_array[0]
        start = first_bit if first_bit == 1 else -1
        for i, val in enumerate(bit_array):
            if val == 1:
                if start == -1:
                    start = i
            else:
                if start != -1:
                    result.append([start, i])
                    start = -1

        return result
