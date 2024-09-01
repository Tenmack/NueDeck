using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    public class CardDeckActionImproveValueAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.CardDeckActionImproveValue;
        public override void DoAction(CardActionParameters actionParameters)
        { 
            foreach (Data.Collection.CardData card in GameManager.Instance.PersistentGameplayData.CurrentCardsList) //take each card in the current deck
            {
                foreach (Data.Collection.CardActionData action in card.CardActionDataList) //take each action of this card
                {
                    if (action.CardActionType == actionParameters.TargetCardActionType) //compare with needed to modify card action type
                    {
                        action.ModifyActionValue(action.ActionValue+actionParameters.Value); //edit value of this action
                    }
                }
            }
        }
    }
}