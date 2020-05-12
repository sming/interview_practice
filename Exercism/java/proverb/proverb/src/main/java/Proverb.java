class Proverb {

    private String[] words;
    private static String prefix = "For want of a ";
    private static String middle = " the ";
    private static String postfix = " was lost.";
    private static String finale = "And all for the want of a ";


	Proverb(String[] words) {
        this.words = words;
    }

    String recite() {
        if (words == null || words.length == 0)
        	return "";
        StringBuilder sb = new StringBuilder();
        for (int i = 1; i < words.length; i++) {
			String wantOfA = words[i-1];
			String wasLost = words[i];
			
			sb.append(prefix + wantOfA + middle + wasLost + postfix + System.lineSeparator());
		}
        
        sb.append(finale + words[0] + ".");
        
        return sb.toString();
    }

}
