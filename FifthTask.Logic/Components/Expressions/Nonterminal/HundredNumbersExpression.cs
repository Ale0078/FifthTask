using FifthTask.Logic.Components.Expressions.Interfaces;

namespace FifthTask.Logic.Components.Expressions.Nonterminal
{
    public class HundredNumbersExpression : IExpression
    {
        private const string NUMBER_CLASS = "hundred";

        private readonly IExpression _number;
        private readonly IExpression _tenNumberExpression;

        public HundredNumbersExpression(IExpression number, IExpression tenNumberExpression) 
        {
            _number = number;
            _tenNumberExpression = tenNumberExpression;
        }

        public string Interpret(Context numberContext) => _number.Interpret(numberContext) switch
        {
            "0" => _tenNumberExpression.Interpret(numberContext),
            _ => $"{numberContext.DictionaryNumbers[_number.Interpret(numberContext)]} {NUMBER_CLASS} {_tenNumberExpression.Interpret(numberContext)}"
        };
    }
}
