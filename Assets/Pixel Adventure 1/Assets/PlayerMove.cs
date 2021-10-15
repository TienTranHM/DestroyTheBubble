using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 8f;
    public float MaxVelocity = 4f;
    public GameObject Bullet;

    [SerializeField]
    private Rigidbody2D Body;
    private Animator Anim;

    private void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveKeyBoard();
        Fire();
    }

    void MoveKeyBoard()
    {
        float Forxe = 0f;
        float vel = Mathf.Abs(Body.velocity.x);
        float h = Input.GetAxis("Horizontal");

        if (h > 0)
        {
            if (vel < MaxVelocity)
                Forxe = Speed;
            Anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            if (vel < MaxVelocity)
                Forxe = -Speed;
            Anim.SetBool("Walk", true);
        }
        else Anim.SetBool("Walk", false);
        

        Body.AddForce(new Vector2(Forxe, 0));   
    }    

    void Fire()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = (GameObject)(Instantiate(Bullet, transform.position + transform.up * 0.5f, Quaternion.identity));
            b.GetComponent<Rigidbody2D>().AddForce(transform.up * 400);
            
        }
    }    
}
