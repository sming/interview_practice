import java.util.List;

public class BinarySearchV1 {
  private final List<Integer> input;

  public BinarySearchV1(List<Integer> input) {
    this.input = input;
  }

  public int indexOf(int query) throws ValueNotFoundException {
    if (input == null || input.size() == 0)
      throw new ValueNotFoundException("Value not in array");

    return findIndexOf(query, 0, input.size() - 1);
  }

  private int findIndexOf(int query, int startIdx, int endIdx)
      throws ValueNotFoundException {
    int midwayIdx = startIdx + Math.abs((endIdx - startIdx) / 2);
    int midway = input.get(midwayIdx);

    if (midway == query) return midwayIdx;
    else if (input.get(startIdx) == query) return startIdx;
    else if (input.get(endIdx) == query) return endIdx;

    if (startIdx > endIdx)
        throw new ValueNotFoundException("Value not in array");

    if (midwayIdx > startIdx && midway > query)
      return findIndexOf(query, startIdx, midwayIdx -1);
    else if (midwayIdx > startIdx && midway < query)
      return findIndexOf(query, midwayIdx, endIdx);


    throw new ValueNotFoundException("Value not in array");
  }
}
