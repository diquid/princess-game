using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMove : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Vector2 speed = new Vector2(10, 10); //скорость объекта
    public Vector2 direction= new Vector2(-1, 0); //направление движения

    private Vector2 movement;
    private Rigidbody2D rb;
    //void Start()
    //{
    //}
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(speed.x * direction.x, 
            speed.y * direction.y); // перемещение
        
    }
    
    void FixedUpdate()
    {
        rb.velocity = movement; //применить движение к RigidBody
    }
}
