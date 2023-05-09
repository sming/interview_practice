/**
 * Instructions Implement a doubly linked list.
 *
 * Like an array, a linked list is a simple linear data structure. Several
 * common data types can be implemented using linked lists, like queues, stacks,
 * and associative arrays.
 *
 * A linked list is a collection of data elements called nodes. In a singly
 * linked list each node holds a value and a link to the next node. In a doubly
 * linked list each node also holds a link to the previous node.
 *
 * You will write an implementation of a doubly linked list. Implement a Node to
 * hold a value and pointers to the next and previous nodes. Then implement a
 * List which holds references to the first and last node and offers an
 * array-like interface for adding and removing items:
 *
 * push (insert value at back); pop (remove value at back); shift (remove value
 * at front). unshift (insert value at front); To keep your implementation
 * simple, the tests will not cover error conditions. Specifically: pop or shift
 * will never be called on an empty list.
 *
 * If you want to know more about linked lists, check Wikipedia.
 *
 * This exercise introduces generics. To make the tests pass you need to
 * construct your class such that it accepts any type of input, e.g. Integer or
 * String.
 *
 * Generics are useful because they allow you to write more general and reusable
 * code. The Java List and Map implementations are both examples of classes that
 * use generics. By using them you can construct a List containing Integers or a
 * list containing Strings or any other type.
 *
 * There are a few constraints on the types used in generics. One of them is
 * that once you've constructed a List containing Integers, you can't put
 * Strings into it. You have to specify which type you want to put into the
 * class when you construct it, and that instance can then only be used with
 * that type.
 *
 * For example you could construct a list of Integers:
 *
 * List<Integer> someList = new LinkedList<>();
 *
 * Now someList can only contain Integers. You could also do:
 *
 * List<String> someOtherList = new LinkedList<>()
 *
 * Now someOtherList can only contain Strings.
 *
 * Another constraint is that any type used with generics cannot be a primitive
 * type, such as int or long. However, every primitive type has a corresponding
 * reference type, so instead of int you can use Integer and instead of long you
 * can use Long.
 *
 * It can help to look at an example use case of generics to get you started.
 */

public class DoublyLinkedList<T> {
    private Node<T> head;
    private Node<T> back;

    private static class Node<T> {
        private T value;
        private Node<T> next;
        private Node<T> prev;

        Node(T val) {
            value = val;
        }
    }

    public void unshift(T val) {
        var newNode = new Node<T>(val);
        if (back == null)
            back = newNode;

        if (head == null) {
            head = newNode;
        } else {
            head.next = newNode;
            newNode.prev = head;
            head = newNode;
        }
    }

    public T pop() {
        if (back == null)
            return null;

        var oldBack = back;
        back = back.next;
        return oldBack.value;
    }

    public T shift() {
        var oldHead = head;
        head = oldHead.prev;
        if (head != null)
            head.next = null;

        return oldHead.value;
    }

    public void push(T val) {
        var newNode = new Node<T>(val);
        var oldBack = back;

        if (head == null)
            head = newNode;

        if (back == null)
            back = newNode;
        else {
            back = newNode;
            back.next = oldBack;
            oldBack.prev = newNode;
        }
    }
}