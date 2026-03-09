
using System;
using System.Collections.Generic;

class Unit
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int Attack { get; set; }

    public void AttackUnit(Unit enemy)
    {
        enemy.HP = -Attack;
        Console.WriteLine(Name + "attacked" + enemy.Name);
    }

    public bool IsAlive()
    {
        return HP > 0;
    }
}

class Warrior : Unit 
{ 
    public Warrior(string name)
    {
        Name = name;
        HP = 300;
        Attack = 130;
    }
}
class Archer : Unit 
{
    public Archer(string name)
    {
        Name = name;
        HP = 400;
        Attack = 150;
    }
}

class Battle
{
    public List<Unit> Army1 = new List<Unit>();
    public List<Unit> Army2 = new List<Unit>();

    public void Start()
    {
        Random rand = new Random();

        while (Army1.Count > 0 && Army2.Count > 0)
        {
            Unit u1 = Army1[0];
            Unit u2 = Army2[0];

            if (rand.Next(2) == 0)
            {
                u1.AttackUnit(u2);

                if (!u2.IsAlive())
                {
                    Console.WriteLine(u2.Name + " dead");
                    Army2.RemoveAt(0);
                }
            }
            else
            {
                u2.AttackUnit(u1);

                if (!u1.IsAlive())
                {
                    Console.WriteLine(u1.Name + " dead");
                    Army1.RemoveAt(0);
                }
            }
        }

        if (Army1.Count > 0)
            Console.WriteLine("Win Army1");
        else
            Console.WriteLine("Win Army2");
    }

}

class Program
{
    static void Main()
    {
        Battle battle = new Battle();

        battle.Army1.Add(new Archer("Archer_one"));
        battle.Army1.Add(new Warrior("Warrior_two"));

        battle.Army2.Add(new Warrior("Warrior_one"));
        battle.Army2.Add(new Archer("Archer_two"));

        battle.Start();

    }
}


