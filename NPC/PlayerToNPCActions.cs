using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerToNPCActions : MonoBehaviour
{
    private Collider2D myCollider;
    public GameObject player;

    private void Start()
    {
        myCollider = gameObject.GetComponent<Collider2D>();
        Collider2D playerCollider = player.gameObject.GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(playerCollider, myCollider, true);
    }

}
