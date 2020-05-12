import java.util.ArrayList;
import java.util.List;

public class Flattener {

	public List<Object> flatten(List<Object> input) {
		List<Object> result = new ArrayList<Object>();
		if (input == null || input.size() == 0)
			return result; 
		
		recursiveFlatten(0, input.size(), input, result);
		return result;
	}

	private void recursiveFlatten(int i, int size, List<Object> input, List<Object> result) {
		if (i > size -1 || input == null || input.get(i) == null)
			return;
				
		Object element = input.get(i);
		if (element instanceof java.util.List) {
			List<Object> list = List.class.cast(element);
			recursiveFlatten(0, list.size(), list, result);
		} else {
			result.add(element);
		}
		i++;
		
		recursiveFlatten(i, input.size(), input, result);
	}
	
}