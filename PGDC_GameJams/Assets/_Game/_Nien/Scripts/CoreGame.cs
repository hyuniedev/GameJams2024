using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class CoreGame : MonoBehaviour
{
    [SerializeField] private float _speedTime;
    [SerializeField] private Text _txtBoomTime;
    private static int _time = 15;
    private float _timer = 0;
    private bool isEnd = false;
    public ParticleSystem _deadParticle;
    public ParticleSystem _winParticle;
    public GameObject _winPanel;
    private void Start()
    {

    }
    void FixedUpdate()
    {
        TimeSystem();
        Victory();
    }
    public void ShockWave(Transform trans, float radius, float time, float boomForce)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            GameObject playerArround = collider.gameObject;

            if (playerArround.CompareTag("Player"))
            {
                playerArround.GetComponent<Rigidbody2D>().AddForce((playerArround.transform.position - transform.position).normalized * boomForce, ForceMode2D.Impulse);
                playerArround.GetComponent<IEvent>().HasEvent(time);
            }
        }
    }

    public void Replay()
    {
        Time.timeScale = 1;
        _time = 15;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Victory()
    {
        if (isEnd)
        {
            Time.timeScale = 0;
            _winPanel.SetActive(true);
            GameObject winner = null; // Initialize 'winner' variable to null
            foreach (var ch in FindObjectsOfType<Character>())
            {
                if (ch.gameObject.activeSelf) winner = ch.gameObject; // Assign 'winner' inside the loop
            }
            if (winner != null) // Check if 'winner' is not null
            {
                string vic = "Player " + winner.name + " Win";
                _winPanel.transform.GetChild(0).GetComponent<Text>().text = vic;
            }
        }
    }
    void TimeSystem()
    {
        if (isEnd) return;
        String g = _time.ToString().Length == 1 ? "0" + _time : _time + "";
        _txtBoomTime.text = "00" + ":" + g;
        _timer += Time.fixedDeltaTime * _speedTime;
        if (_timer > 1)
        {
            _time--;
            _timer = 0;
        }
        if (_time == 0)
        {
            Character[] charactors = FindObjectsOfType<Character>();
            foreach (var ch in charactors)
            {
                if (ch.HasBoom)
                {
                    ch.gameObject.SetActive(false);
                }
            }
            charactors = FindObjectsOfType<Character>();
            if (charactors.Length > 1)
            {
                charactors[0].changeStateBoom();
                resetTimeBoom();
            }
            if (charactors.Length == 1) isEnd = true;

        }
    }

    public static void resetTimeBoom()
    {
        _time = 15;
    }
}
