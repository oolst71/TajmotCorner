using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{

    public int nextLevel;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ProtoPlayerController contr = collision.GetComponent<ProtoPlayerController>();
            if (contr.dashing)
            {
                Destroy(gameObject);
            }
            contr.LevelEnd(nextLevel);
        }
    }
}
