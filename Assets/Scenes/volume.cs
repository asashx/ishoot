using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume : MonoBehaviour
{
    public AudioSource bgmAudio;
    public Slider volumeSlider;

    // Update is called once per frame
    private void Update()
    {
        bgmAudio.volume = volumeSlider.value;
    }
    
}
