using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public float herdDistance = 2f; // Distance between master sheep & herd
    public float separationDistance = 2000f; // Distance to maintain between sheep within the herd

    private List<GameObject> herd = new List<GameObject>();

    public float moveSpeed = 5f;
    private float nonMasterSheepSpeed;
    private Rigidbody2D rb;

    Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandlePlayerInput();
        nonMasterSheepSpeed = moveSpeed * 0.8f;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, herdDistance);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Sheep") && collider.gameObject != gameObject)
            {
                AddToHerd(collider.gameObject);
            }
        } 
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();

        for (int i = 0; i < herd.Count; i++)
        {
            MoveSheep(herd[i], i + 1);
        }
    }

    void HandlePlayerInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void HandlePlayerMovement()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void MoveSheep(GameObject sheep, int index)
    {
        
    }

    private void AddToHerd(GameObject sheep)
    {
        
    }
}
