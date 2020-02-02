using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneProgress : MonoBehaviour
{
    float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 10f) {
            FindObjectOfType<FadePanel>().ChangeLevel("Level 1");
        }
    }
}
