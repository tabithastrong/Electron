using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;

    public string leftRightAxis = "Horizontal";
    public string jumpAxis = "Jump";
    public string superjumpAxis = "Superjump";
    public float jumpSpeed = 100f;
    public float superjumpSpeed = 500f;
    public float jumpCheckDistance = 0.1f;

    public Transform onGroundChecker;

    public GameObject resistorPickupChecker;

    Rigidbody2D rigidbody;

    public List<PickupType> pickups;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        pickups = new List<PickupType>();
    }
    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(new Vector3(Input.GetAxis(leftRightAxis) * Time.deltaTime * movementSpeed, 0f, 0f), ForceMode2D.Impulse);

        if(Input.GetAxis(leftRightAxis) == 0) {
            rigidbody.AddForce(new Vector2(rigidbody.velocity.x * -0.5f, 0f), ForceMode2D.Impulse);
        }

        if(Input.GetButtonDown(jumpAxis)) {
            RaycastHit2D hit = Physics2D.Raycast(onGroundChecker.position, -onGroundChecker.up, jumpCheckDistance, ~LayerMask.GetMask("Pickups and Dropoffs"));
            if(hit && !hit.collider.isTrigger) {
                rigidbody.AddForce(Vector2.up * jumpSpeed);
            }
        }

        if(Input.GetButtonDown(superjumpAxis)) {
            RaycastHit2D hit = Physics2D.Raycast(onGroundChecker.position, -onGroundChecker.up, jumpCheckDistance, ~LayerMask.GetMask("Pickups and Dropoffs"));
            if(hit && !hit.collider.isTrigger) {
                rigidbody.AddForce(Vector2.up * superjumpSpeed);
            }
        }

        resistorPickupChecker.SetActive(this.HasPickup(PickupType.RESISTOR));
    }

    public void Pickup(PickupType type) {
        pickups.Add(type);
    }

    public bool HasPickup(PickupType type) {
        return pickups.Contains(type);
    }

    public void RemovePickup(PickupType type) {
        pickups.Remove(type);
    }
}
