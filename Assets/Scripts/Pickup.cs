using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    RESISTOR,
    LED,
    WIRE
}

public class Pickup : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject spriteObject;

    public PickupType type;

    public void Update() {
        spriteObject.transform.eulerAngles += new Vector3(0f, 0f, Time.deltaTime * rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        PlayerController player;
        if(player = collider.gameObject.GetComponent<PlayerController>()) {
            if(!player.HasPickup(type)) {
                player.Pickup(type);
                Destroy(gameObject);
            }
        }
    }
}
