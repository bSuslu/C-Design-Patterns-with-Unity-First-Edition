
namespace TurnBaseRPG
{
    public class BattleStateMachine : StateMachine
    {
        public State Setup;
        public State PlayerTurn;
        public State EnemyTurn;
        public State End;

        private void Start()
        {
            Setup = new SetupState(this);
            PlayerTurn = new PlayerState(this);
            EnemyTurn = new EnemyState(this);
            End = new EndState(this);
            ChangeState(Setup);
        }
    }
}