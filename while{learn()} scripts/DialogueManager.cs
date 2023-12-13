
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.06f;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject[] choices;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private AudioClip DialogueTypingSoundClip;
    [SerializeField] private GameObject questionImage;

    private AudioSource beepSound;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    public static DialogueManager instance { get; private set; }

    private Coroutine displayLineCoroutine;

    private bool canContinueNextLine = false;

    private void Awake()
    {
        //check if there are more than one dialogue manager
        if (instance == null)
        {
            Debug.LogWarning("Found more than one dialoge manager in the scene");
        }
        instance = this; 

        beepSound = this.gameObject.AddComponent<AudioSource>();
    }
    
    public static DialogueManager GetInstance() {
        return instance;
    }

    private void Start()
    {
        //set parameters when start
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        questionImage.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach( GameObject choice in choices )
        {
            choicesText[index] =  choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying) 
        { 
            return; 
        }
        if (Input.GetKeyDown(KeyCode.Space) && canContinueNextLine)
        {
            continueStory();
        }
    }
    //function to enter the dialogue mode
    public void enterDialogeMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

       continueStory();
    }

    //function to exit the dialogue mode
    private IEnumerator exitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    //function to continue the dialogue
    private void continueStory()
    {
        if (currentStory.canContinue)
        {
            if(displayLineCoroutine != null) 
            {
                StopCoroutine(displayLineCoroutine);
            }

            displayLineCoroutine=StartCoroutine(DisplayLine(currentStory.Continue()));
             
            
        }
        else
        {
            StartCoroutine(exitDialogueMode());
        }

    }

    //function to dislap the line one letter by one letter
    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";

        continueIcon.SetActive(false);
        hideChoices();


        canContinueNextLine = false;

        foreach (char letter in line.ToCharArray())
        {
           
            dialogueText.text += letter;
            beepSound.PlayOneShot(DialogueTypingSoundClip);
            yield return new WaitForSeconds(typingSpeed);
        }
        continueIcon.SetActive(true) ;
        displayChoices();

        canContinueNextLine =true; 
    }

    //hide choices if there is no question
    private void hideChoices()
    {
        foreach(GameObject choicesButton in choices)
        {
            choicesButton.SetActive(false);
            questionImage.SetActive(false);
        }
        
    }

    //show choices if there is no question

    private void displayChoices()
    {

        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }
        
        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
            questionImage.SetActive(true);
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        
        StartCoroutine(selectFirstChoice());
    }
    private IEnumerator selectFirstChoice()
    {
       
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        
    }

    // function for making a choice
    public void MakeChoice(int choiceIndex)
    {
        
        if (canContinueNextLine)
        {
            
            currentStory.ChooseChoiceIndex(choiceIndex);
           
            continueStory();
            
        }


    }
}