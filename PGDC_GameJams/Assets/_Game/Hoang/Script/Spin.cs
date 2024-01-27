using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector2 dir;
    public float distance;
    public LayerMask Wall;
    public bool moving;
    public bool stopMoving = false;
    public float timer;

    public float rotateSpeed;
    public bool rotting;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = time();
        timer -= Time.deltaTime;  
    }
    void Rotation()
    {


        // Sử dụng hàm RotateTowards để quay đến góc đích
        float rotateAmount = Mathf.Min(rotateSpeed * Time.deltaTime, 180);
        if (rotting)
        {
            transform.Rotate(Vector3.forward, rotateAmount * Mathf.Sign(180));
        }


        stopMoving = true;
       
    }
  
    float time()
    {
        float time = Random.Range(1, 15);
        return time;
    }
}
