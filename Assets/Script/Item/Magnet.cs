using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    //informações do ima

    [SerializeField] private float speed = 3f;
    [SerializeField] private float distance;

    [SerializeField] private Transform magnetTransform;

    //teste de função
    public Rigidbody2D rgd2d;

    void Start(){
        rgd2d = gameObject.GetComponent<Rigidbody2D>();
        //magnetTransform = transform.Find("Magnet");
        distance = Vector2.Distance(transform.position, magnetTransform.position);
    }

    void Update() {

        if (distance < 6){
            rgd2d.bodyType = RigidbodyType2D.Dynamic;
            transform.position = Vector2.MoveTowards(transform.position, magnetTransform.position, speed * Time.deltaTime);
        }
        else {
            rgd2d.bodyType = RigidbodyType2D.Kinematic;
        }

    }

}