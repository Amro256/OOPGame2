using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{   
    float horzDirection;
    float vertdirection;
    [SerializeField] float speed = 5;
    Rigidbody2D enemeyRigidBody;
    void Start()
    {
        enemeyRigidBody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        enemeyRigidBody.velocity = new Vector2(horzDirection * speed, vertdirection * speed);
    }

    public void ControlNPC(float horInput, float verInput) // new public method so the regualr inputs are controlled by the NPC
    {
        horzDirection = horInput;
        vertdirection = verInput;
    }
}
