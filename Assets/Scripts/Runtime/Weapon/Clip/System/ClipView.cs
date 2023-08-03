using TMPro;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class ClipView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        public void Show(int bullets, int totalBullets)
        {
            _text.text = $"{bullets}/{totalBullets}";
        }
    }
}