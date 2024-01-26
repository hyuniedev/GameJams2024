using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class FlatFormMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector2 dir;
    public float distance;
    public LayerMask Wall;
    public bool moving;
    public bool stopMoving = false;
    public float timer;
    float targetAngle= 90;
    public float rotateSpeed;

    void Start()
    {
        timer = 5;
    }
    private void OnEnable()
    {
      
        moving = false;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stopMoving) {
            FlatMove();
        }
        timer -= Time.fixedDeltaTime; 
        if (timer <= 0 ) {
            Rotation();
        }
        
       
    }
    private void FlatMove()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, distance, Wall);
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Vector2.left, distance, Wall);
        if(!moving)
        {
            dir = randVector();
            
            moving = true;
           
        }
        Debug.Log(dir);
        if (hit || hit1)
        {
          dir.x = dir.x * -1;
        }
        transform.Translate(dir * speed * Time.fixedDeltaTime);

    }
    Vector2 randVector()
    {

        Vector2[] ListVector = { Vector2.left, Vector2.right };
        Vector2 rdvector = ListVector[Random.Range(0, 2)];
        
        return rdvector;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.left * distance);
    }
    void Rotation()
    {
        /*Quaternion newRotation = Quaternion.Euler(0f, 0, 90f);
        transform.Rotate(Vector3.forward, 2 * Time.fixedDeltaTime);
        transform.rotation = newRotation;*/
        
        float angleToRotate = targetAngle - transform.rotation.eulerAngles.z;

        // Sử dụng hàm RotateTowards để quay đến góc đích
        float rotateAmount = Mathf.Min(rotateSpeed * Time.deltaTime, Mathf.Abs(angleToRotate));
        transform.Rotate(Vector3.forward, rotateAmount * Mathf.Sign(angleToRotate));

        stopMoving = true;
        StartCoroutine(Delayed());
    }
    IEnumerator Delayed()
    {
        yield return new WaitForSeconds(2f);
        Quaternion newRotation = Quaternion.Euler(0f, 0, 0);
        transform.rotation = newRotation;
        stopMoving = false;
        timer = 5;

    }

   

}
