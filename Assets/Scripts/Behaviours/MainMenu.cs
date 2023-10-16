using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : BaseMainMenu
{
    [Header("MainMenu")]
    [SerializeField] private Button startButton;
    
    protected override void Init()
    {
        startButton.onClick.AddListener(StartGame);

        base.Init();
    }
    protected override void ExitGame()
        {
            Application.Quit();
        }

    private void StartGame()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }
}
