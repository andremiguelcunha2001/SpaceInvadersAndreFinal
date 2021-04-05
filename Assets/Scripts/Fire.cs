using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    float force = 500000f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (tag == "Nave")
        {
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
