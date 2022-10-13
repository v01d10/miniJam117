using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    void Awake() {instance = this;}

    public Animator transition;
    public GameObject player;
    public GameObject UI;
    public GameObject mainCam;

    public bool outside = false;

    public float transitionTime = 1f;


    public void LoadBasement()
    {
        StartCoroutine(LoadLevel(1));
        outside = false;
    }

    public void LoadOutside()
    {
       StartCoroutine(LoadLevel(2));
       outside = true;
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
