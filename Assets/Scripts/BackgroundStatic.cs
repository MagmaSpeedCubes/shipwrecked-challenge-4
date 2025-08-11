using UnityEngine;

public class BackgroundStatic : MonoBehaviour
{
    [SerializeField] private Sprite[] staticSprites;
    [SerializeField] private float changeInterval = 0.1f;
    private int index;
    private float timer;

    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            timer = 0;
            index = (index + 1) % staticSprites.Length;
            GetComponent<SpriteRenderer>().sprite = staticSprites[index];
        }
        
    }
    
}
