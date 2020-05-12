import java.util.Stack;

public class BracketChecker {
	private String input;
	private Stack<Character> stack = new Stack<Character>();
	private static String openingBrackets = "([{";
	private static String closingBrackets = ")]}";

	public BracketChecker(String input) {
		this.input = input;
	}
	
	private static boolean isClosingBracket(char c) {
		return closingBrackets.indexOf(c) != -1;
	}
	
	private static boolean isOpeningBracket(char c) {
		return openingBrackets.indexOf(c) != -1;
	}
	
	private static boolean isValidBracketPair(char opening, char closing) {
		return openingBrackets.indexOf(opening) == closingBrackets.indexOf(closing);
	}
	
	/**
	 * Given a string containing brackets [], braces {}, parentheses (), or 
	 * any combination thereof, verify that any and all pairs are matched 
	 * and nested correctly.
	 */
	public boolean areBracketsMatchedAndNestedCorrectly()
	{
		if (input == null || input.length() == 0)
			return true;
		
		return areCorrectRecursive(0, input.length());
	}

	private boolean areCorrectRecursive(int i, int length) {
		if (i >= length) {
			return stack.size() == 0;
		}
		
		char c = input.charAt(i);
		if (isOpeningBracket(c)) {
			stack.push(c);
		} else if (isClosingBracket(c)) {
			if (stack.empty())
				return false;
			char lastOpener = stack.peek();
			if (!isValidBracketPair(lastOpener, c))
				return false;
			else
				stack.pop();
		}
		
		return areCorrectRecursive(i + 1, length);
		
	}
}