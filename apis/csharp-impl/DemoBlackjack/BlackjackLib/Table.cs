using System.Collections.Immutable;
using BlackjackLib.CardSystem;

namespace BlackjackLib;

public class Table(TableConfiguration config)
{
    public Hand DealerHand { get; } = new Hand();
    public List<TablePosition> Positions { get; } = [];
    public TableConfiguration Configuration { get; } = config;

    public Player[] Participants
    {
        get => [.. this.Positions.Select(pos => pos.Owner).ToImmutableHashSet()];
    }

    private static Func<Card, byte[]> CardValueMap => card => card.Rank switch
    {
        Rank.Ace => [1, 11],
        Rank.Numerical n => [n.Num],
        _ when card.Rank.IsFaceCard() => [10],
        _ => throw new ArgumentException(),
    };

    public void TryAddPosition(TablePosition position)
    {
        if (this.Positions.Count >= this.Configuration.MaxPositions)
        {
            throw new MaxPositionsAtTableReachedException();
        }

        this.Positions.Append(position);
    }
}

public class MaxPositionsAtTableReachedException : Exception
{
    public MaxPositionsAtTableReachedException() : base()
    {
    }

    public MaxPositionsAtTableReachedException(string? message) : base(message)
    {
    }

    public MaxPositionsAtTableReachedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
