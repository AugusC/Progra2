using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tetris
{
    public class TetrisFiguresDisplay : MonoBehaviour
    {
        [SerializeField] private Transform m_content;
        [SerializeField] private Button m_button;
        [SerializeField] private TetrisGenerator m_generator;


        private void Awake()
        {
            m_button.onClick.AddListener(ShowNextFigure);
        }


        public void ShowNextFigure()
        {
            if (m_content.childCount > 0 && m_content.childCount >= 5)
            {
                Destroy(m_content.GetChild(0).gameObject);
            }
          
            m_generator.GetFigureDisplay(m_content);
        }
    }
}