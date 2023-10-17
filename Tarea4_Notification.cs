using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarea4_Notification : MonoBehaviour
{
    private GameObject cube;
    public delegate void Message();
    public static event Message OnCollisionEvent;

    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.FindWithTag("MY_CUBE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject == cube) {
            if(OnCollisionEvent != null) OnCollisionEvent();
        }
    }
}
