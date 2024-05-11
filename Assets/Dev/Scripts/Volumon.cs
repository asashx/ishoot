using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Volumon : MonoBehaviour
{
    public GameObject volumSub;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void volumeon() {
        volumSub.SetActive(true);
    }

    public void volumeoff() {
        volumSub.SetActive(false);
    }
}
