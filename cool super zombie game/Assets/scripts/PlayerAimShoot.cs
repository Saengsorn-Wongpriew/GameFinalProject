using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAimShoot : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShootRay;
    //public event EventHandler<OnShootEventArgs> OnShootPhysics;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }

    [SerializeField] private GameObject gunGameObject;
    private SpriteRenderer gunSprite;
    
    // gun pointing
    [SerializeField] private Camera cam;
    private Animator aimAnim;
    public Transform aimTransform;
    public Transform aimGunEndPointTransform;
    private Vector3 mousePosition;

    

    private void Start() {
        aimAnim = aimTransform.GetComponent<Animator>();

        
        gunSprite = gunGameObject.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        // shooty shooty bang bang
        if (Input.GetButtonDown("Fire1"))
        {
            aimAnim.SetTrigger("shoot");
            OnShootRay?.Invoke(this, new OnShootEventArgs {
                gunEndPointPosition = aimGunEndPointTransform.position,
                shootPosition = mousePosition
            });
        }
        
        /*
        if (Input.GetButtonDown("Fire2"))
        {
            OnShootPhysics?.Invoke(this, new OnShootEventArgs {
                gunEndPointPosition = aimGunEndPointTransform.position,
                shootPosition = mousePosition
            });
        }
        */

        // aim
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        if (aimAngle < 0) aimAngle += 360;
        aimTransform.eulerAngles = new Vector3(0, 0, aimAngle);
    }
}
