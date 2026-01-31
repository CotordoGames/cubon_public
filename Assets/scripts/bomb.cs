using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour
{
    public GameObject exp;
    private CircleCollider2D cc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        cc.enabled = false;
    }

    IEnumerator BOOM()
    {
        yield return new WaitForSeconds(3);
        Instantiate(exp);
        cc.enabled = true;
        Destroy(gameObject);
    }
}
