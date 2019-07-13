using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class WeaponUi : MonoBehaviour
    {
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
        }

        public void ShowData(int ammunitionCount, int clipCount)
        {
            _text.text = $"{ammunitionCount}/{clipCount}";
        }

        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);
        }
    }
}