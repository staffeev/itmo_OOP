using System;

class Dice
{
    private Random rnd;
    public Dice()
    { // конструктор
        rnd = new Random();
    }
    public int Throw()
    { // бросок кубика
        return rnd.Next(1, 7);
    }
}

class Player
{
    private string name;
    private Dice dice;
    public Player(string name)
    {
        this.name = name;
        this.dice = new Dice();
    }
    public delegate void PlayerDelegate(Player player);
    public static event PlayerDelegate MaxPointsEvent;
    public int Play()
    { // выполнить бросок кубика игроком
        int res = dice.Throw();
        if (res == 6) MaxPointsEvent(this);
        return res;
    }
    public override string ToString()
    {
        return name;
    }
}

class Program
{
    public static void ProcessPlayersThrow(Player p) {
        Console.WriteLine("У игрока {0} выпало максимальное количество очков!", p);
    }
    public static void Main(string[] args)
    {
        Player.MaxPointsEvent += ProcessPlayersThrow;
        Player p = new Player("Ваня");
        Player p2 = new Player("Саша");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Игрок {0} сделал бросок, получено очков: {1}", p, p.Play());
            Console.WriteLine("Игрок {0} сделал бросок, получено очков: {1}", p2, p2.Play());
        }
    }
}