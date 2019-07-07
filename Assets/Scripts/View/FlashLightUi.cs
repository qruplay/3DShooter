using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class FlashLightUi : MonoBehaviour
    {
        private Image _progressBar;
        
        private void Start()
        {
            _progressBar = GetComponent<Image>();
        }

        public float Energy
        {
            get => _progressBar.fillAmount;
            set => _progressBar.fillAmount = value;
        }
    }
}