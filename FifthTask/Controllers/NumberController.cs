using System;
using System.Text;
using NLog;

using FifthTask.Messages;
using FifthTask.Logic.Components;
using FifthTask.Logic.UserInterface.Abstracts;
using FifthTask.Logic.Components.Expressions.Interfaces;
using FifthTask.Logic.Components.Expressions.Nonterminal;
using FifthTask.Logic.Components.Expressions.Terminal;

namespace FifthTask.Controllers
{
    public class NumberController : Controller
    {
        private readonly ILogger _logger;
        private Context _expressionContext;

        public NumberController(View numberView) : base(numberView) 
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public override void Display()
        {
            ViewToDisplay.Display(_expressionContext);

            _logger.Info(LogMessage.DISPLAY);
        }

        public override void SetModel(string numberToConvert)
        {
            _expressionContext = new Context(SetNumbersToConext(numberToConvert));

            _logger.Info(LogMessage.SET_MODEL_CONTEXT);

            IExpression[] numbersToExpression = new IExpression[_expressionContext.Numbers.Length];

            for (int i = 0; i < numbersToExpression.Length; i++)
            {
                numbersToExpression[i] = new NumberExpression(i);
            }

            ViewToDisplay.ViewModel.SetExpression(CreateExpression(numbersToExpression.Length, numbersToExpression));

            _logger.Info(LogMessage.SET_MODEL_MODEL);
        }

        private IExpression CreateExpression(int digitCapacity, IExpression[] numbersToExpression) => digitCapacity switch
        {
            1 => new OneNumbersExpression(numbersToExpression[0]),
            2 => new TenNumbersExpression(numbersToExpression[0],
                    oneNumberExpression: new OneNumbersExpression(numbersToExpression[1])),
            3 => new HundredNumbersExpression(numbersToExpression[0],
                    tenNumberExpression: new TenNumbersExpression(numbersToExpression[1],
                    oneNumberExpression: new OneNumbersExpression(numbersToExpression[2]))),
            4 => new ThousandNumbersExpression(numbersToExpression[0],
                    hundredNumberExpression: new HundredNumbersExpression(numbersToExpression[1],
                    tenNumberExpression: new TenNumbersExpression(numbersToExpression[2],
                    oneNumberExpression: new OneNumbersExpression(numbersToExpression[3])))),
            5 => new MillionNumbersExpression(numbersToExpression[0],
                    thousandNumbersExpression: new ThousandNumbersExpression(numbersToExpression[1],
                    hundredNumberExpression: new HundredNumbersExpression(numbersToExpression[2],
                    tenNumberExpression: new TenNumbersExpression(numbersToExpression[3],
                    oneNumberExpression: new OneNumbersExpression(numbersToExpression[4]))))),
            _ => throw new FormatException(UserMessage.VALUE_OF_NUMBER)
        };

    private string[] SetNumbersToConext(string numberToConvert) 
        {
            StringBuilder builder = new();

            string[] numbersToContext = numberToConvert.Length switch
            {
                1 => new string[(int)Math.Ceiling(numberToConvert.Length / 3.0)],
                2 => new string[(int)Math.Ceiling(numberToConvert.Length / 3.0) + 1],
                _ => new string[(int)Math.Ceiling(numberToConvert.Length / 3.0) + 2]
            };

            for (int i = 1; i <= 3; i++)
            {
                numbersToContext[^i] = Convert.ToString(numberToConvert[^i]);

                if (i == numbersToContext.Length) 
                {
                    break;
                }
            }

            int j = 4;
            for (int i = 4; i <= numberToConvert.Length; i++)
            {
                builder.Append(Convert.ToString(numberToConvert[^i]));

                if (builder.Length == 3 || i == numberToConvert.Length)
                {
                    char[] tempNumbers = builder.ToString().ToCharArray();
                    Array.Reverse(tempNumbers);
                    numbersToContext[^j] = new string(tempNumbers);

                    builder.Clear();
                    j++;
                }
            }

            return numbersToContext;
        }
    }
}
