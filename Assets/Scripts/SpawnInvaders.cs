using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaders : MonoBehaviour
{

    [SerializeField]
    GameObject[] invasores;

    [SerializeField]
    GameObject[] invasoresIndestrutiveis;

    [SerializeField]
    int nInvasores = 7;

    [SerializeField]
    float xMin = -3f;

    [SerializeField]
    float yMin = -0.5f;

    [SerializeField]
    float xInc = 1f;

    [SerializeField]
    float yInc = 0.5f;

    [SerializeField]
    float probabilidadeDeIndestrutivel = 0.15f;

    float inicioMove = 2f;
    float tempo = 0f;

    [SerializeField]
    float movLat = 3f;

    float velocidade = 0.002f;

    float minX, maxX;
    bool mov = true;

    [SerializeField]
    float velocidadedown = 0.00005f;
  
    void Awake()
    {
    

        float y = yMin;
        for(int line = 0; line < invasores.Length; line++)
        {
            float x = xMin;
            for (int i = 1; i <= nInvasores; i++)
            {
                if(Random.value <= probabilidadeDeIndestrutivel)
                {
                    GameObject newInvader = Instantiate(invasoresIndestrutiveis[line], transform);
                    newInvader.transform.position = new Vector3(x, y, 0f);
                } else
                {
                    GameObject newInvader = Instantiate(invasores[line], transform);
                    newInvader.transform.position = new Vector3(x, y, 0f);
                }
                x += xInc;
            }
            y += yInc;
        }
    }

    void Start()
    {
        minX = Camera.main.ViewportToWorldPoint(Vector2.zero).x + movLat;
        maxX = Camera.main.ViewportToWorldPoint(Vector2.one).x - movLat;
    }
    void Update()
        {


        tempo += Time.deltaTime;

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;


        if (mov == true)
            {
                transform.position += velocidade * Vector3.right;
            transform.position += velocidade * Vector3.down;

            if (position.x == maxX)
                {
                    mov = false;
                }




            }

            if (mov == false)
            {
            transform.position -= velocidade * Vector3.right;
            transform.position -= velocidade * Vector3.down;

            if (position.x == minX)
                {
                mov = true;
                }


             

            }

    }
}
