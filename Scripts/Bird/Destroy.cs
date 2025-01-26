using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Bird")) { 
            Destroy(other.gameObject); 
        }
    }
}
