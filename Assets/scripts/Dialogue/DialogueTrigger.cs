
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private bool touching;

    private bool triggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touching = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touching = false;
            triggered = false;
        }
    }
    private void Update()
    {
        if(touching && !triggered && Input.GetAxisRaw("Vertical") == -1)
        {
            triggered = true;
            TriggerDialogue();
        }
    }
    public void TriggerDialogue()
    {
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
}
