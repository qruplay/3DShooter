using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class FlashLightUi : MonoBehaviour
    {
        private Image _progressBar;

        public float Energy
        {
            get => _progressBar.fillAmount;
            set => _progressBar.fillAmount = value;
        }

        private void Start()
        {
            _progressBar = GetComponent<Image>();
        }
    }
}