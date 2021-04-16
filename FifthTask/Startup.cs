using System;
using NLog;

using static System.Console;

using FifthTask.Controllers;
using FifthTask.Models;
using FifthTask.Views;
using FifthTask.Logic.UserInterface.Abstracts;
using LibToTasks.Builders;
using LibToTasks.Validation.Interfaces;

namespace FifthTask
{
    public class Startup
    {        
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
                WriteLine(MIN_RANGE);

                _logger.Info("Program is finalized");

                return;
            }

            Controller numberController = new NumberController(
                numberView: new NumberView(
                    viewModel: new NumberViewModel()));

            numberController.SetModel(args[0]);

            numberController.Display();

            _logger.Info("Program is finalized");
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
            WriteLine("You must enter only one number from 999999999 to 000000000");

            _logger.Error("You must enter only one number number from 999999999 to 000000000");
            _logger.Info("Program is finalized");
        }
    }
}
