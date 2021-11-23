using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    public void Setup(float eulerZ) {
        transform.eulerAngles = new Vector3(0, 0, eulerZ);
        Destroy(gameObject, 0.025f);
    }

}
