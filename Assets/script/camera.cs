using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangScale(SpriteRenderer sr,float x,float y)
    {
        x *= UnityEngine.Screen.width;
        y *= UnityEngine.Screen.height;
        Debug.Log(UnityEngine.Screen.height);
             Debug.Log(UnityEngine.Screen.width);
        Debug.Log(this.transform.GetComponent<Camera>().sensorSize.x);
        Debug.Log(this.transform.GetComponent<Camera>().sensorSize.y);
        sr.transform.localScale = new Vector3(x,y,1);
    }
}
