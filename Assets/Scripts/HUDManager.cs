using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //energy dipakai format image

public class HUDManager : MonoBehaviour
{
    public Image currentEnergy;

    private GameObject player;

    private float energy = 200;

    private float maxEnergy = 200;

    private float kecepatan;

    private float kecepatanLari;

    private float input_x;
    private float input_z;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        kecepatanLari = player.GetComponent<Gerakan_Player>().speed_lari;
    }

    // Update is called once per frame
    void Update()
    {
        kecepatan = player.GetComponent<Gerakan_Player>().kecepatan;

        input_x = player.GetComponent<Gerakan_Player>().x;
        input_z = player.GetComponent<Gerakan_Player>().z;

        EnergyDrain();
        
    }

    private void EnergyDrain(){
        if(kecepatan == kecepatanLari) {
            if(input_x > 0 || input_z > 0){
                if(energy > 0){
                    energy -= 10 * Time.deltaTime;
                }
            }
        }else{
            if(energy < maxEnergy){
                energy += 15 * Time.deltaTime;
            }
        }
        UpdateEnergy();
    }

    private void UpdateEnergy(){
        float ratio = energy / maxEnergy;

        currentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}
