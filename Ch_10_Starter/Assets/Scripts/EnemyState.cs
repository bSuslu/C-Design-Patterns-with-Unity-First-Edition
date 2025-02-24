using System.Collections;
using UnityEngine;
namespace TurnBaseRPG
{
    public class EnemyState : BaseBattleState
    {
        private bool _isGameEnded;
        private int _movesLeft;
        
        public EnemyState(BattleStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override IEnumerator Enter()
        {
            Debug.Log("Enemy's turn");
            Manager.Instance.Enemy.ChangeColor(Color.green);
            _movesLeft = 1;
            
            yield return new WaitForSeconds(1);
            
            _isGameEnded = Manager.Instance.Player.TakeDamage(1);
            _movesLeft--;
        }

        public override void CheckState()
        {
            if (_isGameEnded)
            {
                _stateMachine.ChangeState(_stateMachine.End);
            }
            else if (_movesLeft < 1)
            {
                _stateMachine.ChangeState(_stateMachine.PlayerTurn);
            }
        }

        public override IEnumerator Exit()
        {
            yield return new WaitForSeconds(1);
            Debug.Log("Enemy's turn ended");
            Manager.Instance.Enemy.ChangeColor(Color.magenta);
        }
    }
}