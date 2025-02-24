using System;
using UnityEngine;

namespace TurnBaseRPG
{
    [RequireComponent(typeof(Manager))]
    public class BattleClient : MonoBehaviour
    {
        private BattleStateMachine _stateMachine;
        
        private void Start()
        {
            _stateMachine = GetComponent<BattleStateMachine>();
            
        }

        private void Update()
        {
            _stateMachine.CheckState();
            _stateMachine.HandleInput();
        }
    }
}