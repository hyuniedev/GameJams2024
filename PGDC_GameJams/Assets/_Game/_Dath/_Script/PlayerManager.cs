using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _players = new List<GameObject>();
    private void Start()
    {

    }
    void Update()
    {

    }

    public GameObject CheckNearestPlayer(GameObject thisPlayer)
    {
        foreach (GameObject player in _players)
        {
            if (player != thisPlayer)
            {
                return player;
            }
        }
        return null;
    }
}
