using FifthTask.Logic.Components.Expressions.Interfaces;

namespace FifthTask.Logic.Components.Expressions.Terminal
{
    internal class NumberExpretion : IExpression
    {
        public long IndexContextNumber { get; }

        public NumberExpretion(long indexContextNumber) 
        {
            IndexContextNumber = indexContextNumber;
        }

        public string Interpret(Context numberContext) 
        {
            return numberContext.Numbers[IndexContextNumber];
        }
    }
}
