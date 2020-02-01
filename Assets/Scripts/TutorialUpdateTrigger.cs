using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TutorialUpdateTrigger : MonoBehaviour
{
    public string text = "Enter tutorial text here!";
    public UnityEngine.UI.Text uiText;
    bool activated = false;

    float timer = 0f;

    void Start() {
        Destroy(GetComponent<SpriteRenderer>());
    }

    void Update() {
        if(activated) {
            timer += Time.deltaTime;

            if(timer >= 2f) {
                Destroy(gameObject);
            } else if(timer >= 1f) {
                float alpha = Mathf.Lerp(uiText.color.a, 1f, 0.1f);

                Color c = new Color(1f, 1f, 1f, alpha);
                uiText.color = c;
                uiText.text = text;

            } else if(timer >= 0f) {
                float alpha = Mathf.Lerp(uiText.color.a, 0f, 0.1f);

                Color c = new Color(1f, 1f, 1f, alpha);
                uiText.color = c;
            }
        }
    }

    public void OnTriggerEnter2D() {
        if(!activated) {
            activated = true;
        }
    }
}
