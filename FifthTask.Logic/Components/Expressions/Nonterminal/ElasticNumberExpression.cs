using FifthTask.Logic.Components.Expressions.Helpers;
using FifthTask.Logic.Components.Expressions.Interfaces;

namespace FifthTask.Logic.Components.Expressions.Nonterminal
{
    public class ElasticNumberExpression : IExpression
    {
        private string _numberClass;

        private IExpression _number;
        private IExpression _nonterminalExpression;

        public ElasticNumberExpression(IExpression number, string numberClass, IExpression nonterminalExpression)
        {
            _number = number;
            _numberClass = numberClass;
            _nonterminalExpression = nonterminalExpression;
        }

        public string Interpret(Context numberContext) => _number.Interpret(numberContext) switch
        {
            "0" or "00" or "000" => _nonterminalExpression.Interpret(numberContext),
            _ => $"{NonterminalExpressionHelper.GetHundredInerpret(_number.Interpret(numberContext))} {_numberClass} " +
                    $"{_nonterminalExpression.Interpret(numberContext)}"
        };
    }
}
