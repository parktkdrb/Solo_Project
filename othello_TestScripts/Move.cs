using System.Collections.Generic;
public class Move
{
    public Player Player { get; set; }
    public Position Position { get; set; }
    public List<Position> Outflacked { get; set; }
}
