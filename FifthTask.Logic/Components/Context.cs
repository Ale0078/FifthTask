using System.Collections.Generic;

namespace FifthTask.Logic.Components
{
    public class Context
    {
        public Dictionary<string, string> DictionaryNumbers { get; }
        public string[] Numbers { get; }

        public Context(params string[] numbers)
        {
            Numbers = numbers;

            DictionaryNumbers = new()
            {                
                { "1", "one" },
                { "2", "two" },
                { "3", "three" },
                { "4", "four" },
                { "5", "five" },
                { "6", "six" },
                { "7", "seven" },
                { "8", "eight" },
                { "9", "nine" }
            };
        }
    }
}
