using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TalkOnTouch : MonoBehaviour
{
    private static List<string> Destroyed = new List<string>();
    public Dialogue dialogue;
    public jonnyboss jboi;
    public GameObject healthbar;
    public AudioSource music;
    bool DoneTalking = false;

    private bool touching;

    private void Start()
    {
        DoneTalking = false;
        healthbar.GetComponentInChildren<Image>().enabled = false;
        jboi.enabled = false;
        if (Destroyed.Count > 0)
        {
            for (int i = 0; i < Destroyed.Count; i++)
            {
                Destroy(GameObject.Find(Destroyed.ToString()));
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }
    private void Update()
    {
        if (FindObjectOfType<DialogueManager>().sentences.Count == 0 && FindObjectOfType<DialogueManager>().donetalking)
        {
            jboi.enabled = true;
            music.Play();
            healthbar.GetComponentInChildren<Image>().enabled = true;
            Destroy(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touching = false;
        }
    }

    [System.Obsolete]
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        DoneTalking = true;
        Destroyed.Add(this.name);
        
    }
}
