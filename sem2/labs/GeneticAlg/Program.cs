using System.Globalization;

class RandomOperations
{
    public static Random rnd = new Random();
    public static HashSet<int> GetRandomFromRange(int min, int max, int count)
    {
        var numbers = new HashSet<int>();
        while (numbers.Count < count)
        {
            numbers.Add(rnd.Next(min, max + 1));
        }
        return numbers;
    }
    public static HashSet<int> GetSetRange(int min, int max)
    {
        return new HashSet<int>(Enumerable.Range(min, max - min + 1));
    }

}

class Eq
{
    public int[] nums;
    public int expected_result;
    public int left_border, right_border, num_of_mutations;
    public Func<int[], int> f;
    private static Random rnd = new Random();
    public int cur_result
    {
        get { return f(nums); }
    }
    public double fitting_f
    {
        get { return (double)Math.Abs(cur_result - expected_result) / (double)Math.Abs(expected_result); }
    }
    public Eq(Func<int[], int> f, int expected_result, int left_border,
                int right_border, int num_of_mutations, int[] nums)
    {
        this.f = f;
        this.expected_result = expected_result;
        this.nums = nums;
        this.left_border = left_border;
        this.right_border = right_border;
        this.num_of_mutations = num_of_mutations;
    }
    public void Mutate()
    {
        var param_nums = RandomOperations.GetRandomFromRange(0, nums.Length - 1, num_of_mutations);
        foreach (int par_num in param_nums)
        {
            int delta = rnd.Next(-2, 3);
            nums[par_num] = Math.Clamp(nums[par_num] + delta, left_border, right_border);
        }
    }
    public void Print()
    {
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write("x{0}={1}, ", i + 1, nums[i]);
        }
        Console.WriteLine();
    }
    public static Eq operator +(Eq father, Eq mother)
    {
        int n = father.nums.Length;
        var father_genes = RandomOperations.GetRandomFromRange(0, n - 1, n / 2);
        var mother_genes = RandomOperations.GetSetRange(0, n - 1);
        mother_genes.ExceptWith(father_genes);
        int[] new_genes = new int[n];
        foreach (int fgen in father_genes)
        {
            new_genes[fgen] = father.nums[fgen];
        }
        foreach (int mgen in mother_genes)
        {
            new_genes[mgen] = mother.nums[mgen];
        }
        return new Eq(father.f, father.expected_result, father.left_border, father.right_border,
            father.num_of_mutations, new_genes);

    }
    public static Eq GenerateEq(Func<int[], int> f, int expected_result, int left_border,
                int right_border, int num_of_mutations, int num_params)
    {
        // генерация уравнения со случайными параметрами при известном результате и функции
        int[] nums = new int[num_params];
        for (int i = 0; i < num_params; i++)
        {
            nums[i] = rnd.Next(left_border, right_border + 1);
        }
        return new Eq(f, expected_result, left_border, right_border, num_of_mutations, nums);
    }
    public static double FittingMean(List<Eq> eqs)
    {
        double sum = 0;
        foreach (Eq eq in eqs)
        {
            sum += eq.fitting_f;
        }
        return sum / eqs.Count;
    }
    public static double GenStdev(List<Eq> eqs)
    {
        double mean = FittingMean(eqs);
        double stdev = 0;
        for (int i = 0; i < eqs.Count; i++)
        {
            stdev += Math.Pow(eqs[i].fitting_f - mean, 2);
        }
        return Math.Sqrt(stdev / eqs.Count);
    }
}

class Program
{
    static void Main()
    {
        // параметры одного уравнения
        Func<int[], int> f = (nums) => nums[0] + 2 * nums[1] + 3 * nums[2] + 4 * nums[3];
        int expected_result = 30;
        int left_border = 1, right_border = 30, num_of_mutations = 1;
        // параметры поколения
        int start_eq_num = 10;
        double survive_ratio = 0.5;
        double mutants_ratio = 0.1;
        var rnd = RandomOperations.rnd;

        var generations = new List<Eq>(start_eq_num);
        for (int i = 0; i < start_eq_num; i++)
        {
            generations.Add(Eq.GenerateEq(f, expected_result, left_border, right_border, num_of_mutations, 4));
        }

        for (int i = 0; ; i++)
        {
            var cur_mean = Eq.FittingMean(generations);
            var cur_stdev = Eq.GenStdev(generations);
            var best_gens = generations.OrderBy(g => 1 + (g.fitting_f - cur_mean) / (2 * cur_stdev)).ToList();
            var med = best_gens[start_eq_num / 2];

            Console.WriteLine("Generation {0}, FitMin {1}, FitMax {2}, FitMean {3}", i + 1, best_gens[0].fitting_f, best_gens[start_eq_num - 1].fitting_f, cur_mean);

            if (best_gens.Any(g => g.fitting_f == 0))
            {
                best_gens[0].Print();
                break;
            }

            var new_generations = new List<Eq>(best_gens.Take((int)(survive_ratio * start_eq_num)));
            while (new_generations.Count < start_eq_num)
            {
                var father = generations[rnd.Next(start_eq_num)];
                var mother = generations[rnd.Next(start_eq_num)];
                var child = father + mother;
                new_generations.Add(child);
            }
            int mutants = (int)(mutants_ratio * start_eq_num);
            foreach (int eq_num in RandomOperations.GetRandomFromRange(0, start_eq_num - 1, mutants))
            {
                new_generations[eq_num].Mutate();
            }
            generations = new_generations;
        }

    }
}