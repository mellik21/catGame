using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPatrol : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D npc;
    private static Animator npcAnimator;
    private Transform currentPoint;
    public float speed;

    public GameObject dialogueBox;

    private static bool isRunning;

    void Start()
    {
        npc = GetComponent<Rigidbody2D>();
        npcAnimator = GetComponent<Animator>();
        currentPoint = pointB.transform;
        npcAnimator.SetBool("isRunning", false);

        StartCoroutine(Waiter());
    }


    void Update()
    {
        bool dialogueActive = dialogueBox.activeInHierarchy;
        if (dialogueActive)
        {
            if (isRunning)
            {
                StopNpc();
            }
            return;
        }

        if (isRunning)
        {
            Vector2 point = currentPoint.position - transform.position;
            if (currentPoint == pointB.transform)
            {
                npc.velocity = new Vector2(-speed, npc.velocity.y);
            }
            else
            {
                npc.velocity = new Vector2(speed, npc.velocity.y);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
            {
                Flip();
                currentPoint = pointA.transform;
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
            {
                Flip();
                currentPoint = pointB.transform;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.2f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.2f);

        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

    private void Flip()
    {   
        gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
    }


    public static void StopNpc()
    {
        isRunning = false;
        npcAnimator.SetBool("isRunning", false);
    }


    public static void StartNpc()
    {
        isRunning = true;
        npcAnimator.SetBool("isRunning", true);
    }

    IEnumerator Waiter()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            isRunning = true;
            npcAnimator.SetBool("isRunning", true);


            yield return new WaitForSeconds(3);
            isRunning = false;
            npcAnimator.SetBool("isRunning", false);
        }
    }

}
