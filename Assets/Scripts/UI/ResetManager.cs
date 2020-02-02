using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetManager : MonoBehaviour
{
    [Range(1, 10)]
    public int resetSeconds = 2;
    public Text uiText;
    
    Animator uiTextAnimator;

    public GameObject playerOneRequest;
    public GameObject playerTwoRequest;

    float countdown = 0f;
    int lastSecond = -1;

    void Start() {
        uiTextAnimator = uiText.GetComponent<Animator>();
    }

    void Update() {
        if(Input.GetButton("Reset") && Input.GetButton("ResetPlayerTwo")) {

            if(lastSecond > 0) {
                uiText.text = "" + (lastSecond);
            } else {
                uiText.text = "";
            }

            playerOneRequest.SetActive(false);
            playerTwoRequest.SetActive(false);

            if(!uiText.gameObject.activeSelf) {
                uiText.gameObject.SetActive(true);
                countdown = resetSeconds;
            }

            if(countdown <= 0f) {
                FindObjectOfType<FadePanel>().ResetLevel();
            }

            countdown -= Time.deltaTime;

            int second = Mathf.CeilToInt(countdown);

            if(second != lastSecond) {
                uiTextAnimator.SetTrigger("ZoomAgain");
            }

            lastSecond = second;
            
        } else {
            countdown = 0f;
            uiText.gameObject.SetActive(false);

            playerOneRequest.SetActive(Input.GetButton("Reset"));
            playerTwoRequest.SetActive(Input.GetButton("ResetPlayerTwo"));
        }
    }
}
