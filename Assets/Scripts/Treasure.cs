using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{

    public bool ChestOpened = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            if (ChestOpened == false)
            {
                ChestOpened = true;

                Destroy(gameObject);
                Debug.Log("treasure has been looted");
            }
        }
    }
}
