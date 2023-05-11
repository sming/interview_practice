from typing import List


class Solution(object):
    def merge(self, intervals: List[List[int]]) -> List[List[int]]:
        result = []
        num_intervals = len(intervals)

        intervals.sort()

        merged_indices = set()
        for i in range(num_intervals - 1):
            if i in merged_indices:
                continue

            start, end = intervals[i]
            for j in range(i + 1, num_intervals):
                if j in merged_indices:
                    continue

                jth = intervals[j]
                if end >= jth[0]:
                    end = max(end, jth[1])
                    merged_indices.add(j)
                    merged_indices.add(i)
                else:
                    break

            result.append([start, end])

        if len(result) == 0 or intervals[num_intervals - 1][0] > result[len(result) - 1][1]:
            result.append(intervals[num_intervals - 1])

        return result
