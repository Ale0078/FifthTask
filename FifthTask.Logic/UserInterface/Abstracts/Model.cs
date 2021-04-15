using FifthTask.Logic.Components.Expressions.Interfaces;

namespace FifthTask.Logic.UserInterface.Abstracts
{
    public abstract class Model
    {
        public IExpression NumberConvector { get; protected set; }

        public abstract void SetExpression(IExpression numberConvector);
    }
}
