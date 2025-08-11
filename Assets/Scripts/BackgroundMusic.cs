using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private void Awake()
    {
        // Prevent duplicate music players
        if (FindObjectsOfType<BackgroundMusic>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}