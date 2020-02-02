using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public bool hDown;
    public bool hTwoDown;

    int levelSelected = 0;

    public GameObject levelParent;
    public Text levelSelectText;

    public AudioClip changeLevelSound;
    public AudioClip selectedLevelSound;

    AudioSource source;

    int levelCount;

    public void Start() {
        levelCount = levelParent.transform.childCount;
        source = GetComponent<AudioSource>();
    }

    public void Update() {
        levelCount = levelParent.transform.childCount;

        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f && !hDown) {
            hDown = true;

            levelSelected = ((levelSelected + (Input.GetAxis("Horizontal") > 0f ? 1 : -1)) + levelCount) % levelCount;
            source.clip = changeLevelSound;
            source.Play();
        } else if(Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1f && hDown) {
            hDown = false;
        }

        if(Mathf.Abs(Input.GetAxis("HorizontalPlayerTwo")) > 0.1f && !hTwoDown) {
            hTwoDown = true;

            levelSelected = ((levelSelected + (Input.GetAxis("HorizontalPlayerTwo") > 0f ? 1 : -1)) + levelCount) % levelCount;
            source.clip = changeLevelSound;
            source.Play();
        } else if(Mathf.Abs(Input.GetAxis("HorizontalPlayerTwo")) < 0.1f && hTwoDown) {
            hTwoDown = false;
        }

        if(Input.GetButtonDown("Jump") || Input.GetButtonDown("JumpPlayerTwo") || Input.GetButtonDown("Interact") || Input.GetButtonDown("InteractPlayerTwo")) {
            string levelName = levelParent.transform.GetChild(levelSelected).name;

            if(levelName == "Quit") {
                Application.Quit();
            } else if(levelName == "Reset Levels") {
                PlayerPrefs.DeleteAll();
                FindObjectOfType<FadePanel>().ResetLevel();
            } else {
                if(levelName == "Level 1") {
                    levelName = "IntroCutscene";
                }

                FindObjectOfType<FadePanel>().ChangeLevel(levelName);
                source.clip = selectedLevelSound;
                source.Play();
            }
        }

        Vector3 newPos = Vector3.Lerp(transform.position, levelParent.transform.GetChild(levelSelected).position, 0.1f);
        transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
        levelSelectText.text = levelParent.transform.GetChild(levelSelected).name;
    }
}
