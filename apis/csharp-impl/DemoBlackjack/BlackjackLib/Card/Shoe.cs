namespace BlackjackLib.Card;

public class Shoe
{
    private Dictionary<Card, byte> cardCountTracker = [];

    public Shoe(byte nDecks)
    {
        foreach (Card card in Card.AllCards)
        {
            this.cardCountTracker.Add(card, nDecks);
        }
    }
}
