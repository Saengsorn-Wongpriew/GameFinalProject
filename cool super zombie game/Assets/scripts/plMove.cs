using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D plRB;

    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        plRB.MovePosition(plRB.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
