using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float followSpeed = 2f;
    public GameObject target;


    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player");
        Vector3 newPos = new Vector3(target.transform.position.x,target.transform.position.y,-10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        
    }
}
