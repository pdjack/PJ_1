using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI waveText;
    
    [SerializeField] private Slider hpSlider;
    
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject cardPanelR;
    [SerializeField] private GameObject cardPanelL;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //text
        waveText.text = "Wave." + 1;
        //slider
        ShowPlayerHpSlider(1);
        //panel
        gameOverPanel.SetActive(false);
        cardPanelR.SetActive(false);
        cardPanelL.SetActive(false);

    }

    //text
    
    // text ) waveCount
    public void UpdateWaveText(int waveCount)
    {
        waveText.text = "Wave." + waveCount.ToString();
    }
    
    //slider

    // slider ) player hp
    public void ShowPlayerHpSlider(float hp)
    {
        hpSlider.value = hp;
    }
    
    //panel
    
    // panel ) gameOver
    public void ShowGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
    //button
    
    // button ) restart
    public void RestartGame()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
