using FifthTask.Logic.Components;

namespace FifthTask.Logic.UserInterface.Abstracts
{
    public abstract class View
    {
        public Model ViewModel { get; }

        public View(Model viewMolde) 
        {
            ViewModel = viewMolde;
        }

        public abstract void Display(Context numberContext);
    }
}
