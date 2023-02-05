using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        GameManager.instance.changeScene(name);
    }

    public void ReloadScene()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
