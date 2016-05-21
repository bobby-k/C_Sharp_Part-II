using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        
        string str = Console.ReadLine();
        
        HashSet<string> perms = FindPermutations(str);

        int count = 0;
        foreach (var perm in perms)
        {
            for (int i = 1; i < perm.Length; i++)
            {
                if (perm[i] == perm[i - 1])
                {
                    count--;
                    break;
                }
            }

            count++;
        }

        Console.WriteLine(count);
    }

    static HashSet<string> FindPermutations(string word)
    {
        // 1. remove first char 
        // 2. find permutations of the rest of chars
        // 3. Attach the first char to each of those permutations.
        //     3.1  for each permutation, move firstChar in all indexes to produce even more permutations.
        // 4. Return list of possible permutations.

        if (word.Length == 2)
        {
            char[] _c = word.ToCharArray();
            string s = new string(new char[] { _c[1], _c[0] });
            return new HashSet<string>
                {
                    word,
                    s
                };
        }
        HashSet<string> _result = new HashSet<string>();
        HashSet<string> _subsetPermutations = FindPermutations(word.Substring(1));
        char _firstChar = word[0];
        foreach (string s in _subsetPermutations)
        {
            string _temp = _firstChar.ToString() + s;
            _result.Add(_temp);
            char[] _chars = _temp.ToCharArray();
            for (int i = 0; i < _temp.Length - 1; i++)
            {
                char t = _chars[i];
                _chars[i] = _chars[i + 1];
                _chars[i + 1] = t;
                string s2 = new string(_chars);
                _result.Add(s2);
            }
        }
        return _result;
    }

}