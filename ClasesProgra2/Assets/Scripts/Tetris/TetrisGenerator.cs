using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tetris
{
    public class TetrisGenerator : MonoBehaviour
    {
        [SerializeField] private List<TetrisFigure> m_tetrisFigures;

        private Queue<int> m_tetrisFiguresIDs = new Queue<int>();

        private void Awake()
        {
            GenerateFiguresIds(10);
        }
        
        public TetrisFigure GetFigureDisplay(Transform p_parent)
        {
            var l_id = m_tetrisFiguresIDs.Dequeue();
            var l_figure = Instantiate(m_tetrisFigures[l_id], p_parent);
            
            Debug.Log("Mostrando ID: " + l_id);

            if (m_tetrisFiguresIDs.Count == 0)
            {
                GenerateFiguresIds(10);
            }
            
            return l_figure;
        }

        private void GenerateFiguresIds(int p_quantity)
        {
            string l_ids = "";
            for (int i = 0; i < p_quantity; i++)
            {
                var l_id = Random.Range(0, m_tetrisFigures.Count);
                m_tetrisFiguresIDs.Enqueue(l_id);
                l_ids += l_id + " :: ";
            }
            Debug.Log("Ids creados: " + l_ids);
        }

    }

}
