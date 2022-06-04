public enum Player
{
    None, Black, White
}

public static class PlayerExtensions
{
    public static Player opponent(this Player player)
    {
        if(player == Player.Black)
        {
            return Player.White;
        }
        else if(player == Player.White)
        {
            return Player.Black;
        }

        return Player.None;
    }
}
