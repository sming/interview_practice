/** a → a
ab → ab, ba
abc → abc, cab, bca, acb, cba, bac (NxN-1 items) */

using System.Collections.Generic;

namespace org.psk.playground
{

    public class Permer
    {
        private readonly string _originalString;

        public Permer(string originalString)
        {
            this._originalString = originalString;
        }

        public HashSet<string> GetPermutations()
        {
            var baseCase = new HashSet<string> { string.Empty };
            return GetPermutationsRecursive(0, baseCase);
        }

        private HashSet<string> GetPermutationsRecursive(int idx, HashSet<string> permutations)
        {
            if (idx == this._originalString.Length)
                return permutations;

            char currChar = this._originalString[idx];

            int count = permutations.Count;
            var nextPermutations = new HashSet<string>(count * (count - 1));
            foreach (string permutation in permutations)
            {
                nextPermutations.UnionWith(Permute(permutation, currChar));
            }

            return GetPermutationsRecursive(++idx, nextPermutations);
        }

        // ba + c → cba, bca, bac
        private static HashSet<string> Permute(string str, char c)
        {
            var result = new HashSet<string>(str.Length + 1);
            for (int i = 0; i < str.Length; i++)
            {
                result.Add(str.Insert(i, c + ""));
            }

            result.Add(str + c);
            return result;
        }

    }
}