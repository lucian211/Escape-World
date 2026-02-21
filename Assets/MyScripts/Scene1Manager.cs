using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1Manager : MonoBehaviour
{
    bool win = false;
    bool lose = false;

    public GameObject meteor;
    public List<GameObject> SpawnPoint;
    private static System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        SpawnMeteor();
    }

    // Update is called once per frame
    void Update()
    {
        if (win == true)
        {
            win = false;
            PlayerPrefs.SetInt("Level", 2);
            SceneManager.LoadScene(0);
        }

        if (lose == true)
        {
            lose = false;
            PlayerPrefs.SetInt("Repeat", 1);
            SceneManager.LoadScene(0);
        }
    }

    public void Win()
    {
        win = true;
    }

    public void Lose()
    {
        lose = true;
    }

    public void SpawnMeteor()
    {
        
        int index = rnd.Next(SpawnPoint.Count);
        meteor.transform.position = SpawnPoint[index].transform.position;
        meteor.SetActive(true);
    }
}
