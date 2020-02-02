using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneEndText : MonoBehaviour
{
    float timer = 0f;
    public float time = 7f;

    public Text text;

    void Start() {
        text.color = new Color(1f, 1f, 1f, 0f);
    }

    void Update() {
        timer += Time.deltaTime;
        if(timer >= time) {
            text.color = Color.Lerp(text.color, new Color(1f, 1f, 1f, 1f), 0.01f);
        }
    }
}
