namespace LetsGetChecked.Concrete
{
    public class BoardMiningInformation
    {
        public Tile[] Mines { get; set; }

        public BoardMiningInformation(Tile[] mines)
        {
            Mines = mines;
        }
    }
}