using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lateUpdate : MonoBehaviour
{
    private void OnEnable() {
        Debug.Log("Enable");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.Translate(0, 0, 0.1f * Time.deltaTime * 10);
    }
}
