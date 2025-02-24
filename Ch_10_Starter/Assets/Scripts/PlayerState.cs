using System.Collections;
using UnityEngine;

namespace TurnBaseRPG
{
    public class PlayerState : BaseBattleState
    {
        private bool _isGameEnded;
        private int _movesLeft;

        public PlayerState(BattleStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override IEnumerator Enter()
        {
            Debug.Log("Player's turn");
            Manager.Instance.Player.ChangeColor(Color.green);
            _movesLeft = 1;
            yield break;
        }

        public override void HandleInput()
        {
            if (_movesLeft < 1)
                return;

            if (Input.GetKeyDown(KeyCode.A))
            {
                _movesLeft--;
                _isGameEnded = Manager.Instance.Enemy.TakeDamage(1);
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                _movesLeft--;
                Manager.Instance.Player.Heal();
            }
        }

        public override void CheckState()
        {
            if (_isGameEnded)
            {
                _stateMachine.ChangeState(_stateMachine.End);
            }
            else if (_movesLeft < 1)
            {
                _stateMachine.ChangeState(_stateMachine.EnemyTurn);
            }
        }
        
        public override IEnumerator Exit()
        {
            yield return new WaitForSeconds(1);
            Debug.Log("Player's turn ended");
            Manager.Instance.Player.ChangeColor(Color.blue);
        }
    }
}