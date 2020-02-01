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

    int levelCount;

    public void Start() {
        levelCount = levelParent.transform.childCount;
    }

    public void Update() {
        levelCount = levelParent.transform.childCount;

        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f && !hDown) {
            hDown = true;

            levelSelected = ((levelSelected + (Input.GetAxis("Horizontal") > 0f ? 1 : -1)) + levelCount) % levelCount;
        } else if(Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1f && hDown) {
            hDown = false;
        }

        if(Mathf.Abs(Input.GetAxis("HorizontalPlayerTwo")) > 0.1f && !hTwoDown) {
            hTwoDown = true;

            levelSelected = ((levelSelected + (Input.GetAxis("HorizontalPlayerTwo") > 0f ? 1 : -1)) + levelCount) % levelCount;
        } else if(Mathf.Abs(Input.GetAxis("HorizontalPlayerTwo")) < 0.1f && hTwoDown) {
            hTwoDown = false;
        }

        if(Input.GetButtonDown("Jump") || Input.GetButtonDown("JumpPlayerTwo")) {
            string levelName = levelParent.transform.GetChild(levelSelected).name;

            if(levelName == "Quit") {
                Application.Quit();
            } else {
                FindObjectOfType<FadePanel>().ChangeLevel(levelName);
            }
        }

        Vector3 newPos = Vector3.Lerp(transform.position, levelParent.transform.GetChild(levelSelected).position, 0.1f);
        transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
        levelSelectText.text = levelParent.transform.GetChild(levelSelected).name;
    }
}
