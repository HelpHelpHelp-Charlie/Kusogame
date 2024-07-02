using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveChara : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode moveL;
    public KeyCode moveR;
    private float _amountToIncrease=0.1F;
    void Start()
    {
        GetComponent<Rigidbody>().velocity=new Vector3(0,0,4);
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
        transform.position = new Vector3 ( transform.position.x + _amountToIncrease, transform.position.y, transform.position.z);
    }
}
