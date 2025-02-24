using System.Collections;
using UnityEngine;

namespace TurnBaseRPG
{
    public class StateMachine : MonoBehaviour
    {
        private bool _isTransitioning;
        public State CurrentState { get; private set; }
        
        public void HandleInput() => CurrentState.HandleInput();
        
        public void CheckState() => CurrentState.CheckState();
        
        public void ChangeState(State newState) => StartCoroutine(StateTransition(newState));
        
        private IEnumerator StateTransition(State newState)
        {
            if (newState == null)
            {
                Debug.LogWarning("Trying to transition to null state");
                yield break;
            }
            if (_isTransitioning)
            {
                Debug.LogWarning("Trying to transition to " + newState + "," +
                                 "But Another transition is already in progress, " +
                                 "Entering or Exiting: " + CurrentState); 
                yield break;
            }
            
            if (CurrentState == newState) 
            {
                Debug.LogWarning("Trying to transition to the same state");
                yield break;
            }
            
            _isTransitioning = true;
            
            if (CurrentState != null)
            {
                yield return StartCoroutine(CurrentState.Exit());
            }

            CurrentState = newState;
            StartCoroutine(CurrentState.Enter());
            
            _isTransitioning = false;
        }
    }
}