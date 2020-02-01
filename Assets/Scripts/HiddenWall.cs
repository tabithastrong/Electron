using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GetComponent<SpriteRenderer>());   
    }
}
