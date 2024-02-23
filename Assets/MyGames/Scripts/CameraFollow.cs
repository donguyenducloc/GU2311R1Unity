using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float distance = 2;
    public float height =3;
    public float shouderOffset = 1;
    public bool switchSoulder;
    public float smoothTime = 0.25f;
    Vector3 lookTarget;
    Vector3 lookTargetVelocity;
    Vector3 currentVelocity;
    // Start is called before the first frame update
    void Start()
    {
        //player= GameObject.Find("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    
    void LateUpdate()
    {
        Vector3 target = player.position - player.transform.forward * distance;
        Vector3 verticalPosition = Vector3.up * height;
        Vector3 shouderPosition = switchSoulder ? transform.right * -shouderOffset : transform.right * shouderOffset;
        transform.position = Vector3.SmoothDamp(transform.position,target+ verticalPosition + shouderPosition,ref currentVelocity,smoothTime);
        lookTarget = Vector3.SmoothDamp(lookTarget,player.position+ verticalPosition+shouderPosition,ref lookTargetVelocity,smoothTime);
        transform.LookAt(lookTarget);
    }
}  
