using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadePanel : MonoBehaviour
{
    Animator animator;

    string level;
    bool changing = false;
    float timer = 0f;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if(changing) {
            timer += Time.deltaTime;
        }

        if(timer >= 1f) {
            SceneManager.LoadScene(level);
        }
    }
    public void ChangeLevel(string levelName) {
        if(!changing) {
            animator.SetTrigger("FadeOut");
            level = levelName;
            changing = true;
        }

    }

    public void ResetLevel() {
        ChangeLevel(SceneManager.GetActiveScene().name);
    }
}
