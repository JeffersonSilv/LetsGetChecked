using LetsGetChecked.Abstract;

namespace LetsGetChecked.Concrete
{
    public class Tile : ITile
    {
        public Direction Direction { get; private set; }

        public void SetDirection(Direction direction)
        {
            Direction = direction;
        }
        
        public int X { get; set; }
        public int Y { get; set; }
    }
}