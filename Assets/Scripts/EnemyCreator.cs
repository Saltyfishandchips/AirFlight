using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyList;
    private int size = 0;

    float timer = 0;

    private void Awake() {
        size = enemyList.Count;    
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3.5f) {
            timer = 0f;
            Instantiate(enemyList[UnityEngine.Random.Range(0, size)], transform.position + new Vector3(UnityEngine.Random.Range(-4, 4),0 , -5), transform.rotation);
        }
    }
}
