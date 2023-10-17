using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarea_4_MoveCube : MonoBehaviour
{
    private GameObject cylinder;
    private GameObject cube;
    private float speed = 0.01f;

    private Vector3 distanceToCylinder;

    public delegate void Message_ex2();
    public static event Message_ex2 OnCollisionWithGroup1;
    public static event Message_ex2 OnCollisionNotFromGroup1;

    public delegate void Message_ex3();
    public static event Message_ex3 ApproachCylinder;
    // Start is called before the first frame update
    void Start()
    {
        
        
        cube = GameObject.FindWithTag("MY_CUBE");
        cylinder = GameObject.FindWithTag("MY_CYLINDER");

        distanceToCylinder = cube.transform.position - cylinder.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow)) {
            cube.transform.Translate(0,0,-speed);
        }
        else if(Input.GetKey(KeyCode.UpArrow)) {
            cube.transform.Translate(0,0,speed);
        }
        else if(Input.GetKey(KeyCode.RightArrow)) {
            cube.transform.Translate(speed,0,0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) {
            cube.transform.Translate(-speed,0,0);
        }

        Vector3 actualDistance = cube.transform.position - cylinder.transform.position;

        if (actualDistance.magnitude < distanceToCylinder.magnitude) {
            if(ApproachCylinder != null) ApproachCylinder();
        }
        distanceToCylinder = actualDistance;
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag.Equals("Group 1")) {
            if(OnCollisionWithGroup1 != null) OnCollisionWithGroup1();
        }
        if(!collision.gameObject.tag.Equals("Group 1")) {
            if(OnCollisionNotFromGroup1 != null) OnCollisionNotFromGroup1();
        }
    }
}
