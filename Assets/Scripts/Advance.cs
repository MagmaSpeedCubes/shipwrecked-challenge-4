using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Advance : MonoBehaviour
{
    [SerializeField] private Collider2D player;
    [SerializeField] private AudioClip advanceSound;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player)
        {
            StartCoroutine(AdvanceAfterSound());
        }
    }

    private IEnumerator AdvanceAfterSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(advanceSound);
        yield return new WaitForSeconds(advanceSound.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}