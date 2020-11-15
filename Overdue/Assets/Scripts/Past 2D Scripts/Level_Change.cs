using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Make sure to add this, or you can't use SceneManager
using UnityEngine.SceneManagement;


public class Level_Change : MonoBehaviour
{

	public int Level;
	
    void OnTriggerEnter2D(Collider2D other)
    {
        //other.name should equal the root of your Player object
        if (other.name == "Player")
        {
            //The scene number to load (in File->Build Settings)
            ChangeScene();
        }
    }
    
    
   public void ChangeScene(){
    	SceneManager.LoadScene(Level);
    }
}