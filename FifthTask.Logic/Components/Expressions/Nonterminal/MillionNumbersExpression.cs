using FifthTask.Logic.Components.Expressions.Helpers;
using FifthTask.Logic.Components.Expressions.Interfaces;

namespace FifthTask.Logic.Components.Expressions.Nonterminal
{
    public class MillionNumbersExpression : IExpression
    {
        private const string NUMBER_CLASS = "million";

        private readonly IExpression _number;
        private readonly IExpression _thousandNumbersExpression;

        public MillionNumbersExpression(IExpression number, IExpression thousandNumbersExpression) 
        {
            _number = number;
            _thousandNumbersExpression = thousandNumbersExpression;
        }

        public string Interpret(Context numberContext) => _number.Interpret(numberContext) switch
        {
            "0" or "00" or "000" => _thousandNumbersExpression.Interpret(numberContext),
            _ => $"{NonterminalExpressionHelper.GetHundredInerpret(_number.Interpret(numberContext))} {NUMBER_CLASS} " +
                    $"{_thousandNumbersExpression.Interpret(numberContext)}"
        };
    }
}
