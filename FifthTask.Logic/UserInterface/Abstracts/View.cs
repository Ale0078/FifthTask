using FifthTask.Logic.Components;
using FifthTask.Logic.Components.Expressions.Interfaces;

namespace FifthTask.Logic.UserInterface.Abstracts
{
    public abstract class View
    {
        public IExpression ViewModel { get; set; }

        public abstract void Display(Context numberContext);
    }
}
