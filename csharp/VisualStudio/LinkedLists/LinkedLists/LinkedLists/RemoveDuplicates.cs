using System;
using System.Collections.Generic;

namespace LinkedLists
{
    /*
     * Write code to remove duplicates from an unsorted linked list. FOLLOW UP
        How would you solve this problem if a temporary buffer is not allowed?  
        */
    public class RemoveDuplicates<T>
    {
        public static LinkedList<T> Go(LinkedList<T> input)
        {
            var set = new HashSet<T>();
            var current = input.Tail;
            var retVal = new LinkedList<T>();
            while (current != null)
            {
                if (!set.Contains(current.Val))
                {
                    set.Add(current.Val);
                    retVal.Push(current.Val);
                }

                current = current.Next;
            }

            return retVal;
        }
    }
    /*
     * Do the same except not using a data structure
        */
    public class RemoveDuplicatesNoBuffer<T>
    {
        
    }
}
