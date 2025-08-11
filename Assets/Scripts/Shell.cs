using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour
{
    [SerializeField] private Collider2D player;
    [SerializeField] private AudioClip shellSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(shellSound);
            StartCoroutine(DestroyAfterSound(shellSound.length));
        }
    }

    private IEnumerator DestroyAfterSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}