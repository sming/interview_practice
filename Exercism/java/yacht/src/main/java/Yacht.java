import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.stream.Collectors;

class Yacht {
    private final int[] dice;
    private YachtCategory yachtCategory;

    /**
     * 5 dice are rolled and the result can be entered in any of twelve categories
     * The score of a throw of the dice depends on category chosen.
     *
     * Given a list of values for five dice and a category, your solution should
     * return the score of the dice for that category. If the dice do not satisfy
     * the requirements of the category your solution should return 0. You can
     * assume that five values will always be presented, and the value of each will
     * be between one and six inclusively. You should not assume that the dice are
     * ordered.
     *
     * So Ones, Twos... Sixes can all share an implementation. It will need to count
     * the occurrences of a digit in an int and then multiply by that digit. Little
     * & Big straight are easy. So's Yacht.
     *
     *
     * @param dice          5 ints representing the scores
     * @param yachtCategory the elected category
     */

    Yacht(final int[] dice, final YachtCategory yachtCategory) {
        this.dice = dice;
        this.yachtCategory = yachtCategory;
    }

    private static ArrayList<YachtCategory> numberCategories = new ArrayList<YachtCategory>(
            Arrays.asList(YachtCategory.ONES, YachtCategory.TWOS, YachtCategory.THREES, YachtCategory.FOURS,
                    YachtCategory.FIVES, YachtCategory.SIXES));

    int score() {
        int score = 0;
        switch (yachtCategory) {
        case ONES:
        case TWOS:
        case THREES:
        case FOURS:
        case FIVES:
        case SIXES:
            score = getRepeatedDigitScore(yachtCategory);
            break;
        case FULL_HOUSE:
            score = getFullHouseScore();
            break;
        case FOUR_OF_A_KIND:
            score = getFourOfAKind();
            break;
        case LITTLE_STRAIGHT:
            score = getLittleStraight();
            break;
        case BIG_STRAIGHT:
            score = getBigStraight();
            break;
        case CHOICE:
            score = getChoice();
            break;
        case YACHT:
            score = getYacht();
            break;
        default:
            break;
        }

        return score;
    }

    private int getYacht() {
        var differentNumbers = new HashSet<Integer>();
        for (int diceValue : dice) {
            differentNumbers.add(diceValue);
        }

        if (differentNumbers.size() > 1)
            return 0;

        return 50;
    }

    private int getChoice() {
        int sum = 0;
        for (int i : dice) {
            sum += i;
        }
        return sum;
    }

    private int getFullHouseScore() {
        int score = 0;
        var numberCounts = new HashMap<Integer, Integer>();
        for (var yc : numberCategories) {
            int digitCount = countDigitOccurrencesOnDice(yc.ordinal());
            numberCounts.put(digitCount, yc.ordinal());
            score += digitCount * yc.ordinal();
        }

        if (!(numberCounts.containsKey(2) && numberCounts.containsKey(3)))
            score = 0;

        return score;
    }

    private int getFourOfAKind() {
        int score = 0;
        var numberCounts = new HashMap<Integer, Integer>();
        for (var yc : numberCategories) {
            numberCounts.put(yc.ordinal(), countDigitOccurrencesOnDice(yc.ordinal()));
            if (numberCounts.get(yc.ordinal()) >= 4) {
                score = 4 * yc.ordinal();
                break;
            }
        }

        return score;
    }

    private int getLittleStraight() {
        return getStraight(1);
    }

    private int getStraight(int startingNumber) {
        var sorted = sortDice();
        for (int i = 0; i < dice.length; i++) {
            if (sorted.get(i) != i + startingNumber) {
                return 0;
            }
        }

        return 30;
    }

    private int getBigStraight() {
        return getStraight(2);
    }

    private List<Integer> sortDice() {
        return Arrays.stream(dice).sorted().boxed().collect(Collectors.toList());
    }

    private int getRepeatedDigitScore(YachtCategory yc) {
        return countDigitOccurrencesOnDice(yc.ordinal()) * yc.ordinal();
    }

    private int countDigitOccurrencesOnDice(final int digit) {
        int count = 0;
        for (int i : dice) {
            if (i == digit)
                count++;
        }

        return count;
    }
}
