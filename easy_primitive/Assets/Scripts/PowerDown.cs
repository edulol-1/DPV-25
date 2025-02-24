using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDown : MonoBehaviour
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
        // Hacemos referencia al renderer del jugador
        Renderer playerRenderer = player.GetComponentInChildren<Renderer>();
        if (playerRenderer == null)
        {
            Debug.LogError("No renderer found in player object :(");
            yield break;
        }
        // Guardamos el color original y cambiamos el color temporalmente
        Color originalColor = playerRenderer.material.color;
        playerRenderer.material.color = Color.red;

        // Apagamos el objecto
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<SphereCollider>().enabled = false;

        player.GetComponent<CharacterMovement>().setVelocity(1.5f);
        
        // Devolvemos la velocidad y el color original, primero esperamos 3 segundos y luego regresamos.
        yield return new WaitForSeconds(2.0f);
        playerRenderer.material.color = originalColor;
        player.GetComponent<CharacterMovement>().resetVelocity();
        Destroy(this.gameObject);
    }
}
