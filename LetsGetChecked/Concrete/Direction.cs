using System.ComponentModel;

namespace LetsGetChecked.Concrete
{
    public enum Direction
    {
        [Description("N")]
        North,
        [Description("E")]
        East,
        [Description("S")]
        South,
        [Description("W")]
        West
    }
}