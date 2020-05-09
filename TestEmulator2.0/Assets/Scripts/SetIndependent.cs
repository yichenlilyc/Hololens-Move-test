using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIndependent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetToIndependent()
    {
        gameObject.transform.parent = null;
    }

}
