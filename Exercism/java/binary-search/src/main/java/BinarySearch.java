import java.util.List;

public class BinarySearch {

  private final List<Integer> list;

  public BinarySearch(List<Integer> list) {
    this.list = list;
  }

  public int indexOf(int target) {
    if (list == null || list.isEmpty())
      throw new ValueNotFoundException("Value not in array");

    return indexOf(target, 0, list.size() - 1);
  }

  private int indexOf(int target, int startIdx, int endIdx) {
    int midIdx = (startIdx + endIdx) / 2;

    var midValue = list.get(midIdx);
    if (midValue == target)
      return midIdx;
    else if (list.get(startIdx) == target)
      return startIdx;
    else if (list.get(endIdx) == target)
      return endIdx;

    if (startIdx >= endIdx || endIdx <= startIdx)
      throw new ValueNotFoundException("Value not in array");

    if (endIdx - startIdx <= 1)
      throw new ValueNotFoundException("Value not in array");

    if (midValue > target)
      return indexOf(target, startIdx, midIdx);
    else if (midValue < target)
      return indexOf(target, midIdx, endIdx);
    else
      throw new ValueNotFoundException("Value not in array");
  }
}
