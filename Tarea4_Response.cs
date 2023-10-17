using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarea4_Response : MonoBehaviour
{
    //BEGIN: NEEDED FOR EX3
    private bool moveTowardsCylinder;
    private System.DateTime lastVisited;
    private int jump;
    GameObject group2Destination;

    //END

    void collisionEvent() {
        string tag = gameObject.tag;
        if(tag.Equals("Group 1")) {
            var cubeRenderer = GetComponent<Renderer>();
            Color randomColor = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));
            cubeRenderer.material.SetColor("_Color", randomColor);
        }
        else if(tag.Equals("Group 2")) {
            moveTowardsCylinder = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        jump = 1;
        lastVisited = System.DateTime.Now;
        moveTowardsCylinder = false;
        Tarea4_Notification.OnCollisionEvent += collisionEvent;
        if(tag.Equals("Group 2")) {
            Tarea_4_MoveCube.OnCollisionWithGroup1 += ex2_reactionGroup2;
            Tarea_4_MoveCube.ApproachCylinder += ex3_reactionGroup2;
        }
        if(tag.Equals("Group 1")) {
            Tarea_4_MoveCube.OnCollisionNotFromGroup1 += ex2_reactionGroup1;
            Tarea_4_MoveCube.ApproachCylinder += ex3_reactionGroup1;
        }

        group2Destination = GameObject.FindWithTag("Destination");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTowardsCylinder)
        {
            GameObject cylinder = GameObject.FindGameObjectWithTag("MY_CYLINDER");
            Vector3 directionToMove = cylinder.transform.position - transform.position;
            directionToMove = directionToMove.normalized * Time.deltaTime;
            transform.position = transform.position + directionToMove;
        }
    }

    void ex2_reactionGroup1() {
        moveTowardsCylinder = true;
    }

    void ex2_reactionGroup2() {
        transform.localScale += new Vector3(1,1,1);
    }

    void ex3_reactionGroup1() {
        System.DateTime callTime = System.DateTime.Now;
        float difference = (callTime - lastVisited).Milliseconds;
        if(difference > 250) {
            lastVisited = callTime;
            var cubeRenderer = GetComponent<Renderer>();
            Color randomColor = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));
            cubeRenderer.material.SetColor("_Color", randomColor);
            transform.position += new Vector3(0,jump,0);
            jump *= -1;
        }
    }

    void ex3_reactionGroup2() {
        Vector3 directionToMove = group2Destination.transform.position - transform.position;
        directionToMove = directionToMove.normalized * Time.deltaTime;
        transform.position = transform.position + directionToMove;
    }

    
}
