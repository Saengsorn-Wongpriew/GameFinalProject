using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEvent : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Transform prefabBullet;

    private void Start(){
        playerController.OnShootRay += PlayerController_OnShootRay;
        playerController.OnShootPhysics += PlayerController_OnShootPhysics;

    }

    private void PlayerController_OnShootRay(object sender, PlayerController.OnShootEventArgs e){
        Vector3 shootDir = (e.shootPosition - e.gunEndPointPosition).normalized;
        
        // Hit scan bullet
        BulletRayCast.Shoot(e.gunEndPointPosition, shootDir);
  
    }

    private void PlayerController_OnShootPhysics(object sender, PlayerController.OnShootEventArgs e){
        Vector3 shootDir = (e.shootPosition - e.gunEndPointPosition).normalized;
        
        // Hit scan bullet
        //BulletRayCast.Shoot(e.gunEndPointPosition, shootDir);
        
        
        // transform-based bullet
        Transform bulletTransform = Instantiate(prefabBullet, e.gunEndPointPosition, Quaternion.identity);
        bulletTransform.GetComponent<Bullet>().Setup(shootDir);
    }
    
}
