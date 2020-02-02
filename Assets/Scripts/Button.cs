using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : ITrigger
{
    SpriteRenderer spriteRenderer;

    public Sprite offSprite;
    public Sprite onSprite;

    public bool state;
    bool oldState = false;

    int collidersOnButton = 0;

    AudioSource source;

    void Start() {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collider) {
        collidersOnButton++;
    }

    void OnTriggerExit2D(Collider2D collider) {

        collidersOnButton--;
    }
    void Update() {
        if(collidersOnButton > 0) {
            spriteRenderer.sprite = onSprite;
            state = true;
        } else {
            spriteRenderer.sprite = offSprite;
            state = false;
        }

        if(oldState != state) {
            source.Play();
        }

        oldState = state;
    }
    public override bool GetState() {
        return state;
    }
}
