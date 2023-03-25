using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // reference for cam
    public Transform cam;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(cam); // This makes the gameObject face the camera, such as the health and mana bar
    }
}
