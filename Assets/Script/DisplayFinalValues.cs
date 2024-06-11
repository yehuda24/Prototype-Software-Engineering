using UnityEngine;
using TMPro;

public class DisplayFinalValues : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI completionBText;
    [SerializeField] private TextMeshProUGUI completionDRText;
    [SerializeField] private TextMeshProUGUI completionKText;
    [SerializeField] private TextMeshProUGUI completionLRText;

    void Start()
    {
        // Ensure TextMeshProUGUI components are assigned
        if (completionBText == null || completionDRText == null || completionKText == null || completionLRText == null)
        {
            Debug.LogError("TextMeshProUGUI components not assigned.");
            return;
        }

        // Update the UI text with the completion values
        completionBText.text = "Bedroom Completion: " + $"<color=green>{CompletionManager.Instance.current_completionB}%</color>";
        completionDRText.text = "Dining Room Completion: " + $"<color=green>{CompletionManager.Instance.current_completionDR}%</color>";
        completionKText.text = "Kitchen Completion: " + $"<color=green>{CompletionManager.Instance.current_completionK}%</color>";
        completionLRText.text = "Completion LR: " + $"<color=green>{CompletionManager.Instance.current_completionLR}%</color>";
    
    }
}
