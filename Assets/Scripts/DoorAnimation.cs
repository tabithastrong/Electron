using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    ControllableObject co;
    public Vector3 newDoorPos = Vector3.zero;
    public Vector3 newDoorRot = Vector3.zero;

    [Range(0f, 5f)]
    public float transitionSpeed = 0.1f;

    public bool rotationMode = false;

    Vector3 startPos;
    Quaternion startRot;
    Quaternion newRot;

    AudioSource source;

    bool lastState = false;

    public bool inverted = false;


    void Start() {
        co = GetComponent<ControllableObject>();
        lastState = co.State;

        startPos = transform.position;
        startRot = transform.rotation;

        source = GetComponent<AudioSource>();

        if(GetComponent<SpriteRenderer>()) {
            GetComponent<SpriteRenderer>().color = co.color;
        }

        foreach(SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>(true)) {
            sr.color = co.color;
        }

        if(rotationMode) {
            newRot =  Quaternion.Euler(startRot.eulerAngles + newDoorRot);
        }
    }

    void Update() {

        bool state = inverted ? !co.State : co.State;

        if(state) {
            if(rotationMode) {
                transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * transitionSpeed);
            } else {
                transform.position = Vector3.Lerp(transform.position, startPos + newDoorPos, transitionSpeed * Time.deltaTime);
            }
        } else {
            if(rotationMode) {
                transform.rotation = Quaternion.Lerp(transform.rotation, startRot, Time.deltaTime * transitionSpeed);
            } else {
                transform.position = Vector3.Lerp(transform.position, startPos, transitionSpeed * Time.deltaTime);
            }
        }

        if(lastState != state) {
            source.Play();
        }

        lastState = state;
    }
}
