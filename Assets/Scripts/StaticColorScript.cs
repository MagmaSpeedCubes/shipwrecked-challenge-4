using UnityEngine;

public class StaticColorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!Constants.debugMode)
        {
           GetComponent<SpriteRenderer>().color = Color.white; // Change to desired static color 
        }
        // Set the color of the GameObject to a static color
        
    }


}
