using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        GameManager.instance.changeScene(name);
    }
}
