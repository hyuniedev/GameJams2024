using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class JumpingCushion : MonoBehaviour
{
    // Start is called before the first frame update
    public float force=12 ;
    public bool Jump=false ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("jump");
        
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
           
            if (rb != null  )
            {
               
                
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
               

                // Tính toán và áp dụng lực theo hướng y (lên) để tạo ra quỹ đạo parabol
                Vector2 jumpForce = new Vector2(0, force);
               
                // Áp dụng lực
                rb.AddForce(jumpForce, ForceMode2D.Impulse);
                
                StartCoroutine(Delayed(rb));  
                
            }
           
            
        }
    }
   
    IEnumerator Delayed(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;

    }






}
