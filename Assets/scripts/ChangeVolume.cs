using UnityEngine;
using UnityEngine.Audio;

public class ChangeVolume : MonoBehaviour
{
    public AudioMixer am;
    public void changeVolume(float volume)
    {
        am.SetFloat("Volume", volume);
    }
}
