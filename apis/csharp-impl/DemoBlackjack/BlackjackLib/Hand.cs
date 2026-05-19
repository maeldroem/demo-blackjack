using System.Collections.Immutable;
using BlackjackLib.CardSystem;

namespace BlackjackLib;

public class Hand
{
    public List<Card> Cards { get; } = [];

    public bool Open = true;

    public void AddCard(Card card)
    {
        if (this.Open)
        {
            this.Cards.Append(card);
        }
    }

    public byte[] EvaluateValue(Func<Card, byte[]> cardValueMap)
    {
        return [.. Cards
            .Aggregate(
                ImmutableHashSet<byte>.Empty,
                (values, card) => [.. values
                    .SelectMany(
                        _ => cardValueMap.Invoke(card),
                        (accValue, cardValue) => (byte)(accValue + cardValue)
                    )
                ]
            )
            .Order()
        ];
    }
}
