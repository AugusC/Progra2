using System;
using TMPro;
using UnityEngine;

namespace HanoiTower
{
    public class HanoiController : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private int m_numberOfDisks = 3;
        
        [Header("References")]
        [SerializeField] private HanoiTowerController m_towerA;
        [SerializeField] private HanoiTowerController m_towerB;
        [SerializeField] private HanoiTowerController m_towerC;
        [SerializeField] private TextMeshProUGUI m_movesText;
        
        [Header("Prefabs")]
        [SerializeField] private HanoiElement m_elementPrefab;
        
        private HanoiTowerController m_selectedTower;
        private HanoiTowerController m_targetTower;
        private int m_moves = 0;
        
        private void Awake()
        {
            m_towerA.OnTowerSelected += OnTowerSelected;
            m_towerB.OnTowerSelected += OnTowerSelected;
            m_towerC.OnTowerSelected += OnTowerSelected;
            m_towerA.OnTowerDeselected += OnTowerDeselected;
            m_towerB.OnTowerDeselected += OnTowerDeselected;
            m_towerC.OnTowerDeselected += OnTowerDeselected;
        }

        public void ResetGame(int p_difficulty)
        {
            m_numberOfDisks = p_difficulty;
            m_moves = 0;
            
            m_movesText.text = "Moves: " + m_moves;

            m_towerA.ResetTower();
            m_towerB.ResetTower();
            m_towerC.ResetTower();
            
            for (int i = m_numberOfDisks; i > 0; i--)
            {
                var l_element = Instantiate(m_elementPrefab);
                l_element.SetElementValue(i);
                m_towerA.AddElement(l_element);
            }
        }

        private void OnTowerSelected(HanoiTowerController p_selectedTower)
        {
            if (!m_selectedTower)
            {
                if (p_selectedTower.GetCount >0)
                {
                    m_selectedTower = p_selectedTower;
                }
                else
                {
                    p_selectedTower.SetSelectionOff();
                }
            }
            else
            {
                m_targetTower = p_selectedTower;
            }
            
            ValidateMovement();
        }
        
        private void OnTowerDeselected(HanoiTowerController p_deselectedTower)
        {
            if (m_selectedTower == p_deselectedTower)
            {
                m_selectedTower = null;
            }
            else
            {
                m_targetTower = null;
            }
        }

        private void ValidateMovement()
        {
            if (!m_selectedTower || !m_targetTower)
                return;
            
            
            if (m_selectedTower != m_targetTower)
            {
                if (m_targetTower != null)
                {
                    if (m_targetTower.GetCount == 0 || m_targetTower.GetTopElementValue > m_selectedTower.GetTopElementValue)
                    {
                        var l_element = m_selectedTower.PopElement;
                        m_targetTower.AddElement(l_element);
                        m_moves++;
                    }
                }
            }
            
         
            m_targetTower.SetSelectionOff();
            m_selectedTower.SetSelectionOff();

            if (VictoryCheck())
            {
                m_movesText.text = "GANASTE CON " + m_moves + " MOVIMIENTOS";
            }
            else
            {
                m_movesText.text = "Moves: " + m_moves;
            }
        }

        private bool VictoryCheck()
        {
            if (m_towerC.GetCount == m_numberOfDisks)
            {
                m_towerA.Disable();
                m_towerB.Disable();
                m_towerC.Disable();
                return true;
            }
               

            return false;
        }

    }
}