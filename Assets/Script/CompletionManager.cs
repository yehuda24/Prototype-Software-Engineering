using UnityEngine;

public class CompletionManager : MonoBehaviour
{
    public static CompletionManager Instance { get; private set; }

    public float current_completionB;
    public float current_completionDR;
    public float current_completionK;
    public float current_completionLR;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Makes the GameObject persist across scenes
        }
        else
        {
            Destroy(gameObject); // Ensures there's only one instance of the manager
        }
    }
}
