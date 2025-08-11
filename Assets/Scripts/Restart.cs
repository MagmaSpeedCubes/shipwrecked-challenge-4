using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour
{
    [SerializeField] private Collider2D player;
    [SerializeField] private AudioClip restartSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player)
        {
            StartCoroutine(RestartAfterSound());
        }
    }

    private IEnumerator RestartAfterSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(restartSound);
        yield return new WaitForSeconds(restartSound.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}