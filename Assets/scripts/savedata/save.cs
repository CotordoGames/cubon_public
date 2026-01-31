using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class ToSave
{
    public Vector2 playerpos;
    public string cureentscene;
    public int playerhealth;
}
public class save : MonoBehaviour
{

    string savepath;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        savepath = Application.persistentDataPath + "/save.json";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                ToSave data = new ToSave();

                data.playerpos = collision.transform.position;
                data.cureentscene = SceneManager.GetActiveScene().name;
                data.playerhealth = collision.GetComponent<ThyShaltGetHurteth>().health;

                string output = JsonUtility.ToJson(data, true);
                File.WriteAllText(savepath, output);
            }
            
        }
    }
}
