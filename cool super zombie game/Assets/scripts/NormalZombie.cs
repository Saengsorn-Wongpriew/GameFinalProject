using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombie : MonoBehaviour
{
    public Rigidbody2D meZombie;
    public float moveSpeed;
    public float health;
    public Transform attackCoor;

    private GameObject[] targetObject;
    private readonly string targetTag = "Player";
    private readonly float maxSpeed = 0.5f;

    Vector2 movement;

    void Start()
    {
        if (targetObject == null)
        {
            targetObject = GameObject.FindGameObjectsWithTag(targetTag);
        }
    }

    void Update()
    {
        Vector3 targetPos = targetObject[0].transform.position;
        Vector3 aimDirection = (targetPos - transform.position).normalized;
        float aimAng = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        attackCoor.eulerAngles = new Vector3(0.0f, 0.0f, aimAng);

        if (health <= 0.0f)
        {
            Destroy(this.gameObject);
        }
        else if (targetObject.Length > 0)
        {
            movement.x = Mathf.Clamp(targetObject[0].transform.position.x - transform.position.x, -maxSpeed, maxSpeed);
            movement.y = Mathf.Clamp(targetObject[0].transform.position.y - transform.position.y, -maxSpeed, maxSpeed);
        }
    }
    void FixedUpdate()
    {
        meZombie.AddForce(movement * moveSpeed);
    }
}
