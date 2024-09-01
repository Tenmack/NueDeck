using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    public class CardNameImproveValueAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.CardNameImproveValue;
        public override void DoAction(CardActionParameters actionParameters)
        {
            foreach (Data.Collection.CardData card in GameManager.Instance.PersistentGameplayData.CurrentCardsList) //take each card in the current deck
            {
                if (card.CardName == actionParameters.NameTarget) //compare names
                {
                    foreach (Data.Collection.CardActionData action in card.CardActionDataList) //take each action of this card
                    {
                        if (action.CardActionType == actionParameters.TargetCardActionType) //compare action
                        {
                            action.ModifyActionValue(action.ActionValue + actionParameters.Value); //edit value of this action
                            return; //end if did
                        }
                    }
                    //block if there is no needed action
                    Data.Collection.CardActionData cardActionData = new Data.Collection.CardActionData();
                    cardActionData.ModifyActionType(actionParameters.TargetCardActionType);
                    cardActionData.ModifyActionTarget(actionParameters.CardActionData.ActionTargetType);
                    cardActionData.ModifyActionValue(actionParameters.Value);
                    cardActionData.ModifyActionDelay(actionParameters.CardActionData.ActionDelay);
                    card.CardActionDataList.Add(new Data.Collection.CardActionData());
                }
             }
        }
    }
 }
