using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBlock : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ProtoPlayerController contr = collision.collider.GetComponent<ProtoPlayerController>();
            if (contr.dashing)
            {
                Destroy(gameObject);
            }
        }
    }

    
}
