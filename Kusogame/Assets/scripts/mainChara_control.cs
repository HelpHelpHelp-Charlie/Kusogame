using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;

public class mainChara_control : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode moveL;
    public KeyCode moveR;
    private float _amountToIncrease=0.3F;
    public GameObject sub_chara;
    public int row_count=7;
    public float offset=0.12f;
    void Start()
    {
        GetComponent<Rigidbody>().velocity=new UnityEngine.Vector3(0,0,4);
        var sub=Instantiate(sub_chara, this.transform);
        sub.transform.SetParent(this.transform);
        sub.GetComponent<follow_parent>().Local_position=new UnityEngine.Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        _amountToIncrease=0F;
        if(Input.GetKey(moveL)){
            _amountToIncrease=-0.01F;
        }else if (Input.GetKey(moveR)){
            _amountToIncrease=0.01F;
        }
        transform.position = new UnityEngine.Vector3 ( transform.position.x + _amountToIncrease, transform.position.y, transform.position.z);
    }

    public void change_amount_of_Child(int changing_number){
        if (changing_number==0){

        }else if(changing_number<0){//changing_number<0 remove child
            changing_number=-changing_number;
            for(int i=0;i<changing_number;i++){
                if(transform.childCount>0){
                    Destroy(this.transform.GetChild(0).gameObject);
                }
            }
            rearrange_child_position();
        }else{//changing_number>0  add child
            for(int i=0;i<changing_number;i++){
                var sub=Instantiate(sub_chara, this.transform);
                sub.transform.SetParent(this.transform);
            }
            rearrange_child_position();
        }
    }
    void rearrange_child_position(){
        int Count=transform.childCount;
        if (Count>0){
            follow_parent[] transform_list = GetComponentsInChildren<follow_parent>();
            Debug.Log("transform.childCount: " +Count);
            int remainder=Count%row_count;
            int quotient = Count/row_count;
            Debug.Log("quotient: " +quotient);
            Debug.Log("remainder: " +remainder);
            for(int i=0;i<quotient;i++){
                Debug.Log("i: " +i);
                for(int j=0;j<row_count;j++){
                    transform_list[i*row_count+j].GetComponent<follow_parent>().Local_position=
                    new UnityEngine.Vector3(((int)(row_count/2)+1-j)*offset,0,-offset*i);
                }
            }
            for(int j=0;j<remainder;j++){
                Debug.Log("j: " +j);
                int now=(quotient*row_count+j);
                Debug.Log("(quotient)*5+j: " +now);
                transform_list[quotient*row_count+ j].GetComponent<follow_parent>().Local_position=new UnityEngine.Vector3(((int)(row_count/2)+1-j)*offset,0,-offset*quotient);
            }
        }
    }
}
