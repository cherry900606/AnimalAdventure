using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerChange : MonoBehaviour
{
    GameObject cap, bag;
    LayerMask invisible_layer_mask;
    // Start is called before the first frame update
    int level;
    void Start()
    {
        level = 0;
        cap = GameObject.FindGameObjectWithTag ("cap");
        bag = GameObject.FindGameObjectWithTag ("bag");
        cap.SetActive(false);
        bag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void trigger(Button button) {
        level = (level + 1) % 4;    
        if(level == 0)
        {
            cap.SetActive(false);
            bag.SetActive(false);
        }
        else if(level == 1)
        {
            cap.SetActive(false);
            bag.SetActive(true);
        }
        else if(level == 2)
        {
            cap.SetActive(true);
            bag.SetActive(false);
        }
        else
        {
            cap.SetActive(true);
            bag.SetActive(true);
        }
    }
}
