using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sphereRandomiser : MonoBehaviour
{

public float Size ; // float is any number that is desimel e.g. 1,2
//public float SizeMultiplier ; 

public int Testint ; // int is a whome number

public string Name ; // string is a series of character e.g. bob

public bool Exists ; //bool is a condition that is either true or false


//public Color myColor ; 

    // Start is called before the first frame update
    void Start()
    {
     gameObject.transform.localScale = new Vector3(x:Size , y: Size , z:Size);//transforming the size to the size variables
     gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
   
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter ()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
} 
