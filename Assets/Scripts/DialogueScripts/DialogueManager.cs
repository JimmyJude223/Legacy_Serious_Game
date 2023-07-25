using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using Story = Ink.Runtime.Story;
using Choice = Ink.Runtime.Choice;
using UnityEditor;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialgoue UI")]
    [SerializeField] private GameObject dialoguepanel;
    [SerializeField] private TextMeshProUGUI dialogue;
    


    private Story currentstory;
     
    private static DialogueManager instance;

    public  bool Dialogueisplaying;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        Dialogueisplaying = false;
        dialoguepanel.SetActive(false);
    }

    private void Update()
    {
        if(!Dialogueisplaying)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Continuestory();    
        }
    }

    public void EnterSpeechMode(TextAsset inkJSON)
    {
        currentstory = new Story(inkJSON.text);
        Dialogueisplaying=true;
        dialoguepanel.SetActive(true);

        Continuestory();
        
    }

    private void ExitDialogue()
    {
        Dialogueisplaying = false;
        dialoguepanel.SetActive(false);
        dialogue.text = "";
    }

    private void Continuestory()
    {
        if (currentstory.canContinue)
        {
            //set the text for the current line of the story
            dialogue.text = currentstory.Continue();
            //display the choices, if any for this dialogue line
        }
        else
        {
            ExitDialogue();
        }
    }
   
}
