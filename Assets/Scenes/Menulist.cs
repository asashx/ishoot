using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menulist : MonoBehaviour
{
    public GameObject menuXiu;
    
    public bool isStop = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isStop) {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                menuXiu.SetActive(true);
                isStop = false;
                Time.timeScale = (0);
            }
        } else if(Input.GetKeyDown(KeyCode.Escape)) {
            menuXiu.SetActive(false);
            isStop = true;
            Time.timeScale = (1);
        }
    }

    public void Resume() {
        Debug.Log("Resume"); 
        if(menuXiu!=null){
        Debug.Log("not null");
        }         
          menuXiu.SetActive(false);
            isStop = true;
            Time.timeScale = (1);
    }

    public void Back() {
        SceneManager.LoadScene(0);
    }
}
