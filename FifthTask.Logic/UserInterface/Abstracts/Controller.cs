namespace FifthTask.Logic.UserInterface.Abstracts
{
    public abstract class Controller
    {
        public View ViewToDisplay { get; }

        public Controller(View viewToDisplay) 
        {
            ViewToDisplay = viewToDisplay;
        }

        public abstract void SetModel(string numberToConvert);
        public abstract void Display();
    }
}
