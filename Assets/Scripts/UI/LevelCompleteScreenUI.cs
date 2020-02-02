using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class LevelCompleteScreenUI : MonoBehaviour
{
    Animator animator;

    float timeSinceFinished = 0f;
    bool levelFinished = false;
    bool runAnimation = true;

    void Start() {
        animator = GetComponent<Animator>();
    }
    void Update() {
        if(levelFinished && runAnimation) {
            timeSinceFinished += Time.deltaTime;
        }

        if(Input.anyKeyDown && levelFinished && timeSinceFinished > 2f) {
            FindObjectOfType<FadePanel>().ChangeLevel("MainMenu");
        }
    }

    public void LevelComplete(bool runAnimation = true) {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
        PlayerPrefs.Save();
        
        if(runAnimation) {
            animator.SetBool("LevelComplete", true);
        }
        levelFinished = true;
        this.runAnimation = runAnimation;
    }
}
