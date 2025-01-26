using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelector : MonoBehaviour
{
    int currentGunIndex = 2;
    public GameObject[] GunModels ;

    void Start()
    {
        currentGunIndex = PlayerPrefs.GetInt("SelectedGun",0);
      foreach(GameObject gun in GunModels ){
        gun.SetActive(false);
      }  

      GunModels[currentGunIndex].SetActive(true);
    }
}
