using UnityEngine;
using UnityEngine.SceneManagement;

public class Advance : MonoBehaviour
{
    [SerializeField] private Collider2D player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player)
        {
            LoadNextScene();
        }
    }
    public void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("No more scenes in build settings.");
        }
    }
}