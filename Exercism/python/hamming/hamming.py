def distance(strand_a: str, strand_b: str) -> int:
    if len(strand_a) != len(strand_b):
        raise ValueError("Strands A and B must be the same length.")

    distance: int = 0
    for idx, char_a in enumerate(strand_a):
        if char_a != strand_b[idx : idx + 1]:
            distance += 1

    return distance
