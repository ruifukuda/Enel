using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaniMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.x < 0.1f && transform.localPosition.y < 5){
        transform.Translate((Vector3.up + Vector3.right * 0.7f) * 9f * Time.deltaTime );

        }
    }
}
