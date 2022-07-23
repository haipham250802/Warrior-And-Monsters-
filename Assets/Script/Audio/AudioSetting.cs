using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider VolumeSlider;
    // Start is called before the first frame update
    private void Awake()
    {
        VolumeSlider.value = DataPlayer.GetVolume();
        audioSource.volume = VolumeSlider.value;
    }
    private void Start()
    {
        VolumeSlider.value = DataPlayer.GetVolume();
    }
    // Update is called once per frame
    void Update()
    {
        DataPlayer.SetVolume(VolumeSlider.value);
        audioSource.volume = DataPlayer.GetVolume();
    }
}
