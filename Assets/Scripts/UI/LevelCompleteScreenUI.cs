using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class LevelCompleteScreenUI : MonoBehaviour
{
    Animator animator;

    float timeSinceFinished = 0f;
    bool levelFinished = false;

    void Start() {
        animator = GetComponent<Animator>();
    }
    void Update() {
        if(levelFinished) {
            timeSinceFinished += Time.deltaTime;
        }

        if(Input.anyKeyDown && levelFinished && timeSinceFinished > 2f) {
            FindObjectOfType<FadePanel>().ChangeLevel("MainMenu");
        }
    }

    public void LevelComplete() {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
        PlayerPrefs.Save();

        animator.SetBool("LevelComplete", true);
        levelFinished = true;
    }
}
