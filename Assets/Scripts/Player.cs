using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private GameObject bullet;
    private Animator animator;

    public bool gameStart = false;

    private void Start() {
        animator = transform.GetComponent<Animator>();
    }

    private void Update()
    {
        if (PlaneChosen.gameStart != true)
            return;

        float scale = 3.0f;
        if (Input.GetKey(KeyCode.W) && transform.position.x < 10) {
            transform.position += scale * Vector3.up * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.x > -10) {
            transform.position += scale * Vector3.down * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -5.7) {
            transform.position += scale * Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 5.7) {
            transform.position += scale * Vector3.right * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            Attack();
        }
    }


    private void Attack() {
        Instantiate(bullet, transform.position + Vector3.up, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (this.tag == "Player" && other.tag == "Enemy") {
            Debug.LogWarning("玩家直接被击中！");
            animator.SetBool("isDead", true);
        }
        else if (this.tag == "Player" && other.tag == "EnemyBullet") {
            Debug.LogWarning("玩家被击中！");
            Bullet bullet = other.GetComponent<Bullet>();
            bullet.Destroy();
            animator.SetBool("isDead", true);
            Destroy(gameObject, 2f);

        }
        else if (this.tag == "Player" && other.tag == "PlayerBullet") {
            return;
        }
        else {
            Debug.LogWarning("Something goes wrong!!!");
        }
    }

    public void ChosePlane(string str)  {
        SpriteRenderer sprite = transform.GetComponent<SpriteRenderer>();
        sprite.sprite = Resources.Load<Sprite>(str);
        PlaneChosen.gameStart = true;
    }

    
}
