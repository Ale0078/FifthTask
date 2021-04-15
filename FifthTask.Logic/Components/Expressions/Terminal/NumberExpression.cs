using FifthTask.Logic.Components.Expressions.Interfaces;

namespace FifthTask.Logic.Components.Expressions.Terminal
{
    internal class NumberExpression : IExpression
    {
        public long IndexContextNumber { get; }

        public NumberExpression(long indexContextNumber) 
        {
            IndexContextNumber = indexContextNumber;
        }

        public string Interpret(Context numberContext) 
        {
            return numberContext.Numbers[IndexContextNumber];
        }
    }
}
