using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseMainMenu : MonoBehaviour
{
    [Header("BaseMainMenu")]
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private OptionView optionViewPrefab;

    private OptionView optionView;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        optionsButton.onClick.AddListener(ShowOptions);
        exitButton.onClick.AddListener(ExitGame);
    }
    private void ShowOptions()
    {
        if (optionView == null)
        {
            optionView = Instantiate(optionViewPrefab, transform);
            optionView.gameObject.SetActive(true);
        }
        else
        {
            optionView.gameObject.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            optionView.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        }
    }
    
    protected virtual void ExitGame()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
