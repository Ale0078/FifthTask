using System.Collections.Generic;

using FifthTask.Logic.Components.Expressions.Interfaces;

namespace FifthTask.Logic.Components.Expressions.Nonterminal
{
    public class TenNumbersExpression : IExpression
    {
        private readonly Dictionary<string, string> _tenNumbers = new()
        {
            { "1", "ten" },
            { "2", "twenty" },
            { "3", "thirthty" },
            { "4", "forty" },
            { "5", "fifty" },
            { "6", "sixty" },
            { "7", "seventy" },
            { "8", "eighty" },
            { "9", "ninety" }
        };

        private readonly Dictionary<string, string> _alternativeTenNumbers = new()
        {
            { "1", "eleven" },
            { "2", "twelve" },
            { "3", "thirteen" }
        };

        private readonly IExpression _number;
        private readonly IExpression _oneNumberExpression;

        public TenNumbersExpression(IExpression number, IExpression oneNumberExpression) 
        {
            _number = number;
            _oneNumberExpression = oneNumberExpression;
        }

        public string Interpret(Context numberContext) => _number.Interpret(numberContext) switch 
        {
            "0" => _oneNumberExpression.Interpret(numberContext),
            "1" => (_oneNumberExpression.Interpret(numberContext)) switch
            {
                "zero" => _tenNumbers["1"],
                "one" => _alternativeTenNumbers["1"],
                "two" => _alternativeTenNumbers["2"],
                "three" => _alternativeTenNumbers["3"],
                "eight" => _oneNumberExpression.Interpret(numberContext) + "een",
                _ => _oneNumberExpression.Interpret(numberContext) + "teen",
            },
            _ => _tenNumbers[_number.Interpret(numberContext)] + 
                    (_oneNumberExpression.Interpret(numberContext) == "zero" ? "" : " " + _oneNumberExpression.Interpret(numberContext)),
        };
    }    
}
