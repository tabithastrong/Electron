using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : ITrigger
{
    SpriteRenderer spriteRenderer;

    public Sprite offSprite;
    public Sprite onSprite;

    public bool state;

    List<PlayerController> playersOnButton = new List<PlayerController>();
    AudioSource source;

    void Start() {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collider) {
        PlayerController pc = collider.gameObject.GetComponent<PlayerController>();
        if(pc) {
            playersOnButton.Add(pc);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        PlayerController pc = collider.gameObject.GetComponent<PlayerController>();
        if(pc) {
            playersOnButton.Remove(pc);
        }
    }
    void Update() {
        foreach(PlayerController pc in playersOnButton) {
            if(pc.InteractDown) {
                state = !state;
                source.Play();
            }
        }

        spriteRenderer.sprite = state ? onSprite : offSprite;
    }
    public override bool GetState() {
        return state;
    }
}
