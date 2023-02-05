using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManagement : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.TriggerEndGame(false);
        }
    }
}
