using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class button3Controller : MonoBehaviour
{
    public GameObject prefab;
    public TMP_Text  displayText;
    public bool gameStart;
    public AudioSource winSound;
    public AudioSource loseSound;
    public winLoseText status;

    public Image clock;

    public int time_max = 50;
    public TMPro.TextMeshProUGUI timer;

    public GameObject[] coins;

    // Start is called before the first frame update
    void Start()
    {
        displayText.text = "";
        timer.text = "";
        gameStart = false;
        winSound = GetComponent<AudioSource>();
        loseSound = GetComponents<AudioSource>()[1];
        coins = new GameObject[10];
        clock.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int score = GameObject.FindGameObjectWithTag ("Player").GetComponent<coinCollidor>().collisionCount;
        if(score == 10)
        {
            CancelInvoke("countDown");
            winSound.Play();
            GameObject.FindGameObjectWithTag ("Player").GetComponent<coinCollidor>().collisionCount = 0;
            gameStart = false;
            clock.enabled = false;
            status.Win();
            timer.text = "";
            //StartCoroutine(ClearTextAfterDelay(5f));
        }
        if(gameStart) displayText.text = "Score: " + score + "/10";
        else displayText.text = "";        
    }

    public void trigger(Button button) {
        InvokeRepeating("countDown", 0, 1);
        Debug.Log("Button Text: " + button.name);
        gameStart = true;
        clock.enabled = true;
        if(gameStart)
        {
            displayText.text = "Score: ";
            time_max = 50;
            GameObject.FindGameObjectWithTag ("Player").GetComponent<coinCollidor>().collisionCount = 0;
            
            for (int i = 0; i < 10; i++)
            {
                Vector3 randomPos = new Vector3(Random.Range(-10f, 10f), 0.7f, Random.Range(-10f, 10f));
                coins[i] = Instantiate(prefab, randomPos, Quaternion.identity);
            }
        }
    }

    public void countDown()
    {
        time_max -= 1;
        if (time_max <= 0) {
            timer.text = "Time up!!!";
            status.Lose();
            loseSound.Play();
            CancelInvoke("countDown");
            Reset();
        } else {
            timer.text = time_max + "";
        }
    }

    void Reset() {
        for(int i=0; i<10; i++)
        {
            if(coins[i] != null)
            {
                Destroy(coins[i]);
                coins[i] = null;
            }
        }
        gameStart = false;
        timer.text = "";
        //StartCoroutine(ClearTextAfterDelay(5f));
        clock.enabled =false;
    }

    IEnumerator ClearTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        timer.text = "";
    }

}
