using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    int currentGunIndex = 0;
    public GameObject[] GunModels ;
    public GunProperties[] guns ; 
    public Button buyButton ;

    void Start()
    {
      foreach (GunProperties gun in guns)
      {
        if(gun.price == 0){
          gun.isUnlocked = true ;
        }else{
          gun.isUnlocked = PlayerPrefs.GetInt(gun.Name,0)== 0 ? false : true ;
        }
        
      }
        currentGunIndex = PlayerPrefs.GetInt("SelectedGun",0);
      foreach(GameObject gun in GunModels ){
        gun.SetActive(false);
      }  

      GunModels[currentGunIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI ();
    }

    public void NextGun () {
         GunModels[currentGunIndex].SetActive(false);
         currentGunIndex++ ;
         if(currentGunIndex == GunModels.Length){
            currentGunIndex = 0 ;
         }        
          GunModels[currentGunIndex].SetActive(true);
          GunProperties g = guns[currentGunIndex];
          if(!g.isUnlocked){
            return;
          }
           PlayerPrefs.SetInt("SelectedGun",currentGunIndex);
    }

    public void PreviousGun () {
         GunModels[currentGunIndex].SetActive(false);
         currentGunIndex-- ;
         if(currentGunIndex == -1){
            currentGunIndex = GunModels.Length -1 ;
         }        
          GunModels[currentGunIndex].SetActive(true);
          GunProperties g = guns[currentGunIndex];
          if(!g.isUnlocked){
            return;
          }
           PlayerPrefs.SetInt("SelectedGun",currentGunIndex);
    }

    public void UpdateUI () {
      GunProperties g = guns[currentGunIndex];
      if(g.isUnlocked){
        buyButton.gameObject.SetActive(false);
        
      }else{
        buyButton.gameObject.SetActive(true);
        buyButton.GetComponentInChildren<Text>(true).text = "buy-" + g.price;
        if(g.price <= PlayerPrefs.GetInt("Coins",0)){
          buyButton.interactable = true ;
        }else{
          buyButton.interactable = false ;
        }
      }
    }
    public void UnlockCar () {
      GunProperties g = guns[currentGunIndex];
      PlayerPrefs.SetInt(g.Name ,1);
      PlayerPrefs.SetInt("SelectedGun" ,currentGunIndex);
      g.isUnlocked = true ;
      PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins",0)-g.price);

    }
}
