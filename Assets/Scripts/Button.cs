using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : ITrigger
{
    SpriteRenderer spriteRenderer;

    public Sprite offSprite;
    public Sprite onSprite;

    public bool state;

    int collidersOnButton = 0;

    void Start() {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
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
    }
    public override bool GetState() {
        return state;
    }
}
