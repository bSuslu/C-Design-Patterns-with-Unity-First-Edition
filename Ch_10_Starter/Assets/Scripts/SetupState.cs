using System.Collections;
using UnityEngine;

namespace TurnBaseRPG
{
    public class SetupState : BaseBattleState
    {
        public SetupState(BattleStateMachine stateMachine) : base(stateMachine) { }

        public override IEnumerator Enter()
        {
            Debug.Log("Setting up ");
            yield return new WaitForSeconds(2);
            _stateMachine.ChangeState(_stateMachine.PlayerTurn);
        }
        
        public override IEnumerator Exit()
        {
            Debug.Log("Finishing setup");
            yield break;
        }
    }
}