using UnityEngine;

public class cloud : MonoBehaviour
{
    private paralaxx pl;
    public float startoffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pl = GetComponent<paralaxx>();
    }

    // Update is called once per frame
    void Update()
    {
        pl.offsetX = pl.offsetX + .01f;
        if(pl.offsetX > startoffset + 255) {
            pl.offsetX = startoffset;
        }
    }
}
