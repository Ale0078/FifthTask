using FifthTask.Logic.UserInterface.Abstracts;
using FifthTask.Logic.Components.Expressions.Interfaces;

namespace FifthTask.Models
{
    public class ViewModel : Model
    {
        public override void SetExpression(IExpression numberConvector)
        {
            NumberConvector = numberConvector;
        }
    }
}
