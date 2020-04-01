using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool inPlay = false;
    private bool gameOver = false;

    public int score1, score2;
    [SerializeField] int scoreToWin;

    public TextMeshProUGUI text1, text2;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI winnerText;

    private void OnEnable()
    {
        instance = this;
    }

    private void Update()
    {
        if (inPlay == false && gameOver != true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inPlay = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        CheckWinner();
    }

    private void CheckWinner()
    {
        if (!inPlay)
        {
            if (score1 >= scoreToWin || score2 >= scoreToWin)
            {
                gameOver = true;
                gameOverPanel.SetActive(true);
                if (score1 >= scoreToWin)
                {
                    winnerText.text = "YOU\nWON";
                }
                else
                {
                    winnerText.text = "NOT YOU\nWON";
                }
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
