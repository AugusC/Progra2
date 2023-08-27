using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HanoiTower
{
    public class HanoiTowerController : MonoBehaviour
    {
        [SerializeField] private Toggle m_selectionToggle;
        [SerializeField] private Transform m_elementsParent;

        public event Action<HanoiTowerController> OnTowerSelected;
        public event Action<HanoiTowerController> OnTowerDeselected;
        
        private Stack<HanoiElement> m_elements;

        public int GetCount => m_elements.Count;
        
        public int GetTopElementValue => m_elements.Peek().Value;
        
        public HanoiElement PopElement => RemoveElement();
        
        private void Awake()
        {
            m_selectionToggle.onValueChanged.AddListener(OnToggleValueChanged);
            m_elements = new Stack<HanoiElement>();
        }
        
        private void OnToggleValueChanged(bool p_isOn)
        {
            if (p_isOn)
            {
                OnTowerSelected?.Invoke(this);
            }
            else
            {
                OnTowerDeselected?.Invoke(this);
            }
        }

        public void ResetTower()
        {
            m_selectionToggle.isOn = false;
            m_selectionToggle.interactable = true;
            foreach (var l_element in m_elements)
            {
                Destroy(l_element.gameObject);
            }
            
            m_elements = new Stack<HanoiElement>();
        }

        public void Disable()
        {
            m_selectionToggle.interactable = false;
        }
        
        public void SetSelectionOff()
        {
            m_selectionToggle.isOn = false;
        }
        
        public void AddElement(HanoiElement p_element)
        {
            m_elements.Push(p_element);
            p_element.transform.SetParent(m_elementsParent);
            p_element.transform.SetAsFirstSibling();
        }
        
        private HanoiElement RemoveElement()
        {
            return m_elements.Pop();
        }

    }
}
