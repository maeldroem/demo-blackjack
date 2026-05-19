namespace BlackjackLib.CardSystem;

public enum Suit
{
    Diamond,
    Club,
    Heart,
    Spade,
}

public static class SuitExtension
{
    extension(Suit suit)
    {
        public bool IsRed() => suit is Suit.Diamond or Suit.Heart;
        public bool IsBlack() => suit is Suit.Club or Suit.Spade;
    }
}
