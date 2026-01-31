using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    private AudioSource AS;
    public AudioSource SFX;


    private string sent;

    public PlayerMovement pm;
    public bool donetalking;
    public bool istalking;
    public Text dialogueText;
    public Image image;

    public Animator anim;
    private Dialogue currentDialogue;

    public Queue<string> sentences;
    public Queue<AudioClip> sounds;
    private Queue<Sprite> portraits;
    private Queue<float> speeds;
    private Queue<Color> colors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        istalking = false;
        donetalking = false;
        AS = GetComponent<AudioSource>();
        sentences = new Queue<string>();
        portraits = new Queue<Sprite>();
        speeds = new Queue<float>();
        colors = new Queue<Color>();
        sounds = new Queue<AudioClip>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        istalking = true;
        donetalking = false;
        anim.SetBool("IsOpen", true);
        currentDialogue = dialogue;

        sentences.Clear();
        portraits.Clear();
        speeds.Clear();
        colors.Clear();
        sounds.Clear();
        pm.rb.linearVelocityX = 0;
        pm.enabled = false;
        foreach (var line in dialogue.lines)
        {
            sentences.Enqueue(line.sentence);
            portraits.Enqueue(line.portrait);
            speeds.Enqueue(line.speed);
            colors.Enqueue(line.color);
            sounds.Enqueue(line.sound);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            
            EndDialogue();
            donetalking = true;
            istalking = false;
            pm.enabled = true;
            return;
        }

        image.sprite = portraits.Dequeue();
        image.SetNativeSize();
        dialogueText.color = colors.Dequeue();
        SFX.clip = sounds.Dequeue();
        SFX.Play();


        string sentence = sentences.Dequeue();
        float speed = speeds.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, speed));

    }

    IEnumerator TypeSentence(string sentence, float speed)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (!dialogueText.text.Contains(sentence))
            {
            
                dialogueText.text += letter;
                if(dialogueText.text[dialogueText.text.Length - 1] == ',' || dialogueText.text[dialogueText.text.Length - 1] == '.' || dialogueText.text[dialogueText.text.Length - 1] == '!' || dialogueText.text[dialogueText.text.Length - 1] == '.' || dialogueText.text[dialogueText.text.Length - 1] == '?')
                {
                    yield return new WaitForSeconds(speed * 1.25f);
                }
                else
                {
                    AS.Play();

                }
            }
            yield return new WaitForSeconds(speed);
            sent = sentence;
        }
    }
    private void Update()
    {
        if(sent == null)
        {
            sent = "";
        }
        if (Input.GetKeyDown("x") && !dialogueText.text.Contains(sent) && sent != null)
        {
            dialogueText.text = sent;
        }
        if (Input.GetKeyDown("z") && dialogueText.text.Contains(sent) && sent != null)
        {
            DisplayNextSentence();
        }
    }

    public void EndDialogue()
    {
        istalking = false;
        anim.SetBool("IsOpen", false);
    }
}
