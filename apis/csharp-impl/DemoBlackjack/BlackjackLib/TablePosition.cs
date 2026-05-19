namespace BlackjackLib;

public class TablePosition(Player owner)
{
    public BettingBox Bets { get; } = new();
    public Hand Hand { get; } = new();
    public Player Owner { get; } = owner;
}
