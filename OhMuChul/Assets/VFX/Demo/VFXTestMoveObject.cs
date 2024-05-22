using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXTestMoveObject : MonoBehaviour
{
    public float speed = 1f;
    private float dir = 1f;
    private void Start()
    {
        transform.position += new Vector3(0, 0, 0);
    }

    void Update()
    {
        this.transform.Translate(0, speed * Time.deltaTime * dir, 0f);
        if (this.transform.position.y < -4f)
            dir = 1f;
        if (this.transform.position.y > 4f)
            dir = -1f;
    }
}
