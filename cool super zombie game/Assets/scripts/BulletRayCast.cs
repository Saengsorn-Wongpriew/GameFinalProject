using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BulletRayCast
{
    public static void Shoot(Vector3 shootPosition, Vector3 shootDirection)
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(shootPosition, shootDirection);

        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.collider.CompareTag("Target"))
            {
                Debug.Log("Hit");
            }
        }
    }
}
