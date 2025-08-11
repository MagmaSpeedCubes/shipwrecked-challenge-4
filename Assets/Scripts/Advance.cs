using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Advance : MonoBehaviour
{
    [SerializeField] private Collider2D player;
    [SerializeField] private AudioClip advanceSound;
    private bool triggered = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player && !triggered)
        {
            triggered = true; // Set flag immediately to prevent multiple triggers
            StartCoroutine(AdvanceAfterSound());
        }
    }

    private IEnumerator AdvanceAfterSound()
    {
        
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Advancing to level " + nextScene);
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(advanceSound);
        yield return new WaitForSeconds(advanceSound.length);
        SceneManager.LoadScene(nextScene);
    }
}