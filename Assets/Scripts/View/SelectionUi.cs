using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class SelectionUi : MonoBehaviour
    {
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
        }

        public string Text
        {
            get => _text.text;
            set => _text.text = value;
        }
    }
}