using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCollision : MonoBehaviour
{
    public GameObject parentObject;
    public Vector3 positionDif = new Vector3(0,0,0);
    public float smoothTime = 0.01f;
    private bool isOnTable=false;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnTable)
        {
            this.gameObject.transform.position = Vector3.SmoothDamp(this.gameObject.transform.position, parentObject.transform.position+positionDif, ref velocity, smoothTime);
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag != "staticObject")
        {
            positionDif = this.gameObject.transform.position - other.gameObject.transform.position;
            isOnTable = true;
            parentObject = other.gameObject;
            //childObject.transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "staticObject")
        {
            isOnTable = true;
            //parentObject = other.gameObject;
            //childObject.transform.parent = other.gameObject.transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // childObject.transform.parent = null;
        isOnTable = false;
        parentObject = null;

    }

}
