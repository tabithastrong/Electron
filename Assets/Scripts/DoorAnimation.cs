using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    ControllableObject co;
    public Vector3 newDoorPos = Vector3.zero;
    [Range(0f, 5f)]
    public float transitionSpeed = 0.1f;

    Vector3 startPos;


    void Start() {
        co = GetComponent<ControllableObject>();
        startPos = transform.position;
    }

    void Update() {
        if(co.State) {
            transform.position = Vector3.Lerp(transform.position, startPos + newDoorPos, transitionSpeed * Time.deltaTime);
        } else {
            transform.position = Vector3.Lerp(transform.position, startPos, transitionSpeed * Time.deltaTime);
        }
    }
}
