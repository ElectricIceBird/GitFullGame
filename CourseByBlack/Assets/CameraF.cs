using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraF : MonoBehaviour
{
    public float speed;
   public Transform playerpos;
   public float minx;
   public float miny;
   public float maxx;
   public float maxy;

   private void Start() {
       transform.position = playerpos.position;
   }
   private void Update() {
       if(playerpos != null){
           float clampdx = Mathf.Clamp(playerpos.position.x,minx,maxx);
           float clampdy = Mathf.Clamp(playerpos.position.y,miny,maxy);

       transform.position = Vector2.Lerp(transform.position,new Vector2(clampdx,clampdy),speed);
   }
   }
}
