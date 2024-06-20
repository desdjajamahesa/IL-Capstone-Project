using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeSceneOnTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public float changeTime;
    public string sceneName;

    // Update is called once per frame
    private void Update()
    {
        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}