
using System;
using System.Collections.Generic;

class Unit
{
    public string Name;
    public int HP;
    public int Attack;
}

class Warrior : Unit { }
class Archer : Unit { }

class Program
{
    static void Main()
    {
        List<Unit> army1 = new List<Unit>();
        List<Unit> army2 = new List<Unit>();

        Warrior w1 = new Warrior();
        w1.Name = "warrior_one";
        w1.HP = 200;
        w1.Attack = 120;
        army2.Add(w1);

        Archer a1 = new Archer();
        a1.Name = "Archer_one";
        a1.HP = 400;
        a1.Attack = 150;
        army1.Add(a1);

        Warrior w2 = new Warrior();
        w2.Name = "Warrior_two";
        w2.HP = 300;
        w2.Attack = 135;
        army1.Add(w2);

        Archer a2 = new Archer();
        a2.Name = "Archer_two";
        a2.HP = 450;
        a2.Attack = 200;
        army2.Add(a2);

        Random rand = new Random();

        while (army1.Count > 0 && army2.Count > 0)
        {
            Unit u1 = army1[0];
            Unit u2 = army2[0];

            if(rand.Next(2) == 0)
            {
                u2.HP -= u1.Attack;
                Console.WriteLine(u1.Name + " Attacked " + u2.Name);

                if(u2.HP < 0)
                {
                    Console.WriteLine(u2.Name + " dead ");
                    army2.RemoveAt(0);
                }
            }
            else
            {
                u1.HP -= u2.Attack;
                Console.WriteLine(u2.Name + " attacked " + u1.Name);

                if(u1.HP < 0)
                {
                    Console.WriteLine(u1.Name + " dead ");
                    army1.RemoveAt(0);
                }
            }
        }

        if (army1.Count > 0)
            Console.WriteLine("Win army1");
        else
            Console.WriteLine("Win army2");
    }
}


