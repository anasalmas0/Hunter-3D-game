using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoping : MonoBehaviour
{
    public Animator animator; 
    public GameObject overlay ;
    public GameObject weaponCamera ;
    public Canvas overlayCanvas; 
    public Canvas buttonCanvas;  
    public Camera mainCamera ;
    public float scopeFOV = 25f ;
    private float normalFOV ;
    private bool isScoped = false; 
    // private bool isPressed = false;
     

    void Update()
    {
        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);
            
        //     if (touch.phase == TouchPhase.Began && !isPressed)
        //     {
        //         ToggleScope(); 
        //         isPressed = true;  
        //     }
        //     else if (touch.phase == TouchPhase.Ended)
        //     {
        //         //  isPressed = false;
        //     }
        // }
    }

    public void OnScopeButtonPressed()
    {
        ToggleScope();
    }

    private void ToggleScope()
    {
        isScoped = !isScoped;
       
        animator.SetBool("Scoped", isScoped);
        if(isScoped){
            StartCoroutine(OnScoped());
        }else{
             StartCoroutine(OnUnScoped());
        }

        Debug.Log("Scoped toggled: " + isScoped);
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);
        overlay.SetActive(true);
        weaponCamera.SetActive(false);
        normalFOV = mainCamera.fieldOfView ;
        mainCamera.fieldOfView = scopeFOV ;


        CanvasGroup canvasGroup = overlay.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = false; 
        }
        overlayCanvas.sortingOrder = 0; 
        buttonCanvas.sortingOrder = 1; 
    }

     IEnumerator OnUnScoped()
    {
        yield return new WaitForSeconds(.15f);
        overlay.SetActive(false);
        weaponCamera.SetActive(true);
         mainCamera.fieldOfView = normalFOV ;

        CanvasGroup canvasGroup = overlay.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = true; 
        }
        overlayCanvas.sortingOrder = 1; 
        buttonCanvas.sortingOrder = 1; 
    }

}
