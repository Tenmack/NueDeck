﻿using NueDeck.Scripts.Enums;
using UnityEngine;

namespace NueDeck.Scripts.EnemyBehaviour.EnemyActions
{
    public class EnemyBlockAction : EnemyActionBase
    {
        public override EnemyActionType ActionType => EnemyActionType.Block;
        
        public override void DoAction(EnemyActionParameters actionParameters)
        {
            if (actionParameters.targetCharacter)
            {
                actionParameters.targetCharacter.CharacterStats.ApplyStatus(StatusType.Block,Mathf.RoundToInt(actionParameters.value));
            }
            else
            {
                actionParameters.selfCharacter.CharacterStats.ApplyStatus(StatusType.Block,Mathf.RoundToInt(actionParameters.value));
            }
        }
    }
}