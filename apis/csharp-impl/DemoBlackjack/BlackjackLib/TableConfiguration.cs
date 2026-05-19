using BlackjackLib.CardSystem;

namespace BlackjackLib;

// TODO: Create TableConfigurationBuilder
// NOTE: This will contain the other game settings per milestones M3a and M3b
public class TableConfiguration(byte maxPositions, Func<Card, byte[]> cardValueMap)
{
    public byte MaxPositions { get; } = maxPositions;
    public Func<Card, byte[]> CardValueMap { get; } = cardValueMap;
}
