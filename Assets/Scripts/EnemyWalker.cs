using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{

    private Vector3 startPosition;
    SpriteRenderer spriteRenderer;
    public bool Flipped;
    public bool StartOver = false;
    public float StartFlipTime;
    public float LoopFlipTime;
    public float speed;
    public GameObject PLayer;


    [SerializeField]
    private float frequency = 5f;

    [SerializeField]
    private float magnitude = 5f;

    [SerializeField]
    private float offSet = 5f;
    public Alert Alerted;

    //public KILLMODE KillingTime;
    // public Logic LogicScript;



    // Start is called before the first frame update
    void Start()
    {
        //LogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        // KillingTime = GameObject.FindGameObjectWithTag("KILLMODE").GetComponent<KILLMODE>();
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (Flipped == true)
        {
            StartCoroutine(StartFlipOX());

        }
        else if (Flipped == false)
        {
            StartCoroutine(StartFlipX());

        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Alerted = GameObject.FindGameObjectWithTag("Alert").GetComponent<Alert>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Alerted.KillMode == true)
        {
            Debug.Log("playe locked");
            FollowPlayer();
        }

        else if (Alerted.KillMode == false)
        {

            transform.position = startPosition + transform.right * Mathf.Sin(Time.time * frequency + offSet) * magnitude;
            if (StartOver == true)
            {

                if (Flipped == false)
                {
                    StartCoroutine(SpriteFlipX());
                }
                else if (Flipped == true)
                {
                    StartCoroutine(SpriteFlipOX());
                }
            }
        }



    }

    private IEnumerator SpriteFlipX()
    {
        yield return new WaitForSecondsRealtime(LoopFlipTime);
        spriteRenderer.flipX = true;
        Flipped = true;
    }

    private IEnumerator SpriteFlipOX()
    {
        yield return new WaitForSecondsRealtime(LoopFlipTime);
        spriteRenderer.flipX = false;
        Flipped = false;
    }

    private IEnumerator StartFlipX()
    {
        yield return new WaitForSecondsRealtime(StartFlipTime);
        spriteRenderer.flipX = true;
        Flipped = true;
        StartOver = true;
    }

    private IEnumerator StartFlipOX()
    {
        yield return new WaitForSecondsRealtime(StartFlipTime);
        spriteRenderer.flipX = false;
        Flipped = false;
        StartOver = true;
    }

    public void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, PLayer.gameObject.transform.position, speed * Time.deltaTime);
    }
}
