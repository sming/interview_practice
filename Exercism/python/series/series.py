from typing import List


"""
Solution to series python exercise.
"""


def slices(series, length):
    series_len: int = len(series)

    if series_len == 0:
        raise ValueError("The series must have at least one character.")

    if length < 1:
        raise ValueError("The length param must be a positive integer.")

    if length > series_len:
        raise ValueError(
            "The supplied length parameter is bigger than the length of the series."
        )

    # so we basically maintain 2 indexes into the string and increment them
    # until the forward idx hits the end of the string.
    results: List[str] = list()
    for idx in range(series_len):
        if idx + length > series_len:
            break

        results.append(series[idx : idx + length])

    return results
