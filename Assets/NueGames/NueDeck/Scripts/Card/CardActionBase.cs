using NueGames.NueDeck.Scripts.Characters;
using NueGames.NueDeck.Scripts.Data.Collection;
using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.Managers;

namespace NueGames.NueDeck.Scripts.Card
{
    public class CardActionParameters
    {
        public readonly float Value;
        public readonly string NameTarget;
        public readonly CardActionType TargetCardActionType;
        public readonly CharacterBase TargetCharacter;
        public readonly CharacterBase SelfCharacter;
        public readonly CardData CardData;
        public readonly CardBase CardBase;
        public readonly CardActionData CardActionData;
        public CardActionParameters(float value, string nameTarget, CardActionType targetCardActionType, CharacterBase targetCharacter, CharacterBase self,CardData cardData, CardBase cardBase, CardActionData cardActionData)
        {
            Value = value;
            NameTarget = nameTarget;
            TargetCharacter = targetCharacter;
            TargetCardActionType = targetCardActionType; //for new card actions improving in the deck
            SelfCharacter = self;
            CardData = cardData;
            CardBase = cardBase;
            CardActionData = cardActionData;
        }
    }
    public abstract class CardActionBase
    {
        protected CardActionBase(){}
        public abstract CardActionType ActionType { get;}
        public abstract void DoAction(CardActionParameters actionParameters);
        
        protected FxManager FxManager => FxManager.Instance;
        protected AudioManager AudioManager => AudioManager.Instance;
        protected GameManager GameManager => GameManager.Instance;
        protected CombatManager CombatManager => CombatManager.Instance;
        protected CollectionManager CollectionManager => CollectionManager.Instance;
        
    }
    
    
   
}