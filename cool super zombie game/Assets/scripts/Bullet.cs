using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 shootDir;
    public float bulletSpeed = 2f;
    public void Setup(Vector3 shootDir){
        this.shootDir = shootDir;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDir));
        Destroy(gameObject, 2f);
    }

    private void Update() {
        float moveSpeed = bulletSpeed;
        transform.position += shootDir * moveSpeed * Time.fixedDeltaTime;
    }

    public static float GetAngleFromVectorFloat(Vector3 dir){
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n <= 0) n += 360;

        return n;
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Target")){
            Destroy(gameObject);
        }
    }
}
