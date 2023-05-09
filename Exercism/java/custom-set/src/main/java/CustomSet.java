import java.util.Set;
import java.util.HashSet;
import java.util.Collection;

public class CustomSet<T> {
    private Set<T> impl;
    public CustomSet(Collection<T> elements) {
        impl = new HashSet<T>(elements);
    }

    @Override
    public boolean equals(Object other) {
        if (!(other instanceof CustomSet))
            return false;
        var o = (CustomSet)(other);
        return impl.equals(o.impl);
    }

    // no element of A can be in B and vice versa
    public boolean isDisjoint(CustomSet<T> other) {
        for (T element : impl)
            if (other.contains(element))
                return false;

        return true;
    }

    // are we a subset of other
    public boolean isSubset(CustomSet<T> other) {
        for (T element : other.impl)
            if (!impl.contains(element))
                return false;

        return true;
    }

    public CustomSet<T> getUnion(CustomSet<T> other) {
        var holder = new CustomSet<T>(this.impl);
        holder.impl.addAll(other.impl);
        return holder;
    }

    public CustomSet<T> getIntersection(CustomSet<T> other) {
        var holder = new CustomSet<T>(this.impl);
        holder.impl.retainAll(other.impl);
        return holder;
    }

    public CustomSet<T> getDifference(CustomSet<T> other) {
        var holder = new CustomSet<T>(this.impl);
        holder.impl.removeAll(other.impl);
        return holder;
    }

    public CustomSet<T> add(T elem) {
        this.impl.add(elem);
        return this;
    }

    public boolean isEmpty() {
        return impl.isEmpty();
    }

    public boolean contains(Object o) {
        return impl.contains(o);
    }
}