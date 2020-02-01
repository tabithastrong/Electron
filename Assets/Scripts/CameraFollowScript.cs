using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform[] objectsToFollow;
    Vector3 vel;

    int playerToTrack = 0;
    int actualPlayerToTrack = 0;

    void Update() {
        Vector3 pos = Vector3.SmoothDamp(transform.position, GetCenter(), ref vel, 1f, 20f);
        pos.z = -10f;
        transform.position = pos;

        if(Input.GetButtonDown("RequestFocus")) {
            playerToTrack = playerToTrack == 1 ? 0 : 1;
        } else if(Input.GetButtonDown("RequestFocusPlayerTwo")) {
            playerToTrack = playerToTrack == 2 ? 0 : 2;
        }
    }

    Vector3 GetCenter() {
        float playerOneInput = Mathf.Abs(Input.GetAxis("Horizontal") + Input.GetAxis("Jump") + Input.GetAxis("Superjump"));
        float playerTwoInput = Mathf.Abs(Input.GetAxis("HorizontalPlayerTwo") + Input.GetAxis("JumpPlayerTwo") + Input.GetAxis("SuperjumpPlayerTwo"));

        if(playerToTrack == 0) {
            if(playerOneInput > playerTwoInput) {
                actualPlayerToTrack = 1;
            } else if(playerOneInput < playerTwoInput) {
                actualPlayerToTrack = 2;
            }
        } else {
            actualPlayerToTrack = playerToTrack;
        }

        if(objectsToFollow.Length == 1) {
            return objectsToFollow[0].position;
        }

        if(actualPlayerToTrack == 0) {

            Vector3 average = Vector3.zero;

            foreach(Transform t in objectsToFollow) {
                average += t.position;
            }

            return average / objectsToFollow.Length;
        } else {
            return objectsToFollow[actualPlayerToTrack - 1].position;
        }
    }
}
