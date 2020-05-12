import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class ChangeCalculator {
    private ArrayList<Integer> coins;
    ArrayList<List<Integer>> changes = new ArrayList<List<Integer>>();

    public ChangeCalculator(List<Integer> coinDenominations) {
        if (coinDenominations == null || coinDenominations.size() == 0)
            throw new IllegalArgumentException("Denominations must be supplied");

        Collections.sort(coinDenominations);
        this.coins = new ArrayList<Integer>(coinDenominations);
        if (this.coins.get(0) < 1)
            throw new IllegalArgumentException("Denominations must be positive");
    }

    public List<Integer> computeMostEfficientChange(int targetAmount) {
        recurse(coins.size() - 1, targetAmount, new ArrayList<Integer>());

        for (int i = 0; i < changes.size(); i++) {
            var list = changes.get(i);
            System.out.println("\nList #" + (i + 1) + ": ");
            var sb = new StringBuffer();
            for (Integer coin : list) {
                sb.append(coin + ", ");
            }
            System.out.println(sb.toString());
        }
        return null;
    }

    public boolean recurse(int denomIdx, int remainingAmount, List<Integer> change) {
        if (denomIdx == -1)
            return false;

        int denominator = coins.get(denomIdx);
        int numCoins = remainingAmount / denominator;
        for (int i = numCoins; i >= 0; i--) {
            remainingAmount -= i * denominator;
            if (remainingAmount == 0) {
                // for (int j = 0; j < i; j++)
                // change.add(denominator);

                return true;
            }

            if (recurse(denomIdx - 1, remainingAmount, change)) {
                for (int j = 0; j < i; j++)
                    change.add(coins.get(denomIdx - 1));

                changes.add(change);
            }
        }

        return false;
    }

    // public List<Integer> computeMostEfficientChangeV0(int targetAmount) {
    // if (targetAmount < 0)
    // throw new IllegalArgumentException("Negative totals are not allowed.");

    // int remainingChange = targetAmount;

    // ArrayList<Integer> change = null;
    // var workingDenominations = new ArrayList<Integer>(coins);
    // while (remainingChange > 0) {
    // change = new ArrayList<Integer>();
    // for (Integer denomination : workingDenominations) {
    // int numCoins = remainingChange / denomination;
    // if (numCoins == 0)
    // continue;

    // for (int i = 0; i < numCoins; i++)
    // change.add(denomination);

    // remainingChange = remainingChange % denomination;
    // }

    // workingDenominations.remove(workingDenominations.size() - 1)
    // }

    // change.sort(Comparator.reverseOrder());
    // return change;
    // }

}