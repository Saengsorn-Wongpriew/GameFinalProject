using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTracer : MonoBehaviour
{
    [SerializeField] private PlayerAimShoot playerAimShoot;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform weaponTracerPrefab;

    private void Start() {
        playerAimShoot.OnShootRay += PlayerAimShoot_OnShootRay;
    }

    private void PlayerAimShoot_OnShootRay(object sender, PlayerAimShoot.OnShootEventArgs e){
        CreateWeaponTracer(e.gunEndPointPosition, e.shootPosition);
    }

    private void CreateWeaponTracer(Vector3 fromPosition, Vector3 targetPosition){
        Vector3 dir = (targetPosition - fromPosition).normalized;
        float eulerZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (eulerZ < 0) eulerZ += 360;
        
        fromPosition += dir * 0.5f;
        Transform bulletTracer = Instantiate(weaponTracerPrefab, fromPosition, Quaternion.identity);
        bulletTracer.GetComponent<Tracer>().Setup(eulerZ);
        
    }
}
