using UnityEngine;

public class paralaxx : MonoBehaviour
{
    public float offsetX;
    public int offsetY;

    public Transform Camera;
    public float speed;
    void Update()
    {
        transform.position = new Vector2(Camera.transform.position.x * speed - offsetX, Camera.transform.position.y * speed - offsetY);
    }
}
