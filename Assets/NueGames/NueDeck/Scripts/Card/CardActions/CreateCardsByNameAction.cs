using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.Managers;
using NueGames.NueDeck.Scripts.Data.Settings;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    public class CreateCardsByNameAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.CreateCardsByName;
        public override void DoAction(CardActionParameters actionParameters)
        {
            Data.Collection.CardData cardToAdd = ScriptableObject.CreateInstance<Data.Collection.CardData>(); //we create an empty cardData
            foreach(Data.Collection.CardData card in GameManager.Instance.GameplayData.AllCardsList) //check every cardData in AllCardsList
            {
                if (card.CardName == actionParameters.NameTarget) //compare names
                {
                    cardToAdd = card; //if success, assign the card data to our new variable
                }
            }
            for (int i = 0; i < actionParameters.Value; i++) //here we define how many new cards should be added
            {
                Data.Collection.CardData cardInstance = GameObject.Instantiate(cardToAdd); // create a separate instance of our card
                GameManager.Instance.PersistentGameplayData.CurrentCardsList.Add(cardInstance); //add the cards in the list of the cards
                var clone = GameManager.BuildAndGetCard(cardInstance, CollectionManager.Instance.HandController.drawTransform); //build a card object
                CollectionManager.Instance.HandController.AddCardToHand(clone); //transform this object to the hand
                CollectionManager.Instance.HandPile.Add(cardInstance); //distribute them into the collections, in this case they go into HandPile
                UIManager.Instance.CombatCanvas.SetPileTexts(); //sets ui pile texts

            foreach (var cardObject in CollectionManager.Instance.HandController.hand)
                cardObject.UpdateCardText(); //updates texts of each card
            }
        }
    }
}
