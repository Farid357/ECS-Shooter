using TMPro;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class WalletView : MonoBehaviour, IWalletView
    {
        [SerializeField] private TMP_Text _text;
        
        public void Show(int money)
        {
            _text.text = money.ToString();
        }
    }
}