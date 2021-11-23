/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class MeshEvent : MonoBehaviour {
    
    [SerializeField] private PlayerAimShoot playerAimShoot;

    private float nextSpawnDirtTime;
    private float nextSpawnFootprintTime;

    private void Start() {
        playerAimShoot.OnShootRay += PlayerAimShoot_OnShootRay;
    }

    private void PlayerAimShoot_OnShootRay(object sender, PlayerAimShoot.OnShootEventArgs e) {
        Vector3 quadPosition = e.gunEndPointPosition;

        Vector3 shootDir = (e.shootPosition - e.gunEndPointPosition).normalized;
        quadPosition += (shootDir * -1f) * 1f;

        float applyRotation = Random.Range(+95f, +85f);
        if (shootDir.x < 0) {
            applyRotation *= -1f;
        }
        
        Vector3 shellMoveDir = UtilsClass.ApplyRotationToVector(shootDir, applyRotation);
    
        ShellParticleSystemHandler.Instance.SpawnShell(quadPosition, shellMoveDir);
    }
    
}
