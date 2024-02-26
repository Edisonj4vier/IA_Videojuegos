using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int runtina;
    public float cronometro;
    public Animator anim;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
          

    void Start()
    {
        anim = GetComponent<Animator>();
        target =GameObject.Find("Player");
    }
    
    void Update()
    {
        ComportamientoEmeny();
    }

    public void ComportamientoEmeny()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            anim.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                runtina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (runtina)
            {
                case 0:
                    anim.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    runtina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward *1 * Time.deltaTime);
                    anim.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
            anim.SetBool("walk", false);
            
            anim.SetBool("run", true);
            transform.Translate(Vector3.forward * (2 * Time.deltaTime));
            
        }
    }
}
