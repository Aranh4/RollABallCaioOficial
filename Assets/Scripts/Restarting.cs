using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restarting : MonoBehaviour
{
 
    public void RestartGame() {
        SceneManager.LoadSceneAsync(0);
    }
    
    
}
