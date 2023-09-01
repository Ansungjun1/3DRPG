using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private bool isOn = false;
    public GameObject canvas;

    public void SceneLoad()
    {
        SceneManager.LoadScene(0);
    }

    public void TrueIsOn()
    {
        isOn = true;
        canvas.SetActive(true);
    }

    private void Update()
    {
        if(isOn && Input.GetKeyDown(KeyCode.Space))
        {
            SceneLoad();
        }
    }
}
