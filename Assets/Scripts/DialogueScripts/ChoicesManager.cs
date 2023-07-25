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
using UnityEngine.SceneManagement;

public class ChoicesManager : MonoBehaviour
{
    [Header("Dialgoue UI")]
    [SerializeField] private GameObject dialoguepanel;
    [SerializeField] private TextMeshProUGUI dialogue;
    [Header("Choices")]
    [SerializeField] private GameObject[] playerchoices;

    private TextMeshProUGUI[] choicesC;


    private Story currentstory;

    private static ChoicesManager instance;

    public bool Dialogueisplaying;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue in the scene");
        }
        instance = this;
    }

    public static ChoicesManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        Dialogueisplaying = false;
        dialoguepanel.SetActive(false);

        //this helps get all the choices in text form
        choicesC = new TextMeshProUGUI[playerchoices.Length];
        int index = 0;
        foreach (GameObject choice in playerchoices)
        {
            choicesC[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!Dialogueisplaying)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Continuestory();
        }
    }

    public void EnterSpeechMode(TextAsset inkJSON)
    {
        currentstory = new Story(inkJSON.text);
        Dialogueisplaying = true;
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
            Displaychoices();
        }
        else
        {
            ExitDialogue();
        }
    }
    private void Displaychoices()
    {
        List<Choice> currentchoices = currentstory.currentChoices;

        //checks to make sure UI can support the amount of choices.
        if (currentchoices.Count > choicesC.Length)
        {
            Debug.Log("More choices were given than the UI can handle!" + currentchoices.Count);
        }

        int index = 0;
        //turns on and starts the choices up to the amount of choices presented.
        foreach (Choice choice in currentchoices)
        {
            playerchoices[index].gameObject.SetActive(true);
            choicesC[index].text = choice.text;
            index++;
        }
        //go through the remaining choices the UI has and hide them
        for (int i = index; i < playerchoices.Length; i++)
        {
            playerchoices[i].gameObject.SetActive(false);
        }

        StartCoroutine(Selectfirstoption());

    }
    private IEnumerator Selectfirstoption()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(playerchoices[0].gameObject);
    }

    public void Makeachoice(int choiceindex)
    {
        currentstory.ChooseChoiceIndex(choiceindex);
        LevelChoices levelLoader = GetComponent<LevelChoices>();
        if (levelLoader != null)
        {
            levelLoader.LoadLevel(choiceindex);
        }
        
    }
}
