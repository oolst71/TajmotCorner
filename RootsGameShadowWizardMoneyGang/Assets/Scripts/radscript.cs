using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class radscript : MonoBehaviour
{
    public GameObject ally;

    public float movespeed;

    public float distance;

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

        distance = Vector2.Distance(transform.position, ally.transform.position);

        if (distance > 40)
        {
            movespeed = 20;
        } else
        {
            movespeed = 3 + (17 * distance / 40);
        }

        if (ally.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        } else
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        transform.position = Vector2.MoveTowards(transform.position, ally.transform.position, movespeed * Time.deltaTime);
    }
}
