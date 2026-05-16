using System.Collections.Immutable;

namespace BlackjackLib.Card;

public abstract record Rank
{
    public static ImmutableHashSet<Rank> AllRanks =
    [
        new Rank.Ace(),
        new Rank.Numerical(2, new Rank.Numerical.UncheckedTag()),
        new Rank.Numerical(3, new Rank.Numerical.UncheckedTag()),
        new Rank.Numerical(4, new Rank.Numerical.UncheckedTag()),
        new Rank.Numerical(5, new Rank.Numerical.UncheckedTag()),
        new Rank.Numerical(6, new Rank.Numerical.UncheckedTag()),
        new Rank.Numerical(7, new Rank.Numerical.UncheckedTag()),
        new Rank.Numerical(8, new Rank.Numerical.UncheckedTag()),
        new Rank.Numerical(9, new Rank.Numerical.UncheckedTag()),
        new Rank.Numerical(10, new Rank.Numerical.UncheckedTag()),
        new Rank.Jack(),
        new Rank.Queen(),
        new Rank.King(),
    ];

    public static Rank TryFromClassicalCardValue(byte cardValue) => cardValue switch
    {
        1 => new Rank.Ace(),
        >= Rank.Numerical.Min and <= Rank.Numerical.Max => new Rank.Numerical(cardValue),
        11 => new Rank.Jack(),
        12 => new Rank.Queen(),
        13 => new Rank.King(),
        _ => throw new ArgumentOutOfRangeException(
            nameof(cardValue),
            cardValue,
            "Given classical card value is out of range"
        ),
    };

    public bool IsFaceCard() => this is Rank.Jack or Rank.Queen or Rank.King;

    public byte ClassicalCardValue
    {
        get => this switch
        {
            Rank.Ace => 1,
            Rank.Numerical numCard => numCard.Num,
            Rank.Jack => 11,
            Rank.Queen => 12,
            Rank.King => 13,
            _ => throw new ArgumentException(),
        };
    }

    public sealed record Ace : Rank;

    public sealed record Numerical : Rank
    {
        // Invariant: Numerical value must be within range 2..=10
        public const byte Min = 2;
        public const byte Max = 10;

        public byte Num;

        public Numerical(byte num) : this(num, new UncheckedTag())
        {
            if (num < Numerical.Min || num > Numerical.Max)
            {
                throw new ArgumentOutOfRangeException(nameof(num), num, "Rank numerical value outside valid range");
            }
        }

        public Numerical(byte num, UncheckedTag _)
        {
            this.Num = num;
        }

        public readonly struct UncheckedTag;
    }

    public sealed record Jack : Rank;
    public sealed record Queen : Rank;
    public sealed record King : Rank;
}
