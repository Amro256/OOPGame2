using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
     //Audio Clips that will be dropped into the inspector 
    [SerializeField] AudioClip PlayerJump;
    [SerializeField] AudioClip PlayerDash;
    [SerializeField] AudioClip Checkpoint;
    [SerializeField] AudioClip EnemyDeath;
    [SerializeField] AudioClip KillZone;
    [SerializeField] AudioClip BulletSound;
    [SerializeField] AudioClip CoinSound;
    AudioSource audioSource;  ///Refernce to the AudioSource Component
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Methods that can be called in other scripts to play the audio
   public void PlayerJumpSound()
   {
        audioSource.PlayOneShot(PlayerJump);
   }

   public void PlayerDashSound()
   {
        audioSource.PlayOneShot(PlayerDash);
   }
   public void CheckpointSound()
   {
        audioSource.PlayOneShot(Checkpoint);
   }
   public void EnemeySound()
   {
        audioSource.PlayOneShot(EnemyDeath);
   }

   public void KillZoneSound()
   {
        audioSource.PlayOneShot(KillZone);
   }

    public void BulletSoundEffect()
   {
        audioSource.PlayOneShot(BulletSound);
   }

   public void CoinsSound()
   {
        audioSource.PlayOneShot(CoinSound);
   }
   

   
}
