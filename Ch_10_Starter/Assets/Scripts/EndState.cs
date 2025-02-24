using System.Collections;
using UnityEngine;

namespace TurnBaseRPG
{
    public class EndState : BaseBattleState
    {
        public EndState(BattleStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override IEnumerator Enter()
        { 
            Debug.Log("Game ended");
            yield break;
        }
    }
}