using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeCheck : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private Transform PlayerFeet;
    [SerializeField] private LayerMask layerMask;
    private RaycastHit2D Hit2D;


    private void SlopeCheckMethod()
    {
        Hit2D = Physics2D.Raycast(raycastOrigin.position, -Vector2.up, 100f, layerMask);
        
        if(Hit2D != false)
        {
            Vector2 temp = PlayerFeet.position;
            temp.y =Hit2D.point.y;
            PlayerFeet.position = temp;
        }
    }

    void Update()
    {
        SlopeCheckMethod();
    }


}
