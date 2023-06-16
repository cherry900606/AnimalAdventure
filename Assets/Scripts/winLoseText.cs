using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winLoseText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public float showTime;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        showTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        showTime += Time.deltaTime;
        if(showTime > 5)
            text.text = "";
    }

    public void Win()
    {
        text.text = "You Win!";
        showTime = 0;
        
    }

    public void Lose()
    {
        text.text = "You Lose!";
        showTime = 0;
    }
}
