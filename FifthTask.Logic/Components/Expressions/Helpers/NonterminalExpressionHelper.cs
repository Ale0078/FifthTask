using System;

using FifthTask.Logic.Components.Expressions.Terminal;
using FifthTask.Logic.Components.Expressions.Interfaces;
using FifthTask.Logic.Components.Expressions.Nonterminal;

namespace FifthTask.Logic.Components.Expressions.Helpers
{
    internal class NonterminalExpressionHelper
    {
        public static string GetHundredInerpret(string numberToContext) 
        {
            string[] numbersToContext = new string[numberToContext.Length];
            IExpression[] exprassions = new IExpression[numbersToContext.Length];

            for (int i = numberToContext.Length - 1; i >= 0; i--)
            {
                numbersToContext[i] = Convert.ToString(numberToContext[i]);
                exprassions[i] = new NumberExpression(i);
            }

            Context context = new(numbersToContext);

            return (numbersToContext.Length) switch
            {
                1 => new OneNumbersExpression(exprassions[0]).Interpret(context),
                2 => new TenNumbersExpression(exprassions[0],
                        oneNumberExpression: new OneNumbersExpression(exprassions[1])).Interpret(context),
                3 => new HundredNumbersExpression(exprassions[0],
                        tenNumberExpression: new TenNumbersExpression(exprassions[1],
                        oneNumberExpression: new OneNumbersExpression(exprassions[2]))).Interpret(context),
                _ => throw new FormatException("numberToContext must be number from 999 to 0")
            };
        }
    }
}
