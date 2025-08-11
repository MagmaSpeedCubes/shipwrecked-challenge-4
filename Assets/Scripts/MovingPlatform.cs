using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 start;
    [SerializeField] private Vector3 end;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject player;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private AudioClip moveSound;
    private AudioSource audioSource;
    [SerializeField] private float speed = 1f;

    void Update()
    {
        if (playerCollider.IsTouching(platform.GetComponent<Collider2D>()))
        {
            audioSource = GetComponent<AudioSource>();
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(moveSound);
            }

            // Move the platform towards the end position
            platform.transform.position = Vector3.MoveTowards(
                platform.transform.position, 
                end, 
                speed * Time.deltaTime
            );

            // Reset to start position if reached end
            if (Vector3.Distance(platform.transform.position, end) < 0.01f)
            {
                platform.transform.position = start;
            }
        }
    }

    void Start()
    {
        platform.transform.position = start; // Initialize platform position
    }
}
