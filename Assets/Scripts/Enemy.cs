using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    [SerializeField]private Vector2 customVeclocity;
    private Animator animator;
    private bool isDead = false;

    public static event Action OnScoreCount;

    private float timer = 0f;

    private Rigidbody2D rigidbody2D;
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D == null)
            Debug.LogWarning("Rigidbody2D has not exist!");
    }

    private void Update() {
        if (PlaneChosen.gameStart != true)
            return;
        else
            rigidbody2D.velocity = customVeclocity;

        timer += Time.deltaTime;

        if (!isDead && timer > 2f) {
            timer = 0f;
            EnemyAttack();
        }
    }

    private void EnemyAttack() {
        if (enemyBullet != null)
            Instantiate(enemyBullet, transform.position + Vector3.down, transform.rotation);
        else 
            Debug.LogWarning("enemyBullet has not exist!");
        
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (this.tag == "Enemy" && other.tag == "Player") {
            animator.SetBool("isDead", true);
        }
        else if (this.tag == "Enemy" && other.tag == "EnemyBullet") {
            return;
        }
        
        else if (this.tag == "Enemy" && other.tag == "PlayerBullet") {
            // 记分
            Bullet bullet = other.GetComponent<Bullet>();
            bullet.Destroy();
            OnScoreCount?.Invoke();
            isDead = true;
            animator.SetBool("isDead", true);
            Destroy(gameObject, 2f);
        }
        else {
            Debug.LogWarning("Something goes wrong!!!");
        }
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

}
