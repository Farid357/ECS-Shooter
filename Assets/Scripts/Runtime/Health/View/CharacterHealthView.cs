using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter.Gameplay
{
    public class CharacterHealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private Slider _slider;
        
        public void Show(int health, int maxHealth)
        {
            float value = (float)health / maxHealth;
            _slider.DOValue(value, 0.3f);
        }
    }
}