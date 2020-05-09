# Hololens-Move-test
Move the table. Move the objects with the table.



unity 2019.3.5

VS 2019

MRTK 2.3.0



## Import MRTK

Assets -> import package -> custom package -> choose the MRTK package

refer to: https://microsoft.github.io/MixedRealityToolkit-Unity/Documentation/GettingStartedWithTheMRTK.html

## Drag objects

add components in the inspector of the object and the table: add NearInteractionGrabbable -> add ManipulationHandler

refer to: https://docs.microsoft.com/en-us/windows/mixed-reality/mrtk-101

## Move the objects with table

1. **Make the table a trigger**

   When the object collides with the table, trigger will be triggered, and then the object will follow the table to move. The object exits the trigger after leaving the table and no longer follows the table.

   

   add components to table: add Box Collider(or Mesh Collider) -> tick "is Trigger"

   

2. **For the object**

   ```c#
   public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = Mathf.Infinity, float deltaTime = Time.deltaTime);
   ```

   This is a function that enables the game object A to follow the movement of the object B

   refer to: https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html



​		add components to the object: add Box Collider(or any other kind of collider) -> add a new script to the object

​		script:

```C#
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

```

3. **Set Rigidbody to the object and the table**

table and the objects: add components -> add Rigidbody -> tick Use Gravity

ground:  add components -> add Box Collider(or other kind of collider)