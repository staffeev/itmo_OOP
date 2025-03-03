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
    static long CalcHash(string s, long[] p_pows, long mod)
    {
        // вычисление полиномиального хэша
        long hash = 0;
        for (int i = 0; i < s.Length; i++)
        {
            hash += (s[i] - 'a' + 1) * p_pows[i];
        }
        return hash % mod;
    }
    static string[] ReadLinesFromFile(string file_name)
    {
        string proj_dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string file_path = Path.Combine(proj_dir, file_name);
        var lines = new List<string>();

        using (var reader = new StreamReader(file_path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        return lines.ToArray();
    }
    static Dictionary<int, long> CreateHashDict(string[] lines, int m, int p, long mod)
    {
        var p_pows = GetPPows(p, m);
        var hashes = new Dictionary<int, long>();

        for (int i = 0; i < lines.Length; i++)
        {
            hashes[i] = CalcHash(lines[i], p_pows, mod);
        }

        return hashes;
    }
    static void Main()
    {
        int m = 10, p = 29;
        long mod = 1000000007;
        string file_name = "string_list.csv";

        var lines = ReadLinesFromFile(file_name);
        var hashes = CreateHashDict(lines, m, p, mod);

        int cnt = 20;
        Console.WriteLine("Первые {0} строк и их хэши", cnt);
        int i = 1;
        foreach (var hash in hashes)
        {
            Console.WriteLine("{0, -10} | {1}", lines[hash.Key], hash.Value);
            i++;
            if (i == cnt) { break; }
        }

        hashes = hashes.OrderBy(hash => hash.Value).ToDictionary(hash => hash.Key, hash => hash.Value);

        int group_num = 0;
        var prev_hash = hashes.First();
        foreach (var hash in hashes)
        {
            if (hash.Equals(hashes.First()) || hash.Value != prev_hash.Value)
            {
                group_num++;
                Console.WriteLine();
                Console.Write("Group {0}: ", group_num);
            }
            Console.Write(hash.Key + " ");
            prev_hash = hash;
        }
    }
}