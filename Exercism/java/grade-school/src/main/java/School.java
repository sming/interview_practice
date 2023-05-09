import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.SortedSet;
import java.util.TreeMap;
import java.util.TreeSet;
import java.util.stream.Collectors;

/**
 * Instructions Given students' names along with the grade that they are in, create a roster for the
 * school.
 * <p>
 * In the end, you should be able to:
 * <p>
 * Add a student's name to the roster for a grade "Add Jim to grade 2." "OK." Get a list of all
 * students enrolled in a grade "Which students are in grade 2?" "We've only got Jim just now." Get
 * a sorted list of all students in all grades. Grades should sort as 1, 2, 3, etc., and students
 * within a grade should be sorted alphabetically by name. "Who all is enrolled in school right
 * now?" "Let me think. We have Anna, Barb, and Charlie in grade 1, Alex, Peter, and Zoe in grade 2
 * and Jim in grade 5. So the answer is: Anna, Barb, Charlie, Alex, Peter, Zoe and Jim" Note that
 * all our students only have one name. (It's a small town, what do you want?)
 * <p>
 * For bonus points Did you get the tests passing and the code clean? If you want to, these are some
 * additional things you could try:
 * <p>
 * If you're working in a language with mutable data structures and your implementation allows
 * outside code to mutate the school's internal DB directly, see if you can prevent this. Feel free
 * to introduce additional tests. Then please share your thoughts in a comment on the submission.
 * Did this experiment make the code better? Worse? Did you learn anything from it?
 */
public class School {

  private TreeMap<Integer, SortedSet<String>> grades = new TreeMap<>();

  public void add(String name, int grade) {
    if (grades.containsKey(grade)) {
      grades.get(grade).add(name);
    } else {
      grades.put(grade, new TreeSet<>(List.of(name)));
    }
  }

  public List<String> roster() {
    return grades.entrySet().stream().flatMap(x -> x.getValue().stream())
        .collect(Collectors.toList());
  }

  public List<String> grade(int grade) {
    if (!grades.containsKey(grade))
      return new ArrayList<>();

    return new ArrayList<>(grades.get(grade));
  }
}