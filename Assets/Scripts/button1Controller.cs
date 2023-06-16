using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class button1Controller : MonoBehaviour
{
    public Material skybox;
    public GameObject shower;
    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void trigger(Button button) {
        Debug.Log("Button Text: " + button.name);
        RenderSettings.skybox = skybox;
        shower.SetActive(false);
        backgroundMusic.Play();
    }
}
