using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public int maxAmmo = 5;
    public int currentAmmo ;
    private float relodingTime = 1f ;
    public bool isReloding = false; 
    public float damage = 10f;
    public float ShootRange = 500f ;
    public float impactforce = 30f ;
    public GameObject mainCamera;
    public ParticleSystem muzzleFlash ; 
    public GameObject impactEffect ;
    public AudioSource audioSource; 
    public AudioSource audiosource; 
    public AudioClip soundClip;
    public AudioClip soundclip;

     void Start() {

        currentAmmo = maxAmmo;

        
        
    }
    private void OnEnable() {
        isReloding = false ;
    }


    void Update()
    {

        if (isReloding){
            return;
        }

        // if (currentAmmo <= 0 ){
        //     StartCoroutine(Reload());
        //     return ;
        // }

      

    
    }

    public void Fire(){
        if(currentAmmo >= 1 ){
        muzzleFlash.Play();

        currentAmmo --;

        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip); 
        }

        RaycastHit hit ;

       if( Physics.Raycast(mainCamera.transform.position,mainCamera.transform.forward,out hit , ShootRange))
       {
        Debug.Log(hit.transform.name);

       }

       Target target = hit.transform.GetComponent<Target>();
       Target2 target2 = hit.transform.GetComponent<Target2>();
       
       if(target != null  ){
        target.TakeDamage(damage);
         }

          if(target2 != null  ){
        target2.takeDamage(damage);
         }
      
      
      
       if (hit.rigidbody != null){
        hit.rigidbody.AddForce(-hit.normal * impactforce );
       }
       Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));

       if(Pause.gameIsPause){
        audioSource.Stop();
       }
        }

    }

    IEnumerator Reload(){

        isReloding = true;
        

        yield return new WaitForSeconds(relodingTime - .25f);
        if (audiosource != null && soundclip != null)
        {
            audiosource.PlayOneShot(soundclip); 
        }

        currentAmmo = maxAmmo ;
        yield return new WaitForSeconds(.25f);
         isReloding = false;

    }

    public void ReloadButton(){
       if (!isReloding && currentAmmo < maxAmmo) {
            StartCoroutine(Reload());
        }
    }

    void Shoot(){

    }

    
}
