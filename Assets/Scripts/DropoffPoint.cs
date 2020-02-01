using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropoffPoint : MonoBehaviour
{
    public PickupType dropoffType;
    public GameObject revealWhenComplete;
    public GameObject[] hideWhenComplete;

    bool complete = false;

    public bool IsComplete {
        get {
            return complete;
        }
    }

    void Start() {
        revealWhenComplete.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        PlayerController player;

        if(player = collider.gameObject.GetComponent<PlayerController>()) {
            if(player.HasPickup(dropoffType)) {
                player.RemovePickup(dropoffType);
                complete = true;
                revealWhenComplete.SetActive(true);

                foreach(GameObject go in hideWhenComplete) {
                    go.SetActive(false);
                }
            }
        }
    }
}
