using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class adder : MonoBehaviour
{
    public GameObject text;
    private Material material;
    public Color positive;
    public Color negative;
    // Start is called before the first frame update
    public int add_number=0;

    public GameObject main_Chara;
    void Start()
    {
        main_Chara=GameObject.FindGameObjectWithTag("Player");
        material = Instantiate(Resources.Load<Material>("adder_color"));
        add_number=UnityEngine.Random.Range(-6,-3);
        //add_number=UnityEngine.Random.Range(55,56);

        if (add_number>0){
            text.GetComponent<TextMesh>().text="+"+add_number.ToString();
            this.GetComponent<Renderer>().material.color=positive;
        }else{
            text.GetComponent<TextMesh>().text=add_number.ToString();
            this.GetComponent<Renderer>().material.color=negative;
        }   
    }

    public void onHit(){

        add_number+=1;
        if (add_number>0){
            text.GetComponent<TextMesh>().text="+"+add_number.ToString();
            this.GetComponent<Renderer>().material.color=positive;
            
        }else{
            text.GetComponent<TextMesh>().text=add_number.ToString();
            this.GetComponent<Renderer>().material.color=negative;
        }
    }

    void OnTriggerExit(Collider collision){
        
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player"){
            main_Chara.GetComponent<mainChara_control>().change_amount_of_Child(this.add_number);
        }
    }
}
