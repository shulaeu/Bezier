using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseMainMenu : MonoBehaviour
{
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private OptionView optionViewPrefab;

    private OptionView optionView;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        OptionManager optionManager = new OptionManager(optionViewPrefab, transform);

        optionsButton.onClick.AddListener(optionManager.ShowOptions);
        exitButton.onClick.AddListener(ExitGame);
    }
    
    protected virtual void ExitGame()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
