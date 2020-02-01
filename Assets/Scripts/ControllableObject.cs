using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableObject : MonoBehaviour
{
    public ITrigger[] controls;

    public Animator animator;

    public void Start() {
        animator = GetComponent<Animator>();
    }

    public void Update() {
        if(animator)
            animator.SetBool("IsTriggered", State);
    }

    public bool State {
        get {
            foreach(ITrigger t in controls) {
                if(t.GetState() == true) {
                    return true;
                }
            }

            return false;
        }
    }
}
