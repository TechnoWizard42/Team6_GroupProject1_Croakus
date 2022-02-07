using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    Rigidbody2D rigidbody2d;
    public bool vertical;
    public bool negVertical;
    public bool horizontal;
    public bool negHorizontal;

    public bool OnEaten;

    AudioSource audioSource;

    public AudioClip hitSound;
    public AudioClip gameMusic;
    public AudioClip pickUp;

    public GameObject winMusic;
    public GameObject loseMusic;

    public Animator animator;

    public GameObject life3;
    public GameObject life2;
    public GameObject life1;

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;

    public GameObject powerUp;
    public GameObject powerUp2;
    public GameObject powerUp3;
    public GameObject powerUp4;

    int direction = 1;

    private float pointsValue;
    public Text pointsText;

    public Text winText;
    public Text loseText;

    public int health;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        pointsText.text = pointsValue.ToString();
        pointsValue = 0;
        health = 3;

        SetWinText();
        winText.text = "";
        SetLoseText();
        loseText.text = "";

        OnEaten = false;
        PlaySound(gameMusic);

        winMusic.SetActive(false);
        loseMusic.SetActive(false);
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            vertical = true;
            horizontal = false;
            negVertical = false;
            negHorizontal = false;
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 1);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = true;
            negHorizontal = false;
            vertical = false;
            negVertical = false;
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("MoveX", 1);
            animator.SetFloat("MoveY", 0);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            negVertical = true;
            negHorizontal = false;
            vertical = false;
            horizontal = false;
            position.y = position.y + Time.deltaTime * speed * -direction;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", -1);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            negHorizontal = true;
            negVertical = false;
            vertical = false;
            horizontal = false;
            position.x = position.x + Time.deltaTime * speed * -direction;
            animator.SetFloat("MoveX", -1);
            animator.SetFloat("MoveY", 0);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("Quit game");
            Application.Quit();
        }

        rigidbody2d.MovePosition(position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Collectible")
        {
            pointsValue += 10;
            Destroy(collision.collider.gameObject);
            pointsText.text = pointsValue.ToString();
            SetWinText();
        }

        if (collision.collider.tag == "RightTeleporter")
        {
            transform.position = new Vector2(-3.5f, 1.45f);
            PlaySound(pickUp);
        }

        if (collision.collider.tag == "LeftTeleporter")
        {
            transform.position = new Vector2(3.5f, 1.45f);
            PlaySound(pickUp);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Enemy")) && health <= 3)
        {
            health -= 1;
            transform.position = new Vector2(0.03f, 0.47f);
            PlaySound(hitSound);
        }

        if ((other.gameObject.CompareTag("Enemy")) && health == 2)
        {
            Destroy(life3);
            transform.position = new Vector2(0.03f, 0.47f);
            PlaySound(hitSound);
        }

        if ((other.gameObject.CompareTag("Enemy")) && health == 1)
        {
            Destroy(life2);
            transform.position = new Vector2(0.03f, 0.47f);
            PlaySound(hitSound);
        }

        if ((other.gameObject.CompareTag("Enemy")) && health == 0)
        {
            Destroy(life1);
            SetLoseText();
            PlaySound(hitSound);
        }

        if ((other.gameObject.CompareTag("PowerUp")))
        {
            OnEaten = true;
            PlaySound(pickUp);
            StartCoroutine(EnemyInvisible());
            Enemy1.SetActive(false);
            Enemy2.SetActive(false);
            Enemy3.SetActive(false);
            Enemy4.SetActive(false);
            powerUp.SetActive(false);
        }

        if ((other.gameObject.CompareTag("PowerUp2")))
        {
            OnEaten = true;
            PlaySound(pickUp);
            StartCoroutine(EnemyInvisible());
            Enemy1.SetActive(false);
            Enemy2.SetActive(false);
            Enemy3.SetActive(false);
            Enemy4.SetActive(false);
            powerUp2.SetActive(false);
        }

        if ((other.gameObject.CompareTag("PowerUp3")))
        {
            OnEaten = true;
            PlaySound(pickUp);
            StartCoroutine(EnemyInvisible());
            Enemy1.SetActive(false);
            Enemy2.SetActive(false);
            Enemy3.SetActive(false);
            Enemy4.SetActive(false);
            powerUp3.SetActive(false);
        }

        if ((other.gameObject.CompareTag("PowerUp4")))
        {
            OnEaten = true;
            PlaySound(pickUp);
            StartCoroutine(EnemyInvisible());
            Enemy1.SetActive(false);
            Enemy2.SetActive(false);
            Enemy3.SetActive(false);
            Enemy4.SetActive(false);
            powerUp4.SetActive(false);
        }
    }

    IEnumerator EnemyInvisible()
    {
        yield return new WaitForSeconds(4f);
        OnEaten = false;
        Enemy1.SetActive(true);
        Enemy2.SetActive(true);
        Enemy3.SetActive(true);
        Enemy4.SetActive(true);
    }

    private void SetWinText()
    {
        if (pointsValue >= 2790)
        {
            winMusic.SetActive(true);
            winText.text = "You Win!";
            Destroy(gameObject);
        }
    }

    private void SetLoseText()
    {
        if (health <= 0)
        {
            loseMusic.SetActive(true);
            loseText.text = "You Lose!";
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
