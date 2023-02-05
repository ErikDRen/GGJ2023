using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _loosePanel;
    [SerializeField] private PlayerMovement _player;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void TriggerEndGame(bool isWinner)
    {
        _player.CanMove = false;
        if(isWinner)
        {
            _winPanel.SetActive(true);
        }
        else
        {
            _loosePanel.SetActive(true);
        }
    }
    public void changeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
