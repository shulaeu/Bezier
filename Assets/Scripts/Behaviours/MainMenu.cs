using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private OptionView optionViewPrefab;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        OptionManager optionManager = new OptionManager(optionViewPrefab, transform);

        startButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(optionManager.ShowOptions);
        exitButton.onClick.AddListener(ExitGame);
    }
    private void ExitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }
}
