using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class gameplay_Manager : MonoBehaviour
{

    public string[] phrases = new string[] { "as hell", "as gall", "as hell", "as a bat", "as brasS", "as a lion", "as a button", "as a bee", "as a millpond", "as dirt", "as a whistle", "as day", "as mud", "as the grave", "as an elephant", "as marble", "as steel", "as a cucumber", "as a fox", "as death", "as a doornail", "as a post", "as a lord", "as dust", "as ditchwater", "as pie", "as a deer", "as a pig", "as a fiddle", "as a pancake", "as a daisy", "as a lamb", "as gold", "as new", "as grass", "as nails", "as a dove", "as lead", "as a kite", "as fire", "as a wolf", "as life", "as a feather", "as two peas", "as a hatter", "as a snake", "as a fruitcake", "As the hills", "as death", "as a church mouse", "as dirt", "as a picture", "as a peacock", "as a flash", "as a clockwork", "as rain", "as houses", "as a dog", "as a willow", "as a judge", "as a bell", "as a rock", "as hell", "as thieves", "as a stick", "as a dog", "as old boots", "as sin", "as toast", "as water", "as snow", "as a ghost" };
    public string[] answers = new string[] { "angry", "bitter", "black", "blind", "bold", "brave", "bright", "busy", "calm", "cheap", "clean", "clear", "clear", "close", "clumsy", "cold", "cold", "cool", "cunning", "dark", "dead", "drunk", "dry", "dull", "easy", "fast", "fat", "fit", "flat", "fresh", "gentle", "good", "good", "green", "hard", "harmless", "heavy", "high", "hot", "hungry", "large", "light", "like", "mad", "mean", "nutty", "old", "pale", "poor", "poor", "pretty", "proud", "quick", "regular", "right", "safe", "sick", "slim", "sober", "sound", "steady", "sure", "thick", "thin", "tired", "tough", "ugly", "warm", "weak", "white", "white" };
    public CinemachineVirtualCamera currentCamera;
    public CinemachineBrain cBrain;
    public GameObject target2;
    public GameObject target1;
    public TextMeshPro text;
    public TextMeshPro score;
    public int scorecount;
    public TextMeshPro endgame;
    public TMP_InputField input;
    public TextMeshProUGUI box;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.visible = true;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

    public void Play()
    {
        scorecount = 0;
        endgame.gameObject.SetActive(false);
        var dolly = currentCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        index = Random.Range(0, phrases.Length);
        box.text = "Check Answer";
        text.text = phrases[index];
        if(dolly.m_PathPosition < 1)
        {
            StartCoroutine(Move());
        }
    }

    public void Return()
    {
        StartCoroutine(Move());
    }

    public void CheckAnswer()
    {
        var finishedtext = input.text.ToLower();
        if(finishedtext == answers[index])
        {
            Debug.Log("Correct");
            scorecount++;
            index = Random.Range(0, phrases.Length);
            text.text = phrases[index];
            score.text = "Score: " + scorecount;
        }
        else
        {
            box.text = "Try again?";
            if(endgame.gameObject.active == true)
            {
                Play();
            }
            else
            {
                endgame.gameObject.SetActive(true);
            }
        }
    }
    
    IEnumerator Move()
    {
        Debug.Log("Running");
        var dolly = currentCamera.GetCinemachineComponent<CinemachineTrackedDolly>();

        if (dolly.m_PathPosition < 1)
        {
            while (dolly.m_PathPosition < 1)
            {
                currentCamera.LookAt = target2.transform;
                dolly.m_PathPosition += 0.01f;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            while (dolly.m_PathPosition > 0)
            {
                Debug.Log("Test");
                currentCamera.LookAt = target1.transform;
                dolly.m_PathPosition -= 0.01f;
                yield return new WaitForSeconds(0.1f);
            }
        }

    }
}