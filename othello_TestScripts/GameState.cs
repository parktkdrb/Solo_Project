using System.Collections.Generic;


public class GameState
{
    public const int Rows = 8;
    public const int Cols = 8;

    public Player[,] Board { get; }
    public Dictionary<Player, int> DiscCount { get; }
    public Player CurrentPlayer { get; private set; }
    public bool Gameover { get; private set; }
    public Player Winner { get; private set; }
    public Dictionary<Position, List<Position>> LegalMove { get; private set; }

    public GameState()
    {
        Board = new Player[Rows, Cols];
        Board[3, 3] = Player.White;
        Board[3, 4] = Player.Black;
        Board[4, 3] = Player.Black;
        Board[4, 4] = Player.White;

        DiscCount = new Dictionary<Player, int>()
        {
            {Player.Black, 2},
            {Player.White, 2},
        };

        CurrentPlayer = Player.Black;
        LegalMove = FindLegalMoves(CurrentPlayer);
    }

    public bool MakeMove(Position pos, out Move moveInfo)
    {
        if (!LegalMove.ContainsKey(pos))
        {
            moveInfo = null;
            return false;
        }

        Player movePlayer = CurrentPlayer;
        List<Position> outflanked = LegalMove[pos];

        Board[pos.Row, pos.Col] = movePlayer;
        FlipDiscs(outflanked);
        UpdateDiscCounts(movePlayer, outflanked.Count);
        passTurn();

        moveInfo = new Move { Player = movePlayer, Position = pos, Outflacked = outflanked };
        return true;
    }
    public IEnumerable<Position> OccupiedPositions()
    {
        for(int r = 0; r< Rows; r++)
        {
            for(int c = 0; c < Cols; c++)
            {
                if (Board[r, c] != Player.None)
                {
                    yield return new Position(r, c);
                }
            }
        }
    }

    private void FlipDiscs(List<Position> positions)
    {
        foreach(Position pos in positions)
        {
            Board[pos.Row, pos.Col] = Board[pos.Row, pos.Col].opponent();
        }
    }

    private void UpdateDiscCounts(Player movePlayer, int outflankedCount)
    {
        DiscCount[movePlayer] += outflankedCount + 1;
        DiscCount[movePlayer.opponent()] -= outflankedCount;
    }

    private void ChangePlayer()
    {
        CurrentPlayer = CurrentPlayer.opponent();
        LegalMove = FindLegalMoves(CurrentPlayer); 
    }
    private Player FindWinner()
    {
        if (DiscCount[Player.Black] > DiscCount[Player.White])
        {
            return Player.Black;
        }
        if (DiscCount[Player.White] > DiscCount[Player.Black])
        {
            return Player.White;
        }
        return Player.None;
    }

    private void passTurn()
    {
        ChangePlayer();

        if(LegalMove.Count  > 0)
        {
            return;
        }

        ChangePlayer();

        if (LegalMove.Count == 0)
        {
            CurrentPlayer = Player.None;
            Gameover = true;
            Winner = FindWinner();

        }
    }

    private bool IsInsideBoard(int r, int c)
    {
        return r >= 0 && r < Rows && r < Cols;
    }

    private List<Position> OutflankedInDir(Position pos, Player player, int rDelta, int cDelta)
    {
        List<Position> outflanked = new List<Position>();
        int r = pos.Row + rDelta;
        int c = pos.Col + cDelta;
        while(IsInsideBoard(r, c) && Board[r, c] != Player.None)
        {
            if (Board[r, c] == player.opponent())
            {
                outflanked.Add(new Position(r, c));
                r += rDelta;
                c += cDelta;
            }
            else
            {
                return outflanked;
            }
        }
        return new List<Position>();
    }

    private List<Position> Outflanked(Position pos, Player player)
    {
        List<Position> outflaned = new List<Position>();

        for(int rDelta = -1; rDelta <= 1; rDelta++)
        {
            for (int cDelta = -1; cDelta <= -1; cDelta++)
            {
                if(rDelta == 0 && cDelta == 0)
                {
                    continue;
                }
                outflaned.AddRange(OutflankedInDir(pos, player, rDelta, cDelta));
            }
        }

        return outflaned;
    }

    private bool IsMoveLegal(Player player, Position pos, out List<Position> outflanked)
    {
        if (Board[pos.Row, pos.Col] != Player.None)
        {
            outflanked = null;
            return false;
        }
        outflanked = Outflanked(pos, player);
        return outflanked.Count > 0;
    }

    private Dictionary<Position, List<Position>> FindLegalMoves(Player player)
    {
        Dictionary<Position, List<Position>> legalMoves = new Dictionary<Position, List<Position>>();
        for (int r = 0; r < Rows; r++)
        {
            for(int c = 0; c < Cols; c++)
            {
                Position pos = new Position(r, c);
                if (IsMoveLegal(player, pos, out List<Position> outflanked))
                {
                    legalMoves[pos] = outflanked;
                }
            }
        }
        return legalMoves;
    }


}
