using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class update : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, 0.1f * Time.deltaTime * 10);
    }
}
