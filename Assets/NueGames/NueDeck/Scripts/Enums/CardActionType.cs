namespace NueGames.NueDeck.Scripts.Enums
{
    public enum CardActionType
    {
        Attack,
        Heal,
        Block,
        IncreaseStrength,
        IncreaseMaxHealth,
        Draw,
        EarnMana,
        LifeSteal,
        Stun,
        Exhaust,
        Gassed, //new one for the task
        CardDeckActionImproveValue, //for improving effects of different actions of the current cards
        CardNameImproveValue, //for improving effects of cards by their name
        CreateCardsByName //for creating new cards
    }
}