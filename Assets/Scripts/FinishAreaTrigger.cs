using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class FinishAreaTrigger : MonoBehaviour
{
    public Transform[] inToComplete;

    BoxCollider2D collider2D;
    
    public float flashingSpeed = 10f;

    Light2D light;

    AudioSource source;
    bool complete = false;
    
    void Start() {
        Destroy(GetComponent<SpriteRenderer>());
        collider2D = GetComponent<BoxCollider2D>();

        source = GetComponent<AudioSource>();
        light = GetComponentInChildren<Light2D>();
    }

    void Update() {
        if(IsLevelComplete() && !complete) {
            source.Play();
            complete = true;

            if(SceneManager.GetActiveScene().name == "Level 6") {
                FindObjectOfType<LevelCompleteScreenUI>().LevelComplete(false);
                FindObjectOfType<FadePanel>().ChangeLevel("OutroCutscene");
            } else {
                FindObjectOfType<LevelCompleteScreenUI>().LevelComplete();
            }
        }

        if(complete) {
            light.intensity = 1f + (Mathf.Sin(Time.time * flashingSpeed) * 0.4f);
        }
    }

    bool IsLevelComplete() {
        foreach(DropoffPoint p in FindObjectsOfType<DropoffPoint>()) {
            if(!p.IsComplete) {
                return false;
            }
        }
        
        if(inToComplete.Length == 0) {
            return false;
        }

        foreach(Transform t in inToComplete) {
            if(!collider2D.bounds.Contains(t.position)) {
                return false;
            }
        }

        return true;
    }
}
