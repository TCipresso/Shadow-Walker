using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{

    private float speed = 1.5f;
    //public GameObject Player;
    //public PlayerController PlayerC;
    public bool KillMode = false;
    // Start is called before the first frame update
    void Start()
    {
        // PlayerC = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //FollowPlayer();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //LogicScript.Victory(); Game Over Screen here
            KillMode = true;

        }
    }
}
