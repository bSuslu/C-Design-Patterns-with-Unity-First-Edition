using UnityEngine;

namespace TurnBaseRPG
{
    public class UnitStats : MonoBehaviour
    {
        public int Health;
        private Renderer _renderer;

        void Start()
        {
            _renderer = this.GetComponent<Renderer>();
        }

        public bool TakeDamage(int value)
        {
            Health -= value;
            return Health == 0;
        }

        public void Heal()
        {
            Health++;
        }

        public void ChangeColor(Color newColor)
        {
            _renderer.material.SetColor("_Color", newColor);
        }
    }
}