using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Dialogue
{
    public DialogueLine[] lines;
}

[System.Serializable]
public class DialogueLine
{
    public string name;
    public Sprite portrait;
    public float speed;
    public Color color;
    public AudioClip sound;

    [TextArea(3, 10)]
    public string sentence;
}