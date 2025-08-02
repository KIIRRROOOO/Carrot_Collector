using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed;
    public Transform spawnPosition;
    public float maxX;
    public float maxY;
    public TextMeshProUGUI Score;
    float hInput, vInput;
    int score = 0;

    public GameObject Carrot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        hInput = joystick.Horizontal * moveSpeed;
        vInput = joystick.Vertical * moveSpeed;

        transform.Translate(hInput, vInput, 0);
    }

    private void SpawnCarrot()
    {
        Vector3 spawn = spawnPosition.position;
        spawn.x = Random.Range(-maxX, maxX);
        spawn.y = Random.Range(-maxY, maxY);
        Instantiate(Carrot, spawn, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Carrot")
        {
            score++;
            Destroy(collision.gameObject);
            Score.text = "Score: " + score.ToString();
            moveSpeed = moveSpeed + 0.01f;
            SpawnCarrot();
        }
    }
}
