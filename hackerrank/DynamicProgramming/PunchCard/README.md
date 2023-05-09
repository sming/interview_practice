# Punch Card Dynamic Programming

From [Demystifying Dynamic Programming](https://www.freecodecamp.org/news/demystifying-dynamic-programming-3efafb8d4296/)

Pretend you’re back in the 1950s working on an IBM-650 computer. You know what this means — punchcards!

Your job is to man, or woman, the IBM-650 for a day.

- You’re given a natural number **n** punchcards to run.
- Each punchcard i must be run at some predetermined start time **s_i**
- and stop running at some predetermined finish time **f_i**.
- Only one punchcard can run on the IBM-650 at once.
- Each punchcard also has an associated value **v_i** based on how important it is to your company.

```shell
n == number of punchcards needing running
i == a punchcard
s_i == start time
f_i == end time
v_i = value (to company)
```

Problem: As the person in charge of the IBM-650, you must determine the optimal schedule of punchcards that maximizes the total value of all punchcards run.

Python Fibonacci memoization solution

```Python
def fibonacciVal(n):
    memo = [0] * (n+1)
    memo[0], memo[1] = 0, 1
    for i in range(2, n+1):
        memo[i] = memo[i-1] + memo[i-2]

    return memo[n]
```
