using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movePoints : MonoBehaviour
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
        if (collision.gameObject.tag == "CuboPuntos") {
            Rigidbody cubo = collision.gameObject.GetComponent<Rigidbody>();
            if (cubo != null) {
                Vector3 direccionEmpuje = collision.transform.position - transform.position;
                direccionEmpuje.y = 0.9f;
                cubo.AddForce(direccionEmpuje.normalized * 7f, ForceMode.Impulse);
            }
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
