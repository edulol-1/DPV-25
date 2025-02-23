using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float velocity, originalVelocity;
    public float gravity;
    public Vector3 direction;
    public CharacterController cc;
    
    // Start is called before the first frame update
    void Start()
    {
        cc = this.gameObject.GetComponent<CharacterController>();
        originalVelocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        direction.y -= gravity;
        direction.x = Input.GetAxisRaw("Horizontal") * velocity;
        direction.z = Input.GetAxisRaw("Vertical") * velocity;
        cc.Move(direction * Time.deltaTime);
        //horizontal = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        //vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        //direction = new Vector3(horizontal, gravity, vertical);
        //this.transform.position += direction * Time.deltaTime;
    }

    public void setVelocity(float velocity)
    {
        this.velocity = velocity;
    }

    public void resetVelocity()
    {
        this.velocity = originalVelocity;
    }

}
