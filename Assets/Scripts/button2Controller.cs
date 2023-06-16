using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class button2Controller : MonoBehaviour
{
    public Material skybox;
    public GameObject shower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void trigger(Button button) {
        Debug.Log("Button Text: " + button.name);
        RenderSettings.skybox = skybox;
        shower.SetActive(true);
        GameObject.FindObjectOfType<button1Controller>().GetComponent<AudioSource>().Pause();
    }
}
