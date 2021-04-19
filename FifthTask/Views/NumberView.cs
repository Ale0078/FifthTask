using static System.Console;

using FifthTask.Logic.UserInterface.Abstracts;
using FifthTask.Logic.Components;

namespace FifthTask.Views
{
    public class NumberView : View
    {
        public override void Display(Context numberContext)
        {
            WriteLine(ViewModel.Interpret(numberContext));
        }
    }
}
