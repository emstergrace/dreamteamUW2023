using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    GameObject toggle;

    private void Start()
    {
        toggle = GameObject.Find("Mute Audio Toggle");
        if (AudioListener.volume > 0)
        {
            toggle.GetComponent<Toggle>().isOn = false;
        }
        else
        {
            toggle.GetComponent<Toggle>().isOn = true;
        }
    }

    public void MuteToggle(bool muted)
    {
        if (muted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
