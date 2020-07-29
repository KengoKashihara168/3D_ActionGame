using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneManager : MonoBehaviour
{
    private readonly string TitleScene = "TitleScene";
    private readonly float ChangeSceneTime = 5.0f;

    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > ChangeSceneTime)
        {
            SceneManager.LoadScene(TitleScene);
        }
    }
}
