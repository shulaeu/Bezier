using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionManager
{
    private OptionView optionView;
    private readonly OptionView optionViewPrefab;
    private readonly Transform parent;

    public OptionManager(OptionView optionViewPrefab, Transform parent)
    {
        this.optionViewPrefab = optionViewPrefab;
        this.parent = parent;
    }

    public void ShowOptions()
    {
        if (optionView == null)
        {
            optionView = Object.Instantiate(optionViewPrefab, parent);
            optionView.gameObject.SetActive(true);
        }
        else
        {
            optionView.gameObject.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            optionView.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
