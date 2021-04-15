using FifthTask.Logic.Components.Expressions.Helpers;
using FifthTask.Logic.Components.Expressions.Interfaces;

namespace FifthTask.Logic.Components.Expressions.Nonterminal
{
    public class ThousandNumbersExpression : IExpression
    {
        private const string NUMBER_CLASS = "thousand";

        private IExpression _number;
        private IExpression _hundredNumberExpression;

        public ThousandNumbersExpression(IExpression number, IExpression hundredNumberExpression) 
        {
            _number = number;
            _hundredNumberExpression = hundredNumberExpression;
        }

        public string Interpret(Context numberContext) => _number.Interpret(numberContext) switch
        {
            "0" or "00" or "000" => _hundredNumberExpression.Interpret(numberContext),
            _ => $"{NonterminalExpressionHelper.GetHundredInerpret(_number.Interpret(numberContext))} {NUMBER_CLASS} " +
                    $"{_hundredNumberExpression.Interpret(numberContext)}"
        };
    }
}
