using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    public string mixerParameter;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        float getValue;
        audioMixer.GetFloat(mixerParameter, out getValue);
        slider.value = VolumeToValue(getValue);
    }

    public void VolumeUpdate()
    {
        audioMixer.SetFloat(mixerParameter, ValueToVolume(slider.value));
    }

    private float ValueToVolume(float value)
    {
        return Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20;
    }

    private float VolumeToValue(float value){
        return Mathf.Pow(10, value / 20);
    }
}
