import threading


class BankAccount:
    def __init__(self):
        self._open: bool = False
        self._balance: int = 0
        self._key_lock = threading.Lock()

    def get_balance(self):
        with self._key_lock:
            if not self._open:
                raise ValueError("Can't check balance of closed account")
            return self._balance

    def open(self):
        with self._key_lock:
            if self._open:
                raise ValueError("Already open")
            self._open = True
            self._balance = 0

    def deposit(self, amount: int):
        with self._key_lock:
            if not self._open:
                raise ValueError("Can't deposit to closed account")
            if amount < 1:
                raise ValueError("Deposits have to be positive")
            self._balance += amount

    def withdraw(self, amount: int):
        with self._key_lock:
            if not self._open:
                raise ValueError("Can't withdraw from closed account")
            if amount < 1:
                raise ValueError("Withdrawals have to be positive")
            if amount > self._balance:
                raise ValueError("Can't withdraw more than you have")
            self._balance -= amount

    def close(self):
        with self._key_lock:
            if not self._open:
                raise ValueError("Can't close a closed account")
            self._open = False
