import java.util.ArrayList;
public class Transpose {
    public String transpose(String input) {
        if (input == null || input == "")
            return "";


        String[] rows = input.split("\n");
        int maxLen = 0;
        for (String row : rows) {
            if (row == null || row == "")
                continue;

            if (row.length() > maxLen)
                maxLen = row.length();
        }

        var grid = new ArrayList<String>();
        for (var row : rows) {
            int addlSpacesNeeded = maxLen - row.length();
            var spaceBuilder = new StringBuilder(row);
            for (int i = 0; i < addlSpacesNeeded; i++)
                spaceBuilder.append(" ");

            grid.add(spaceBuilder.toString());
        }

        var transposedGrid = new ArrayList<StringBuilder>();
        for (int i = 0; i < maxLen; i++) {
            var col = new StringBuilder(maxLen);
            transposedGrid.add(col);
            // for (var row : grid)
            //     col.append(row.charAt(i));
            boolean haveSeenNonWs = false;
            for (int j = grid.size() - 1; j > -1; j--) {
                var row = grid.get(j);
                char c = row.charAt(j);
                if (c != ' ')
                    haveSeenNonWs = true;

                if (!haveSeenNonWs && c == ' ')
                    continue;
            }
        }



        StringBuilder sb = new StringBuilder();
        String prefix = "";
        for (var tranRow : transposedGrid) {
            sb.append(prefix);
            prefix = "\n";
            sb.append(tranRow.toString());
            // for (int i = 0; i < grid.size(); j++) {
            //     String s = grid.get(j).toString();
            //     char c = s.charAt(i);
            //     String remainingChars = s.substring(i);
                // boolean allSpaces = true;
                // for (int k = 1; k < remainingChars.length(); k++)
                //     if (remainingChars.charAt(k) != ' ')
                //         allSpaces = false;

                // if (!allSpaces)
            }

        System.err.println(input + " transposed is " + sb.toString());
        return sb.toString();
    }

}