using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void start(){
        SceneManager.LoadScene("levelone");
    }
    
    public void help(){
        SceneManager.LoadScene("help");
    }
    
    public void backMenu(){
        SceneManager.LoadScene("menu");
    }
    
    public void quit(){
        Debug.Log("Quit!");
        Application.Quit();
    }
}
