using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishAreaTrigger : MonoBehaviour
{
    public Transform[] inToComplete;

    BoxCollider2D collider2D;

    AudioSource source;
    bool complete = false;
    
    void Start() {
        Destroy(GetComponent<SpriteRenderer>());
        collider2D = GetComponent<BoxCollider2D>();

        source = GetComponent<AudioSource>();
    }

    void Update() {
        if(IsLevelComplete() && !complete) {
            source.Play();
            complete = true;
            FindObjectOfType<LevelCompleteScreenUI>().LevelComplete();
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
