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
    public int Play()
    { // выполнить бросок кубика игроком
        return dice.Throw();
    }
    public override string ToString()
    {
        return name;
    }
}

class Program {
    public static void Main(string[] args) {
        Player p = new Player("Ваня");
        for (int i = 0; i < 10; i++) {
            Console.WriteLine("Игрок {0} сделал бросок, получено очков: {1}", p, p.Play());
        }
    }
}