using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWall : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
   
    Vector2 pos;
    public GameObject wall;
    GameObject obs;
    private bool rising;
    void Start()
    {
      obs =Instantiate(wall);
      obs.SetActive(false);
      timer = time();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            RiseUpWall();
        }



    }
    void RiseUpWall()
    {
        if(!rising) {
            obs.SetActive(true);
            obs.transform.position = randPos();
            rising = true;
        }

        StartCoroutine(Delayed());

    }
    Vector2 randPos()
    { 
        float infacePos = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
        Vector2 rdpos = new Vector2(transform.position.x +infacePos, transform.position.y+transform.localScale.y);
        return rdpos;
    }

    IEnumerator Delayed()
    {
        yield return new WaitForSeconds(2f);
        obs.SetActive(false);
        timer = time();
        rising = false;

    }
    float time()
    {
        float time = Random.Range(1, 6);
        return time;
    }
}
