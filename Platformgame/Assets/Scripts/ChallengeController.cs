using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour {

    public float scrollerSpeed = 0.5f;
    public GameObject[] challenges;
    public float frequency = 5.0f;
    float counter = 0.0f;
    public Transform challengesSpawnPoint;
    bool isGameOver = false;

	// Use this for initialization
	void Start () {
        
        GenerateRandomChallenge();
	}
	
	// Update is called once per frame
	void Update () {
        if (isGameOver) return;

        //GenerateObjects
        if (counter <= 0.0f)
        {
            GenerateRandomChallenge();
        }
        else
        {
            counter -= Time.deltaTime * frequency;
        }

        //Scrolling 
        GameObject currentChild;
        for (int i=0; i< transform.childCount; i++) {
            currentChild = transform.GetChild(i).gameObject;
            ScrollChallenge(currentChild);
            if (currentChild.transform.position.x <= -15.0f)
            {
                Destroy(currentChild);
            }
        }
	}

    void ScrollChallenge (GameObject currentChallenge)
    {
        currentChallenge.transform.position -= Vector3.right * (scrollerSpeed * Time.deltaTime);

    }

    void GenerateRandomChallenge()
    {
        GameObject newChallenge = Instantiate(challenges[Random.Range(0, challenges.Length)], challengesSpawnPoint.position, Quaternion.identity) as GameObject;
        newChallenge.transform.parent = transform;
        counter = 1.0f;
    }
    public void GameOver()
    {
        isGameOver = true;
        transform.GetComponent<GameController>().GameOver();
  }
}
