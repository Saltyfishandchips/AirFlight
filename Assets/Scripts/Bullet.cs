using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private Vector2 customVeclocity;
    private float timer;

    private void Start() {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
            rigidbody2D.velocity = customVeclocity;
        else 
            Debug.LogWarning("Rigidbody2D has not exist!");
    }

    public void SelectBullet(string str) {
        Sprite sprite = transform.GetComponent<Sprite>();
        if (sprite != null)
            sprite = Resources.Load<Sprite>(str);
        else 
            Debug.LogWarning("Sprite has not exist!");
    }
    
    private void Update() {
        timer += Time.deltaTime;
        if (timer > 5f) {
            Destroy(gameObject);
            timer = 0f;
        }
    }

    public void Destroy() {
        Destroy(gameObject);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
