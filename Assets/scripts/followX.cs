using System;
using UnityEngine;

public class followX : MonoBehaviour
{
    public float speed;
    public Transform Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y/1.5f, transform.position.z);

        /*if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, Player.position.x + 5, speed), transform.position.y, transform.position.z);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, Player.position.x - 5, speed), transform.position.y, transform.position.z);
        }*/
    }
}
