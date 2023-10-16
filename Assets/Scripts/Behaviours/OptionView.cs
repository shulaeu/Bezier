using UnityEngine;
using UnityEngine.UI;

public class OptionView : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    private void Start()
    {
        closeButton.onClick.AddListener(onCloseButton);
    }
    
    private void onCloseButton()
    {
        gameObject.SetActive(false);
    }
}
