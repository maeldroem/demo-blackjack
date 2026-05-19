namespace BlackjackLib.CardSystem;

public class Shoe
{
    // The reason why we use a stack of shuffled cards rather than a hash map tracking the count
    // of each possible card is because we need to rapidly deal cards while counting the shoe
    // is a rare operation
    private readonly Stack<Card> cardStack;

    public byte NumDecks { get; }
    public uint NumCardsRemaining { get => (uint)this.cardStack.Count; }

    public Shoe(byte numDecks)
    {
        this.NumDecks = numDecks;
        this.cardStack = new(Card.AllCards.Count * this.NumDecks);
        this.Reset();
    }

    public void Reset()
    {
        this.cardStack.Clear();

        for (byte i = 0; i < NumDecks; i++)
        {
            foreach (Card card in Card.AllCards.ToArray().Shuffle())
            {
                this.cardStack.Push(card);
            }
        }
    }

    public Card? Deal()
    {
        this.cardStack.TryPop(out Card? cardOut);
        return cardOut;
    }
}
