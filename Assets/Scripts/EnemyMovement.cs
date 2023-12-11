using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class EnemyMovment : MonoBehaviour

{
  private Enemy enemy;
    private float speed;
    private Transform player; // Referencja do obiektu gracza
    private Rigidbody rb;

    void Start()
    {
        speed = GetComponent<Enemy>().Speed;
        player = GameObject.FindGameObjectWithTag("Player").transform; // Znajdź obiekt gracza
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Kierunek od przeciwnika do gracza
        Vector2 direction = (player.position - transform.position).normalized;

        // Ruch przeciwnika w kierunku gracza
        //rb.MoveTowards(rb.position + direction * speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
      
    }

}
