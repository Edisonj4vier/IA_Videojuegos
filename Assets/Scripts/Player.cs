using UnityEngine;
public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Animator anim;
    public Transform eje;
    
    public bool inground;
    private RaycastHit hit;
    public float distanciadesuelo;
    public Vector3 v3;
    
    void Update()
    {
        if (Physics.Raycast(transform.position + v3, transform.up * -1, out hit, distanciadesuelo))
        {
            if (hit.collider.tag == "suelo")
            {
                inground = true;
            }
        }
        else
        {
            inground = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + v3, transform.up * -1 * distanciadesuelo);
    }

    void Move()
    {
        Vector3 RotaTragetZ = eje.transform.forward;
        RotaTragetZ.y = 0;
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RotaTragetZ), 0.3f);
            var dir = transform.forward * (speed * Time.fixedDeltaTime);
            dir.y = rb.velocity.y;
            rb.velocity = dir;
            anim.SetBool("run", true);
        }
        else
        {
            if (inground)
            {
                rb.velocity = Vector3.zero;
            }
            anim.SetBool("run", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RotaTragetZ*-1), 0.3f);
            var dir = transform.forward*speed*Time.fixedDeltaTime;
            dir.y = rb.velocity.y;
            rb.velocity = dir;
            anim.SetBool("run", true);
        }
        Vector3 RotaTragetX = eje.transform.right;
        RotaTragetX.y = 0;
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RotaTragetX), 0.3f);
            var dir = transform.forward*speed*Time.fixedDeltaTime;
            dir.y = rb.velocity.y;
            rb.velocity = dir;
            anim.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RotaTragetX*-1), 0.3f);
            var dir = transform.forward*speed*Time.fixedDeltaTime;
            dir.y = rb.velocity.y;
            rb.velocity = dir;
            anim.SetBool("run", true);
        }
        
    }

    private void FixedUpdate()
    {
        Move();
    }
}
