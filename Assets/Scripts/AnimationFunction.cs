using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFunction : MonoBehaviour
{
   [SerializeField] MenuButtonController menuButtonController;
    // Start is called before the first frame update
   void PlaySound(AudioClip whichSound){
       menuButtonController.audioSource.PlayOneShot(whichSound);
   }
}
