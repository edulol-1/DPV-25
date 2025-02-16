using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float velocidad;
    public float movimientoVertical;
    public float movimientoHorizontal;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxis("Horizontal");
        movimientoVertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical);
        rb.AddForce(movimiento * velocidad);
    }

    // Solo registra colisiones, no registra triggers
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Finish") {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Muro") {
             Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay (Collision collision) {
        if (collision.gameObject.tag == "Muro") {
            Destroy(collision.gameObject);
        }
    }
}
