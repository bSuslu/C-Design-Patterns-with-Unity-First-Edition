
using System.Collections;

namespace TurnBaseRPG
{
    public abstract class State
    {
        public virtual void Initialize() { }
    
        public virtual IEnumerator Enter() { yield break; } 
    
        public virtual void HandleInput() { }
    
        public virtual void CheckState() { }
    
        public virtual IEnumerator Exit() { yield break; }
    }
}