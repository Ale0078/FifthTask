using System;
using NLog;

using static System.Console;

using FifthTask.Controllers;
using FifthTask.Models;
using FifthTask.Views;
using FifthTask.Messages;
using FifthTask.Logic.UserInterface.Abstracts;
using LibToTasks.Builders;
using LibToTasks.Validation.Interfaces;

namespace FifthTask
{
    public class Startup
    {
        private const string ZERO = "zero";
        private const int MAX_RANGE = 999999999;
        private const int MIN_RANGE = 000000000;

        private readonly ILogger _logger;
        private readonly IValidator _validator;
        private readonly ITransformator _transformator;

        public Startup() 
        {
            _logger = LogManager.GetCurrentClassLogger();

            _validator = new DefaultValidatorBuilder().Create();
            _transformator = new DefaultTransformatorBuilder().Create();
        }

        public void Start(string[] args) 
        {
            if (args.Length != 1) 
            {
                GetMessage();

                return;
            }

            if (!uint.TryParse(args[0], out _ )) 
            {
                GetMessage();

                return;
            }

            if (!CheckingValue(args[0])) 
            {
                GetMessage();

                return;
            }

            if (int.Parse(args[0]) == 0) 
            {
                WriteLine(ZERO);

                _logger.Info(LogMessage.FINALIZED);

                return;
            }

            Controller numberController = new NumberController(
                numberView: new NumberView(
                    viewModel: new NumberViewModel()));

            numberController.SetModel(args[0]);

            numberController.Display();

            _logger.Info(LogMessage.FINALIZED);
        }

        private bool CheckingValue(string valueToCheck) 
        {
            return _validator.CheckValue(checkingValue =>
            {
                if (checkingValue > MAX_RANGE || checkingValue < MIN_RANGE)
                {
                    return false;
                }

                return true;
            }, _transformator.ConfirmConversion<int, string>(valueToCheck), false);
        }

        private void GetMessage() 
        {
            WriteLine(UserMessage.VALUE_OF_NUMBER);

            _logger.Error(UserMessage.VALUE_OF_NUMBER);
            _logger.Info(LogMessage.FINALIZED);
        }
    }
}
