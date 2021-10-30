using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animasi : MonoBehaviour
{
    //variabel
   //private float kecepatan_player;
    private float nilai_x;
    private float nilai_z;
    private bool status_ground;

    //referensi
    private Animator anim;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //kecepatan_player = player.GetComponent<Gerakan_Player>().kecepatan;
        nilai_x = player.GetComponent<Gerakan_Player>().x;
        nilai_z = player.GetComponent<Gerakan_Player>().z;
        status_ground = player.GetComponent<Gerakan_Player>().isGrounded;
        //anim.SetFloat("speed", kecepatan_player);
        anim.SetFloat("x", nilai_x);
        anim.SetFloat("z", nilai_z);
        anim.SetBool("isGrounded", status_ground);
    }
}
