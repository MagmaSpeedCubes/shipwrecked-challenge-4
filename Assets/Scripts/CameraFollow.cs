using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 myPos;
    public Transform myPlay;

    public void Update()
    {
        transform.position = new Vector3(
            myPlay.position.x + myPos.x,
            transform.position.y,
            transform.position.z
        );
    }
}
