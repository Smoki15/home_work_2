using System;
using System.Collections.Generic;

namespace GameMapDemo
{
    public abstract class MapObject
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        protected MapObject(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract char Symbol { get; }
        public abstract bool IsAlive { get; }

        public virtual void Update() { }

        public virtual void Render(char[,] buffer)
        {
            buffer[Y, X] = Symbol;
        }
    }

    public class Tree : MapObject
    {
        public int Height { get; private set; }
        public bool Alive { get; private set; } = true;

        public Tree(int x, int y, int height) : base(x, y)
        {
            Height = height;
        }

        public override char Symbol => Alive ? 'T' : 't';
        public override bool IsAlive => Alive;

        public void Grow() => Height++;
        public void ChopDown() => Alive = false;
    }

    public class Stone : MapObject
    {
        public int Durability { get; private set; }

        public Stone(int x, int y, int durability) : base(x, y)
        {
            Durability = durability;
        }

        public override char Symbol => Durability > 0 ? 'S' : '.';
        public override bool IsAlive => Durability > 0;

        public void Damage(int value)
        {
            Durability -= value;
            if (Durability < 0)
                Durability = 0;
        }
    }

    public class Unit : MapObject
    {
        public string Name { get; }
        public int HP { get; private set; }
        public int Damage { get; }

        public Unit(int x, int y, string name, int hp, int damage) : base(x, y)
        {
            Name = name;
            HP = hp;
            Damage = damage;
        }

        public override char Symbol => HP > 0 ? 'U' : 'X';
        public override bool IsAlive => HP > 0;

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public void TakeDamage(int value)
        {
            HP -= value;
            if (HP < 0)
                HP = 0;
        }
    }

    public class Map
    {
        private readonly int width;
        private readonly int height;

        private readonly List<Tree> trees = new();
        private readonly List<Stone> stones = new();
        private readonly List<Unit> units = new();

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void AddTree(Tree tree) => trees.Add(tree);
        public void AddStone(Stone stone) => stones.Add(stone);
        public void AddUnit(Unit unit) => units.Add(unit);

        public void Render()
        {
            char[,] buffer = new char[height, width];

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    buffer[y, x] = '.';

            foreach (var tree in trees)
                tree.Render(buffer);

            foreach (var stone in stones)
                stone.Render(buffer);

            foreach (var unit in units)
                unit.Render(buffer);

            Console.Clear();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    Console.Write(buffer[y, x] + " ");
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Map map = new Map(10, 6);

            map.AddTree(new Tree(2, 1, 5));
            map.AddTree(new Tree(4, 3, 7));

            map.AddStone(new Stone(6, 2, 10));
            map.AddStone(new Stone(1, 4, 5));

            Unit hero = new Unit(0, 0, "Hero", 100, 15);
            map.AddUnit(hero);

            map.Render();
            Console.ReadKey();

            hero.Move(2, 1);
            map.Render();
            Console.ReadKey();

            hero.Move(1, 1);
            map.Render();
            Console.ReadKey();
        }
    }
}