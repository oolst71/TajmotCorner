using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class radscript : MonoBehaviour
{
    public GameObject ally;


    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (ally.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        } else
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        transform.position = Vector2.MoveTowards(transform.position, ally.transform.position, 7 * Time.deltaTime);
    }
}
