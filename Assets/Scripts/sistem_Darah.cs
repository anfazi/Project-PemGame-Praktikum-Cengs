using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sistem_Darah : MonoBehaviour
{
    public float darah_player;
    // Start is called before the first frame update
    void Start()
    {
        darah_player = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (darah_player > 0){
            Debug.Log("Player Hidup");
        }else{
            Debug.Log("Player Mati");
            darah_player = 0;
        }
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Obstacle"){
            darah_player -= 30f;
            Debug.Log("Darah ="+ darah_player);
        }
    }
}
