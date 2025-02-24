
namespace TurnBaseRPG
{
    public class BaseBattleState : State
    {
        protected BattleStateMachine _stateMachine;
    
        public BaseBattleState(BattleStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
    }
}