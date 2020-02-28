﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 dir;

    // Update is called once per frame
    void Update()
    {

      dir.z = playerTransform.eulerAngles.y;
      transform.localEulerAngles = dir;

    }
}
