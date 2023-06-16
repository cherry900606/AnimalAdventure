using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollidor : MonoBehaviour
{
    public int collisionCount;
    public AudioSource coinSound;
    // Start is called before the first frame update
    void Start()
    {
        collisionCount = 0;
        coinSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "coin")
        {
            collisionCount = collisionCount + 1;
            Debug.Log("Coin collision :" + collisionCount);
            Destroy(other.gameObject);

            coinSound.Play();
        }
    }
}
