using static System.Console;

using FifthTask.Logic.UserInterface.Abstracts;
using FifthTask.Logic.Components;

namespace FifthTask.Views
{
    public class NumberView : View
    {
        public NumberView(Model viewModel) : base(viewModel) 
        {
        }

        public override void Display(Context numberContext)
        {
            WriteLine(ViewModel.NumberConvector.Interpret(numberContext));
        }
    }
}
