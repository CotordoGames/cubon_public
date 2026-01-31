using UnityEngine;

public class startdialogue : MonoBehaviour
{

    public Dialogue sentences;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerDialogue()
    {
        FindFirstObjectByType<DialogueManager>().StartDialogue(sentences);
    }
}
