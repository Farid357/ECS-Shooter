using TMPro;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class BestScoreRecordView : MonoBehaviour, IBestScoreRecordView
    {
        [SerializeField] private TMP_Text _text;
        
        public void Show(int record)
        {
            _text.text = record.ToString();
        }
    }
}