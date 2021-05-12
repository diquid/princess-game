using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DragonMove : MonoBehaviour
{
    public List<Transform> points;
    public int nextID = 0;
    private int idChangeValue = 1;
    public float speed = 2;


    private void Reset()
    {
        Init();
    }

    void Init()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        GameObject root = new GameObject(name + "_Root");
        root.transform.position = transform.position;
        transform.SetParent(transform);
        GameObject waypoints = new GameObject("Waypoints");
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        GameObject p1 = new GameObject("Point1");
        p1.transform.SetParent(waypoints.transform);
        p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2");
        p2.transform.SetParent(waypoints.transform);
        p2.transform.position = root.transform.position;

        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        Transform goalPoint = points[nextID];
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
        {
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            if (nextID == 0)
                idChangeValue = 1;
            nextID += idChangeValue;
        }
    }

















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
