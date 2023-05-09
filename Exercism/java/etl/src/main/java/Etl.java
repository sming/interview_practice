import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.HashMap;

class Etl {

    Map<String, Integer> transform(Map<Integer, List<String>> old) {
        var result = new HashMap<String, Integer>();
        for (var entry : old.entrySet()) {
            for (var letter : entry.getValue()) {
                result.put(letter.toLowerCase(), entry.getKey());
            }
        }

        return result;
    }
}
