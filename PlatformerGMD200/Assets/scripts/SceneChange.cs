using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = 0;
        if(currentSceneIndex +1 < SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = currentSceneIndex +1;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
