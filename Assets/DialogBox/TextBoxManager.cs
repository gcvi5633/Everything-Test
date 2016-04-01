using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;

    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public PlayerController player;

    public bool isActive;
    public bool stopPlayerMovement;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float tyoeSpeed;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0) {
            endAtLine = textLines.Length - 1;
        }
        if(isActive) {
            EnableTextBox();
        }else {
            DisableTextBox();
        }
    }

    // Update is called once per frame
    void Update () {
        if(!isActive) {
            return;
        }
        
        //theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return)) {
            if(!isTyping) {
                currentLine += 1;
                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                    ActivateTextAtLine a = FindObjectOfType<ActivateTextAtLine>();
                    a.waitForPress = true;
                }
                else {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if(isTyping && !cancelTyping) {
                cancelTyping = true;
            }
        }
	}

    private IEnumerator TextScroll(string lineOfText) {
        int latter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;

        while(isTyping && !cancelTyping && (latter < lineOfText.Length-1)) {
            theText.text += lineOfText[latter];
            latter++;
            yield return new WaitForSeconds(tyoeSpeed);
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox() {
        textBox.SetActive(true);
        isActive = true;
        if(stopPlayerMovement) {
            player.canMove = false;
        }
        StartCoroutine(TextScroll(textLines[currentLine]));
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        player.canMove = true;
    }

    public void ReloadScript(TextAsset theText) {
        if(theText!=null) {
            textLines = new string[0];
            textLines = (theText.text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }
}
