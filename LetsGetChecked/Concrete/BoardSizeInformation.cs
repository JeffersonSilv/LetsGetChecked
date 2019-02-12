namespace LetsGetChecked.Concrete
{
    public class BoardSizeInformation
    {
        public Tile Position { get; set; }

        public BoardSizeInformation(Tile position)
        {
            Position = position;
        }
    }
}