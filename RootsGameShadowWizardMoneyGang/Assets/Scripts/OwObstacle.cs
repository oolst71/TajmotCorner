using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwObstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ProtoPlayerController contr = collision.collider.GetComponent<ProtoPlayerController>();
            contr.OnDeath();
        }
    }
}
