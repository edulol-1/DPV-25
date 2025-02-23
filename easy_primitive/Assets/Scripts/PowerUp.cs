using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // We do something
            StartCoroutine(superVelocity(other.gameObject));
            //Destroy(this.gameObject, 3.0f);
        }
    }

    IEnumerator superVelocity(GameObject player)
    {
        // Apagamos el objecto
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        // this.gameObject.SetActive(false);
        player.GetComponent<CharacterMovement>().setVelocity(10.0f);
        // Devolvemos valor temporal, primero esperamos 3 segundos y luego regresamos.
        yield return new WaitForSeconds(3.0f);
        player.GetComponent<CharacterMovement>().resetVelocity();
        Destroy(this.gameObject);
    }
}
