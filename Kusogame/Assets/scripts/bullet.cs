using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float life=2f;

    void Awake(){
        Destroy(gameObject,life);
    }
    
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag=="add"){
            collision.gameObject.GetComponent<adder>().onHit();
            Destroy(gameObject);
        }else if(collision.gameObject.tag=="non_bullet_affect"){

        }else{
            Destroy(gameObject);
        }

    }
}
