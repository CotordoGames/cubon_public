
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathIfPlayerTouch : MonoBehaviour
{
    public GameObject music;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(music);
            SceneManager.LoadScene("title_screen");
        }
    }
}
