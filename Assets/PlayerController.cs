using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4.0f; // the f at the end of the number says it is a floating-point number
    public float rotateSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Player Started");
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxis("Vertical");

        //set animations
        Animator anim = gameObject.GetComponent<Animator>();

        if (speed !=0)
        {
            anim.SetBool("forward", true);
        }
        else
        {
            anim.SetBool("forward", false);
        }

        // rotate around y-axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        if (speed != 0)
        {
            Debug.Log(Vector3.forward);
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Debug.Log(forward);

            // you need the character controller so you can use SimpleMove
            CharacterController controller = GetComponent<CharacterController>();
            controller.SimpleMove(forward * speed * moveSpeed);
        }
    }
}
