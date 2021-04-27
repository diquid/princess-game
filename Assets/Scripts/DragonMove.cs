using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragonMove : MonoBehaviour
{
    public List<Transform> points;
    public int nextID;
    int idChangeValue = 1;




















    ////public Vector2 speed = new Vector2(1, 1); //скорость объекта
    //[SerializeField] private float speed; //скорость объекта
    //[SerializeField] private Vector3[] positions;
    //private int index;
    //private Vector2 movement;
    //private Rigidbody2D rb;
    //public bool isRightSide = true;
    //private SpriteRenderer sprite;

    //void Awake()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //void Update()
    //{
    //    if (transform.position == positions[index])
    //    {
    //        if (index == positions.Length - 1)
    //        {
    //            index = 0;
    //        }
    //        else
    //        {
    //            index++;
    //        }
    //    }
    //}
    
    //void FixedUpdate()
    //{
    //    rb.velocity = movement; //применить движение к RigidBody
    //}

    //void Spin()
    //{
    //    isRightSide = !isRightSide;
    //    transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
    //}
}
