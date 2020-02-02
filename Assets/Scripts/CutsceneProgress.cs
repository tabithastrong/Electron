using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneProgress : MonoBehaviour
{
    [Range(5f, 15f)]
    public float cutsceneEndTime = 11f;
    public string nextLevel = "Level 1";

    float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > cutsceneEndTime) {
            FindObjectOfType<FadePanel>().ChangeLevel(nextLevel);
        }
    }
}
