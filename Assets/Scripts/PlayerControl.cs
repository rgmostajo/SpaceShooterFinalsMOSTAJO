using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject GameManagerGO;

    public GameObject PlayerBulletGO;
    public GameObject BulletPosition;
    public GameObject ExplosionGO;

    public Text LivesUIText;

    AudioSource audioData;

    const int MaxLives = 3;
    int lives;

    public float speed;

    public void Init()
    {
        lives = MaxLives;

        LivesUIText.text = lives.ToString();

        transform.position = new Vector2(0, -1);

        gameObject.SetActive(true);
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            Debug.Log("started");

            GameObject bullet = (GameObject)Instantiate(PlayerBulletGO);
            bullet.transform.position = BulletPosition.transform.position;
        }

        float x = Input.GetAxisRaw("Horizontal");
       // float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, 0).normalized;

        Move(direction);
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));

        max.x = max.x - 0.08f;
        min.x = min.x - 0.01f;

        max.y = max.y - 0.115f;
        min.y = min.y - 0.115f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp (pos.x, min.x, max.x);
    //    pos.y = Mathf.Clamp (pos.y, min.y, max.y);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();

            lives--;
            LivesUIText.text = lives.ToString();

            if(lives == 0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                gameObject.SetActive(false);
            }
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        explosion.transform.position = transform.position;
    }
}
