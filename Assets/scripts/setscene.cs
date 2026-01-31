using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setscene : MonoBehaviour
{

    public string SceneName;
    public ToSave data;
    private string savepath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetScene()
    {
        savepath = Application.persistentDataPath + "/save.json";

        if(File.Exists(savepath))
        {
            data = JsonUtility.FromJson<ToSave>(File.ReadAllText(savepath));
            SceneManager.LoadScene(data.cureentscene);
        }
        else
        {
            data = new ToSave();
            data.cureentscene = "test";
            data.playerhealth = 100;
            data.playerpos = new Vector2(0, 0);


            File.WriteAllText(savepath, JsonUtility.ToJson(data));
            SceneManager.LoadScene(data.cureentscene);
        }
        
    }
}
