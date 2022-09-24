using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const float WIN_CONDITION = 75;

    private DisplayHandler _handler;

    [Header("Display UI")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject mainGame;
    [SerializeField] private GameObject endGame;

    void Start()
    {
        _handler = FindObjectOfType<DisplayHandler>();
    }
    
    
    public void SetMainGameScreen()
    {
        mainMenu.SetActive(false);
        endGame.SetActive(false);
        mainGame.SetActive(true);
    }

    public void SetMainMenu()
    {
        mainMenu.SetActive(true);
        mainGame.SetActive(false);
        endGame.SetActive(false);
    }

    public void SetEndGame(bool isWon)
    {
        mainGame.SetActive(false);
        mainMenu.SetActive(false);
        endGame.SetActive(true);
        _handler.SetEndGameDisplay(isWon);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
