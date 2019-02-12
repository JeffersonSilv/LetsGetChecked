namespace LetsGetChecked.Concrete
{
    public class BoardExitInformation
    {
        public Tile Position { get; set; }

        public BoardExitInformation(Tile position)
        {
            Position = position;
        }
    }
}