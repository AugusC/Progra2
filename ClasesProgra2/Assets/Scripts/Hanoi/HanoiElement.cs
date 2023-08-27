using TMPro;
using UnityEngine;

namespace HanoiTower
{
    public class HanoiElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_label;
        private int m_value = -1;

        public int Value => m_value;
        
        public void SetElementValue(int p_elementValue)
        {
            m_label.text = p_elementValue.ToString();
            m_value = p_elementValue;
            
            SetRectTransformWidth(p_elementValue * 20);
        }
        
        private void SetRectTransformWidth(float p_elementWidth) 
        {
            var l_rectTransform = transform as RectTransform;
            l_rectTransform.sizeDelta = new Vector2(p_elementWidth, l_rectTransform.sizeDelta.y);
        }
    }
}