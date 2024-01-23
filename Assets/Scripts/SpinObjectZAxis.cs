using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObjectZAxis : MonoBehaviour
{
    public float spinSpeed = 1f;
    void Update()
    {
        transform.Rotate(0f, 0f, 60f * (spinSpeed * Time.deltaTime), Space.Self);
    }
}
