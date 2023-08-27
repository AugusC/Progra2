using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HanoiTower
{
    
    public enum HanoiState
    {
        Menu,
        Game,
        Instructions,
        pause,
        win
    }
    public class HanoiMenuController : MonoBehaviour
    {
        [SerializeField] GameObject m_menuPanel;
        [SerializeField] GameObject m_gamePanel;
        [SerializeField] GameObject m_instructionsPanel;
        [SerializeField] GameObject m_winPanel;
        [SerializeField] GameObject m_pausePanel;
        [SerializeField] HanoiController m_hanoiController;
        
        [SerializeField] TMP_InputField m_difficultyInputField;

        [SerializeField] private Button m_menuButton;
        [SerializeField] private Button m_instructionsButton;
        [SerializeField] private Button m_gameButton;
        [SerializeField] private Button m_winButton;
        
        [SerializeField] private Button m_pauseResumeButton;
        [SerializeField] private Button m_pauseMenuButton;
        
        
        public void Awake()
        {
            m_menuButton.onClick.AddListener((() =>
            {
                SetGameState(HanoiState.Instructions);
            }));
            
            m_instructionsButton.onClick.AddListener((() =>
            {
                SetGameState(HanoiState.Game);
                m_hanoiController.ResetGame(int.Parse(m_difficultyInputField.text));
            }));
            
            m_gameButton.onClick.AddListener((() =>
            {
                SetGameState(HanoiState.pause);
            }));
            
            m_winButton.onClick.AddListener(() =>
            {
                SetGameState(HanoiState.Menu);
            });
            
            m_pauseResumeButton.onClick.AddListener(() =>
            {
                SetGameState(HanoiState.Game);
            });
            
            m_pauseMenuButton.onClick.AddListener(() =>
            {
                SetGameState(HanoiState.Menu);
            });
            
            SetGameState(HanoiState.Menu);
        }

        public void SetGameState(HanoiState p_state)
        {
            switch (p_state)
            {
                case HanoiState.Menu:
                    m_menuPanel.SetActive(true);
                    m_gamePanel.SetActive(false);
                    m_instructionsPanel.SetActive(false);
                    m_winPanel.SetActive(false);
                    m_pausePanel.SetActive(false);
                    break;
                case HanoiState.Game:
                    m_menuPanel.SetActive(false);
                    m_gamePanel.SetActive(true);
                    m_instructionsPanel.SetActive(false);
                    m_winPanel.SetActive(false);
                    m_pausePanel.SetActive(false);
                    break;
                case HanoiState.Instructions:
                    m_menuPanel.SetActive(false);
                    m_gamePanel.SetActive(false);
                    m_instructionsPanel.SetActive(true);
                    m_winPanel.SetActive(false);
                    m_pausePanel.SetActive(false);

                    m_difficultyInputField.text = "3";
                    break;
                case HanoiState.pause:
                    m_menuPanel.SetActive(false);
                    //m_gamePanel.SetActive(false);
                    m_instructionsPanel.SetActive(false);
                    m_winPanel.SetActive(false);
                    m_pausePanel.SetActive(true);
                    break;
                case HanoiState.win:
                    m_menuPanel.SetActive(false);
                    //m_gamePanel.SetActive(false);
                    m_instructionsPanel.SetActive(false);
                    m_winPanel.SetActive(true);
                    m_pausePanel.SetActive(false);
                    break;
            }
        }
    }
}
