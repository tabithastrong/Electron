using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLevelLights : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = transform.childCount - 1; i >= 0; i--) {
            GameObject go = transform.GetChild(i).gameObject;
            if(go.name.StartsWith("Level")) {
                int levelID = int.Parse(go.name.Split(' ')[1]);

                //if it hasnt been complete 
                if(!PlayerPrefs.HasKey(go.name) || PlayerPrefs.GetInt(go.name) != 1) { 

                    //the one before it has 
                    if((PlayerPrefs.HasKey("Level " + (levelID - 1)) && PlayerPrefs.GetInt("Level " + (levelID - 1)) == 1) || levelID == 1) {
                        go.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().enabled = false;
                    } else {
                        //else delete
                        Destroy(go);
                    }
                }
            }
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
