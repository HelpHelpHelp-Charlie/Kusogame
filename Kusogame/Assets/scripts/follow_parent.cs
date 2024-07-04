using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Video;

public class follow_parent : MonoBehaviour
{
    public Vector3 Local_position;
    public Rigidbody rb;

    private float speed=0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       

        // Local_position=Vector3.MoveTowards(transform.localPosition, new Vector3(0,0,0), speed * Time.deltaTime);
        // transform.rotation= Quaternion.Euler(0,0,0);
        Vector3 forceDirection = new Vector3(0,0,0) - transform.localPosition;
        Vector3 LocalVelocity = rb.velocity;
        //Debug.Log("rb.velocity: " +rb.velocity);
        forceDirection[1]=0;
        rb.velocity=(forceDirection* 3f);
        //rb.AddForce (forceDirection* 3f);
        transform.localRotation = Quaternion.Euler(0,0,0);
        //transform.localPosition=new Vector3(transform.localPosition.x,Local_position.y,transform.localPosition.z);
    }
    public void refreshPOS(){
        transform.localPosition = Local_position;
        //Debug.Log("Local_position: " +Local_position);
    }
}
