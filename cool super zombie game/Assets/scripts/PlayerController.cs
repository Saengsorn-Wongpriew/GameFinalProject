using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShootRay;
    public event EventHandler<OnShootEventArgs> OnShootPhysics;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }


    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private Camera cam;
    
    // gun pointing
    public Transform aimTransform;
    public Transform aimGunEndPointTransform;

    // component
    private Rigidbody2D rb;

    private Vector2 moveDirection;
    private Vector3 mousePosition;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // getting inputs
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(dirX, dirY).normalized;
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        
        // shoot
        if (Input.GetButtonDown("Fire1"))
        {
            OnShootRay?.Invoke(this, new OnShootEventArgs {
                gunEndPointPosition = aimGunEndPointTransform.position,
                shootPosition = mousePosition
            });
        }
        if (Input.GetButtonDown("Fire2"))
        {
            OnShootPhysics?.Invoke(this, new OnShootEventArgs {
                gunEndPointPosition = aimGunEndPointTransform.position,
                shootPosition = mousePosition
            });
        }
        

    }

    private void FixedUpdate()
    {
        // move
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        // aim
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, aimAngle);

    }
}
