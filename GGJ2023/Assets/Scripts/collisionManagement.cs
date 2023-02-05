using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManagement : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("MEEEEEEEEEEEEEEEEEEERDE J'AI PERDUUUUU");
            Destroy(gameObject);
        }
    }
}
