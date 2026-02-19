using System;
using System.Text;

namespace RandomLib
{
    public class  RandomStringGenerator
    {
        private Random random = new Random();
        private string symbols = "abcdef0123456789";

        public string Generate(int length)
        {
            string result = "";

            for(int i = 0; i < length; i++)
            {
                int index = random.Next(symbols.Length);
                result += symbols[index];
            }

            return result;
        }
    }

    public class RandomNumberGenerator
    {
        private Random random = new Random();
        public int Generate(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}