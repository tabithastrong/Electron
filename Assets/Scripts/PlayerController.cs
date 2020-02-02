using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;

    public string leftRightAxis = "Horizontal";
    public string jumpAxis = "Jump";
    public string interactButton = "Interact";
    public float jumpSpeed = 100f;
    public float superjumpSpeed = 500f;
    public float jumpCheckDistance = 0.1f;

    public bool InteractDown {
        get {
            return Input.GetButtonDown(interactButton);
        }
    }

    public Transform onGroundChecker;

    public GameObject resistorPickupChecker;

    Rigidbody2D rigidbody;

    public List<PickupType> pickups;

    public AudioClip jumpClip;
    public AudioClip superjumpClip;

    public AudioClip pickupClip;
    public AudioClip dropoffClip;

    AudioSource source;
    AudioSource pickupDropoffSource;

    float jumpTimer = 0f;
    bool isOnGround = false;
    bool hasUsedSuper = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        pickups = new List<PickupType>();
        source = GetComponent<AudioSource>();
        pickupDropoffSource = gameObject.AddComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(new Vector3(Input.GetAxis(leftRightAxis) * Time.deltaTime * movementSpeed, 0f, 0f), ForceMode2D.Impulse);

        if(Input.GetAxis(leftRightAxis) == 0) {
            rigidbody.AddForce(new Vector2(rigidbody.velocity.x * -0.5f, 0f), ForceMode2D.Impulse);
        }

        RaycastHit2D hit = Physics2D.Raycast(onGroundChecker.position, -onGroundChecker.up, jumpCheckDistance, ~LayerMask.GetMask("Pickups and Dropoffs"));
        
        jumpTimer = Mathf.Max(0f, jumpTimer - Time.deltaTime);
        
        if(hit && !hit.collider.isTrigger) {
            isOnGround = true;
            hasUsedSuper = false;
        } else {
            isOnGround = false;
        }

        if(Input.GetButtonDown(jumpAxis)) {
            if(jumpTimer <= 0f && isOnGround) {
                jumpTimer = 0.2f;

                rigidbody.AddForce(Vector2.up * jumpSpeed);

                source.clip = jumpClip;
                source.pitch = Random.Range(0.8f, 1.2f);
                source.Play();
            } else if(!isOnGround && !hasUsedSuper) {
                hasUsedSuper = true;
                rigidbody.AddForce(Vector2.up * superjumpSpeed);

                source.clip = superjumpClip;
                source.pitch = Random.Range(0.8f, 1.2f);
                source.Play();
                
            }
        }

        resistorPickupChecker.SetActive(this.HasPickup(PickupType.RESISTOR));
    }

    public void Pickup(PickupType type) {
        pickups.Add(type);

        pickupDropoffSource.clip = pickupClip;
        pickupDropoffSource.Play();
    }

    public bool HasPickup(PickupType type) {
        return pickups.Contains(type);
    }

    public void RemovePickup(PickupType type) {
        pickups.Remove(type);

        
        pickupDropoffSource.clip = dropoffClip;
        pickupDropoffSource.Play();
    }
}
