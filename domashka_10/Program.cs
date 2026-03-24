
namespace GameCharacterBuilder
{
    public interface ICharacter
    {
        string Name { get; }
        string Class { get; }
        int Strength { get; }
        int Agility { get; }
        int Intelligence { get; }

        void ShowInfo();
    }

    public class Character : ICharacter
    {
        public string Name { get; internal set; }
        public string Class { get; internal set; }
        public int Strength { get; internal set; }
        public int Agility { get; internal set; }
        public int Intelligence { get; internal set; }

        public void ShowInfo()
        {
            Console.WriteLine("=== Character ===");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"STR: {Strength}");
            Console.WriteLine($"AGI: {Agility}");
            Console.WriteLine($"INT: {Intelligence}");
        }
    }

    public interface ICharacterBuilder
    {
        ICharacterBuilder SetName(string name);
        ICharacterBuilder SetClass(string characterClass);
        ICharacterBuilder SetStrength(int value);
        ICharacterBuilder SetAgility(int value);
        ICharacterBuilder SetIntelligence(int value);
        ICharacter Build();
    }

    public class CharacterBuilder : ICharacterBuilder
    {
        private Character _character = new Character();
        public ICharacterBuilder SetName(string name)
        {
            _character.Name = name;
            return this;
        }

        public ICharacterBuilder SetClass(string characterClass)
        {
            _character.Class = characterClass;
            return this;
        }

        public ICharacterBuilder SetStrength(int value)
        {
            _character.Strength = value;
            return this;
        }

        public ICharacterBuilder SetAgility(int value)
        {
            _character.Agility = value;
            return this;
        }
        public ICharacterBuilder SetIntelligence(int value)
        {
            _character.Intelligence = value;
            return this;
        }

        public ICharacter Build()
        {
            var result = _character;

            _character = new Character();

            return result;
        }
    }

    public class CharacterDirector
    {
        public ICharacter CreateWarrior(ICharacterBuilder builder)
        {
            return builder
                .SetName("Warrior")
                .SetClass("Tank")
                .SetStrength(10)
                .SetAgility(3)
                .SetIntelligence(1)
                .Build();
        }

        public ICharacter CreateMage(ICharacterBuilder builder)
        {
            return builder
                .SetName("Mage")
                .SetClass("Caster")
                .SetStrength(1)
                .SetAgility(3)
                .SetIntelligence(10)
                .Build();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICharacterBuilder builder = new CharacterBuilder();
            CharacterDirector director = new CharacterDirector();

            var warrior = director.CreateWarrior(builder);
            warrior.ShowInfo();

            Console.WriteLine();

            var customCharacter = builder
                .SetName("Assassin")
                .SetClass("Rogue")
                .SetStrength(5)
                .SetAgility(10)
                .SetIntelligence(3)
                .Build();

            customCharacter.ShowInfo();

            Console.ReadLine();
        }
    }
}


