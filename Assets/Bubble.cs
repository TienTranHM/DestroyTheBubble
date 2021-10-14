using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Vector2 startForce;
    public Rigidbody2D rb;
    public GameObject nextBubble;
    public GameObject bubble;

    void Start()
    {
        rb.AddForce(startForce, ForceMode2D.Impulse);
    }

    public void Split()
    {
        if(nextBubble != null)
        {
            GameObject bubble1 = Instantiate(nextBubble, rb.position + Vector2.right / 0.7f, Quaternion.identity);
            GameObject bubble2 = Instantiate(nextBubble, rb.position + Vector2.left / 0.7f, Quaternion.identity);

            bubble1.GetComponent<Bubble>().startForce = new Vector2(5f, 5f);
            bubble2.GetComponent<Bubble>().startForce = new Vector2(-5f, 5f);
        }
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Bullet")
        {
            Split();
            Destroy(bubble);
            //Debug.Log("Split it");
        }
    }
}
