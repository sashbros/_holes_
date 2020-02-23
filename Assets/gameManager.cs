using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public Animator animator;
    public void RestartCurrentScene() {
        StartCoroutine(RestartScene());
    }
    IEnumerator RestartScene() {
        yield return new WaitForSeconds(1.5f);
        animator.SetTrigger("fadeOut");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Update() {
        if(Input.GetKey(KeyCode.Escape)) {
            animator.SetTrigger("fadeOut");
            SceneManager.LoadScene(0);
        }    
    }

    public void AdvanceToNextScene() {
        StartCoroutine(NextScene());
    }
    IEnumerator NextScene() {
        yield return new WaitForSeconds(4f);
        animator.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Play() {
        animator.SetTrigger("fadeOut");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit() {
        Application.Quit();
    }
}
