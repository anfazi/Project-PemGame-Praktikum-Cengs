using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player; //variabel player model transform

    private void LateUpdate(){
        Vector3 newPosition = player.position;  //membuat variabel baru newPosition dan isinya adalah posisi player
        newPosition.y = transform.position.y; //sistem kamera mengikuti sumbu Y
        transform.position = newPosition; //mengatur kamera selalu mengikuti posisi sesuai variabel newPosition

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f); //FUngsi kamera mengikuti rotasi player
    }

}
