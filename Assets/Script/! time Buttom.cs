using UnityEngine;
using UnityEngine.UI;

public class OneTimeButton : MonoBehaviour
{
    [SerializeField] private Button button;

    void Start()
    {
        
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        // Disable the button after it is clicked
        button.interactable = false;
    }
}

