# Change

Correctly determine the fewest number of coins to be given to a customer such
that the sum of the coins' value would equal the correct amount of change.

## For example

- An input of 15 with [1, 5, 10, 25, 100] should return one nickel (5)
  and one dime (10) or [5, 10]
- An input of 40 with [1, 5, 10, 25, 100] should return one nickel (5)
  and one dime (10) and one quarter (25) or [5, 10, 25]
- An input of 39 with [1, 5, 10, 25, 100] should return [25, 10, 1111]
-
- An input of 39 with [1,2, 5, 10, 25, 100] should return [25, 10, 2, 2]
-

## Edge cases

- Does your algorithm work for any given set of coins?
- Can you ask for negative change?
- Can you ask for a change value smaller than the smallest coin value?

## PSK Notes

- could do brute force but that's lame
- could do brute force but stop when ...
- need to do some kind of explorative approach and backtrack when you blow through the amount perhaps?
    - which sounds like dynamic programming where you record the smallest stack/list of coins found to date

```
total is passed "through"
foreach denom in demons
  if total+denom > change
    next
  else
    total+=denom
```

```
class ShortestChangeCalculator(denom[] allDenoms)
  CoinSet calculate(int changeTotal)

class CoinSet(denom[] allDenoms, denom[] branch, int changeTotal)
  int eval() // adds up branch
  bool test(denom coin) // returns true if coin can be added without blowing change
  CoinSet addCoin(denom toAdd)
  CoinSet removeCoin(denom toRemove)
```

Example 1
change = 3, denoms = 1,2

2
2,2 x
back to 2
2,1 ✔️
back to empty
1
1,1
1,1,1 ✔️
back to 1,1
1,1,2 x
back to 1
1,2 ✔️ (but already found that one)

Example 2
change = 4, denoms = 1, 2, 3

1
...
1,1,1,1 ✔️
1,1,1,2 x
1,1,1,3 x
1,1,2 ✔️
1,1,3 x
1,2,1 ✔️ (Set will detect this and we'll skip it)
1,3 ✔️
2,1
2,1,1 ✔️ (Set)
2,1,2 x
2,1,3 x
2,2 ✔️
2,3 x

-> you stop on that branch when you exceed the change required or nail it i.e. >=
- but how do you avoid all the necessary mirrored work...
- aha. You record how many coins make up *each incremental amount below the change*
    - so you build an amount->(num_coins, coin_set) map


## Setup

Go through the setup instructions for Java to install the necessary
dependencies:

[https://exercism.io/tracks/java/installation](https://exercism.io/tracks/java/installation)

# Running the tests

You can run all the tests for an exercise by entering the following in your
terminal:

```sh
$ gradle test
```

In the test suites all tests but the first have been skipped.

Once you get a test passing, you can enable the next one by removing the
`@Ignore("Remove to run test")` annotation.

## Source

Software Craftsmanship - Coin Change Kata [https://web.archive.org/web/20130115115225/http://craftsmanship.sv.cmu.edu:80/exercises/coin-change-kata](https://web.archive.org/web/20130115115225/http://craftsmanship.sv.cmu.edu:80/exercises/coin-change-kata)

## Submitting Incomplete Solutions
It's possible to submit an incomplete solution so you can see how others have
completed the exercise.
