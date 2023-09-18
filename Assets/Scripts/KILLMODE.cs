using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILLMODE : MonoBehaviour
{
    public bool KillMode = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
