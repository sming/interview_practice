def is_valid(isbn: str) -> bool:
    if not isbn:
        return False

    isbn = isbn.replace("-", "")

    if len(isbn) != 10:
        return False

    check_char: str = isbn[-1]
    try:
        if check_char != "X" and int(check_char) not in range(10):
            return False
    except ValueError:
        return False

    check_int = 10 if check_char == "X" else int(check_char)

    isbn = isbn[:-1]

    try:
        _: int = int(isbn)
    except ValueError:
        return False

    multiplier: int = 10
    sum: int = 0
    for char in isbn:
        digit = int(char)
        sum += digit * multiplier
        multiplier -= 1

    sum += check_int

    return sum % 11 == 0
