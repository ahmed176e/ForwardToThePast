﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlash : MonoBehaviour {
    private List<int> hitList;
    public AudioClip hitSound;

    void Start () {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    private void Awake()
    {
        hitList = new List<int>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        int colliderId = collider.GetInstanceID();
        if ((collider.gameObject.layer == 8 || collider.gameObject.layer == 10) && !hitList.Contains(colliderId))
        {
            EnemyBasic enemy = collider.gameObject.GetComponent<EnemyBasic>();
            enemy.TakeDamage();
            var source = GetComponentInParent<AudioSource>();
            source.clip = hitSound;
            source.Play();
            enemy.KnockbackEnemy(PlayerManager.instance.Player.transform.position); //only works if has rigidbody

            hitList.Add(colliderId);
        }
        
    }
}