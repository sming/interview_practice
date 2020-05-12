using System;
using System.Collections.Generic;

namespace RecursionPractice
{
    public class StringPermutations
    {
        /**
         * a => a len: 1
         * ab => ab, ba == previous set, augmented with b
         * abc => abc, bac, bca, acb, cab, cba == previous set, augmented with c
         */
        public ISet<String> GetAllPermutations(String s)
        {
            var resultSet = new HashSet<String>();
            if (s == null || s.Length == 0)
                return resultSet;

            foreach (char c in s)
            {
                AddCharToPermutations(c, resultSet);
            }

            return resultSet;
        }

        private void AddCharToPermutations(char c, HashSet<string> resultSet)
        {
            var set = new HashSet<String>();
            foreach (string s in resultSet)
            {
                InsertInAllLocations(c, s, set);
            }
        }

        private void InsertInAllLocations(char c, string s, HashSet<string> set)
        {
            for (int i = 0; i < s.Length; i++)
            {
                string perm = s.Substring(0, i) + c + s.Substring(i + 1);
                _ = set.Add(perm);
            }
        }
    }
}
