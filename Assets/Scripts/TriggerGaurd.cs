using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGaurd : MonoBehaviour
{
    public PlayerController Player;
    public Logic LogicScript;



    void Start()
    {
        // Player = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>();
        // LogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>()
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //LogicScript.Victory(); Game Over Screen here
            Destroy(Player.gameObject);
            LogicScript.GameOver();


        }
    }
}
