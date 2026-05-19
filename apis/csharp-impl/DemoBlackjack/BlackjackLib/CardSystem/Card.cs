using System.Collections.Immutable;

namespace BlackjackLib.CardSystem;

public record Card(Suit Suit, Rank Rank)
{
    public static ImmutableHashSet<Card> AllCards =
        Enum.GetValues<Suit>()
            .Zip(Rank.AllRanks)
            .Select(suitRankTuple => new Card(suitRankTuple.First, suitRankTuple.Second))
            .AsParallel()
            .ToImmutableHashSet();
}
