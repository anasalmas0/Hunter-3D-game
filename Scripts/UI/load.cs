
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void back(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
