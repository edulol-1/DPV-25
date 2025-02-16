using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixedUpdate : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(0, 0, 0.1f * Time.deltaTime * 10);
    }
}
