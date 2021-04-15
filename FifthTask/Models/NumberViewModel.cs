using FifthTask.Logic.UserInterface.Abstracts;
using FifthTask.Logic.Components.Expressions.Interfaces;

namespace FifthTask.Models
{
    public class NumberViewModel : Model
    {
        public override void SetExpression(IExpression numberConvector)
        {
            NumberConvector = numberConvector;
        }
    }
}
