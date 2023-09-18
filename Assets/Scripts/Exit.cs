using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    public Treasure Looted;
    public Logic LogicScript;
    public PlayerController PlayerC;
    void Start()
    {
        //Looted = GameObject.FindGameObjectWithTag("Treasure").GetComponent<Treasure>();
        //LogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        // PlayerC = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Looted.ChestOpened == true)
        {
            LogicScript.Victory();
            Destroy(PlayerC.gameObject);
            Debug.Log("u escaped");

        }
    }
}
