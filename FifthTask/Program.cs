using System;

using FifthTask.Controllers;
using FifthTask.Views;
using FifthTask.Models;
using FifthTask.Logic.Components;
using FifthTask.Logic.Components.Expressions.Interfaces;
using FifthTask.Logic.Components.Expressions.Nonterminal;
using FifthTask.Logic.Components.Expressions.Terminal;

Context context = new Context("990", "919", "4", "0", "9");

IExpression number1 = new NumberExpression(0);
IExpression number2 = new NumberExpression(1);
IExpression number3 = new NumberExpression(2);
IExpression number4 = new NumberExpression(3);
IExpression number5 = new NumberExpression(4);

IExpression expression = new MillionNumbersExpression(number1,
    thousandNumbersExpression: new ThousandNumbersExpression(number2,
    hundredNumberExpression: new HundredNumbersExpression(number3,
    tenNumberExpression: new TenNumbersExpression(number4,
    oneNumberExpression: new OneNumbersExpression(number5)))));

Console.WriteLine(expression.Interpret(context));

NumberController n = new NumberController(new NumberView(new NumberViewModel()));
n.SetModel("9990");
n.Display();