using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    public class GassedAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.Gassed;
        public override void DoAction(CardActionParameters actionParameters)
        {
            var newTarget = actionParameters.TargetCharacter;

            if (!newTarget) return;

            newTarget.CharacterStats.ApplyStatus(StatusType.Gassed, Mathf.RoundToInt(actionParameters.Value));

            if (FxManager != null)
                FxManager.PlayFx(newTarget.transform, FxType.Poison);

            if (AudioManager != null)
                AudioManager.PlayOneShot(AudioActionType.Poison);
        }
    }
}
