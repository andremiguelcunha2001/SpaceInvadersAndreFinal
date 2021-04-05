using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField]
    GameObject fire;

    //   [SerializeField]
    //  float cadencia = 1.5f;

    //  float tempoQuePassou = 0f;
    public float minFireRateTime = 1.0f; 
    public float maxFireRateTime = 3.0f; 
    public float baseFireWaitTime = 3.0f;

    [SerializeField]
    float vidasInvasores = 10f;

    void Start()
    {
        baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

    }

    void FixedUpdate()
    {
        if (tag == "Destrutivel")
        {
            if (Time.time > baseFireWaitTime)
            {

                baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

                Instantiate(fire, transform.position, Quaternion.identity);

            }

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Destrutivel")
        {
            if (collision.gameObject.tag == "ProjectilAmigo")
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        } else
        {
            vidasInvasores -= 1;

            if (vidasInvasores < 1)
            {

                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
