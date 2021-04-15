using FifthTask.Logic.Components.Expressions.Interfaces;

namespace FifthTask.Logic.Components.Expressions.Nonterminal
{
    public class OneNumbersExpression : IExpression
    {
        private readonly IExpression _number;

        public OneNumbersExpression(IExpression number) 
        {
            _number = number;
        }

        public string Interpret(Context context) 
        {
            return context.DictionaryNumbers[_number.Interpret(context)];
        }
    }
}
