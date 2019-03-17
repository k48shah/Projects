﻿using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour
{
    public float RayCast_Length;

    public RaycastHit hit_l, hit_fl, hit_f, hit_fr, hit_r;
    public float dis_l, dis_fl, dis_f, dis_fr, dis_r;

    private Vector3 origin, left, frontleft, front, frontright, right;
    private float heading;

    // Use this for initialization
    void Start()
    {
        //set detect radius
        RayCast_Length = 5.0f;


        origin = transform.position + Vector3.up * 0.2f;
        /*
		left = origin - (Vector3.forward * RayCast_Length);
		frontleft = origin + (Vector3.left - Vector3.forward) * RayCast_Length;
		front = origin + (Vector3.left * RayCast_Length);
		frontright = origin + (Vector3.left + Vector3.forward) * RayCast_Length;
		right = origin + (Vector3.forward * RayCast_Length);
		*/
        heading = transform.rotation.eulerAngles.y;
        float angle = heading / 180 * Mathf.PI;

        left = new Vector3(origin.x - RayCast_Length * Mathf.Cos(angle), origin.y, origin.z + RayCast_Length * Mathf.Sin(angle));
        frontleft = new Vector3(origin.x - RayCast_Length * Mathf.Sin(angle - Mathf.PI / 4), origin.y, origin.z - RayCast_Length * Mathf.Cos(angle - Mathf.PI / 4));
        front = new Vector3(origin.x - RayCast_Length * Mathf.Sin(angle), origin.y, origin.z - RayCast_Length * Mathf.Cos(angle));
        frontright = new Vector3(origin.x - RayCast_Length * Mathf.Sin(angle + Mathf.PI / 4), origin.y, origin.z - RayCast_Length * Mathf.Cos(angle + Mathf.PI / 4));
        right = origin + origin - left;

        dis_l = 0.0f;
        dis_fl = 0.0f;
        dis_f = 0.0f;
        dis_fr = 0.0f;
        dis_r = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position + Vector3.up * 0.2f;
        /*
		left = origin - (Vector3.forward * RayCast_Length);
		frontleft = origin + (Vector3.left - Vector3.forward) * RayCast_Length;
		front = origin + (Vector3.left * RayCast_Length);
		frontright = origin + (Vector3.left + Vector3.forward) * RayCast_Length;
		right = origin + (Vector3.forward * RayCast_Length);
		*/
        heading = transform.rotation.eulerAngles.y;
        float angle = heading / 180 * Mathf.PI;

        left = new Vector3(origin.x - RayCast_Length * Mathf.Cos(angle), origin.y, origin.z + RayCast_Length * Mathf.Sin(angle));
        frontleft = new Vector3(origin.x - RayCast_Length * Mathf.Sin(angle - Mathf.PI / 4), origin.y, origin.z - RayCast_Length * Mathf.Cos(angle - Mathf.PI / 4));
        front = new Vector3(origin.x - RayCast_Length * Mathf.Sin(angle), origin.y, origin.z - RayCast_Length * Mathf.Cos(angle));
        frontright = new Vector3(origin.x - RayCast_Length * Mathf.Sin(angle + Mathf.PI / 4), origin.y, origin.z - RayCast_Length * Mathf.Cos(angle + Mathf.PI / 4));
        right = origin + origin - left;


        CastRay();

        dis_l = hit_l.distance;
        dis_fl = hit_fl.distance;
        dis_f = hit_f.distance;
        dis_fr = hit_fr.distance;
        dis_r = hit_r.distance;

    }

    void CastRay()
    {
        //left linecast
        Physics.Linecast(origin, left, out hit_l);
        Debug.DrawLine(origin, left, Color.yellow);
        //frontleft
        Physics.Linecast(origin, frontleft, out hit_fl);
        Debug.DrawLine(origin, frontleft, Color.red);
        //front
        Physics.Linecast(origin, front, out hit_f);
        Debug.DrawLine(origin, front, Color.white);
        //frontright
        Physics.Linecast(origin, frontright, out hit_fr);
        Debug.DrawLine(origin, frontright, Color.green);
        //right
        Physics.Linecast(origin, right, out hit_r);
        Debug.DrawLine(origin, right, Color.blue);
    }
}
