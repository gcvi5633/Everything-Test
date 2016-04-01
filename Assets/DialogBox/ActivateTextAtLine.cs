using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public bool requireButtonPress;
    public bool waitForPress;

    public bool destroyWhenActivated;
	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(waitForPress && Input.GetKeyDown(KeyCode.J)) {
            waitForPress = false;
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.stopPlayerMovement = true;
            theTextBox.ReloadScript(theText);
            theTextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
	}

    void OnTriggerEnter(Collider other) {
        if(other.name == "Player") {
            if(requireButtonPress) {
                waitForPress = true;
                return;
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.name == "Player") {
            waitForPress = false;
        }
    }
}
