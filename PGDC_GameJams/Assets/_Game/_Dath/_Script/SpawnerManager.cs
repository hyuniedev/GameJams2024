using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [Header("Time Spawn")]
    float _timer = 0;
    private float _timeSpawn = 5f;

    //
    [Range(10, 200)][SerializeField] private float _distanceSpawn;
    [SerializeField] List<GameObject> _skills = new List<GameObject>();



    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = _timeSpawn;
            Spawn();
        }
    }

    void Spawn()
    {
        Vector2 randomPos = new Vector2(transform.position.x + Random.Range(-_distanceSpawn, _distanceSpawn), transform.position.y);
        int randomSkill = Random.Range(0, _skills.Count);
        Instantiate(_skills[randomSkill], randomPos, Quaternion.identity);
    }
}
