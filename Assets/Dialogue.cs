using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text textDisplay;
    public string[] sentences;
    private int index=0;
    public float typingSpeed;

    public GameObject continueBtn;
    public Animator animator;

    void Start() {
        StartCoroutine(SceneStart());
    }

    void Update() {
        if (textDisplay.text == sentences[index]) {
            continueBtn.SetActive(true);
        }
    }

    IEnumerator SceneStart() {
        yield return new WaitForSeconds(2f);
        StartCoroutine(Type());
    }

    IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence() {
        FindObjectOfType<audioManager>().Play("Continue");
        continueBtn.SetActive(false);

        if (index < sentences.Length -1) {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else {
            textDisplay.text = "";
            continueBtn.SetActive(false);
            animator.SetTrigger("dialogueBack");
            GameObject.Find("GameManager").GetComponent<gameManager>().AdvanceToNextScene();
        }
    }

}
