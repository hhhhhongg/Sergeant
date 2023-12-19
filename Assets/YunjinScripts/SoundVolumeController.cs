using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeController : MonoBehaviour
{
    public Slider bgm_slider;
    public Slider sfx_slider;

    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = SoundManager.instance;
        bgm_slider.value = _soundManager.GetBGM_Volume();
        sfx_slider.value = _soundManager.GetSFX_Volume();
    }

    public void BGM_Sliderset(float value)
    {
        _soundManager.SetBGM_Volume(value);
    }
    public void SFX_Sliderset(float value)
    {
        _soundManager.SetSFX_Volume(value);
    }
    
    public void XButton()
    {
        this.gameObject.SetActive(false);
    }     

}
