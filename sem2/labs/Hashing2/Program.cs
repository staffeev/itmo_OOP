using System.Collections.Generic;
using System.IO;
using System.Reflection;

class Program
{

    static long[] GetPPows(int p, int m)
    {
        // массив степеней p
        long[] p_pows = new long[m];
        p_pows[0] = 1;
        for (int i = 1; i < m; i++)
        {
            p_pows[i] = p_pows[i - 1] * p;
        }
        return p_pows;
    }
    static long CalcHash(string s, long[] p_pows)
    {
        // вычисление полиномиального хэша
        long hash = 0;
        for (int i = 0; i < s.Length; i++)
        {
            hash += (s[i] - 'a' + 1) * p_pows[i];
        }
        return hash;
    }

    static long[] CalcPrefixHash(string s, long[] p_pows)
    {
        // вычисление хэшей для всех префиксов строки
        long[] hashes = new long[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            hashes[i] = (s[i] - 'a' + 1) * p_pows[i];
            if (i != 0)
            {
                hashes[i] += hashes[i - 1];
            }
        }
        return hashes;
    }

    static void Main()
    {
        int p = 29;

        string s = Console.ReadLine();
        string t = Console.ReadLine();
        int n = s.Length, m = t.Length;

        var p_pows = GetPPows(p, n);
        var s_hashes = CalcPrefixHash(s, p_pows);
        var t_hash = CalcHash(t, p_pows);

        for (int i = 0; i <= n - m; i++)
        {
            long cur_hash = s_hashes[i + m - 1];
            if (i > 0)
            {
                cur_hash = cur_hash - s_hashes[i - 1];
            }

            if (cur_hash == t_hash * p_pows[i])
            {
                Console.WriteLine(i);
            }
        }
    }
}