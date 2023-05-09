import java.util.ArrayDeque;
import java.util.Deque;

/**
 * Tail of queue == newest elements
 * Head of queue == oldest elements
 * @param <T>
 */
public class CircularBuffer<T> {

    private final int size;
    private Deque<T> deq = new ArrayDeque<T>();

    public CircularBuffer(int size) {
        this.size = size;
    }

    public void write(T i) throws BufferIOException {
        if (deq.size() == size)
            throw new BufferIOException("Tried to write to full buffer");

        deq.add(i);
    }

    public void overwrite(T i) {
        if (deq.size() < size)
            deq.add(i);
        else {
            deq.remove();
            deq.add(i);
        }
    }

    public T read() throws BufferIOException {
        if (deq.size() == 0)
            throw new BufferIOException("Tried to read from empty buffer");

        return deq.remove();
    }

    public void clear() {
        deq.clear();
    }
}
