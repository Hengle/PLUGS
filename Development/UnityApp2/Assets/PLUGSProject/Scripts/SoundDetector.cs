using UnityEngine;
using System.Collections;

public class SoundDetector : MonoBehaviour
{
    //float[] samples;


    //void Start()
    //{
    //    aud = GetComponent<AudioSource>();
    //    aud.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);

    //    while (!(Microphone.GetPosition(null) > 0))
    //    {
    //    }
    //    aud.Play();

    //    samples = new float[4096]; // 4096 = around 85 ms of samples
    //}

    //void Update()
    //{
    //    float vol = GetRMS(0) + GetRMS(1);

    //    Debug.Log("Vol:" + vol); // the actual intensity/ volume of the sound from the microphone
    //}

    //float GetRMS(int channel)
    //{
    //    aud.GetOutputData(samples, channel); // fill array with samples
    //    float sum = 0;
    //    for (FIXME_VAR_TYPE i = 0; i < 4096; i++)
    //    {
    //        sum += samples * samples; // sum squared samples
    //    }
    //    return Mathf.Sqrt(sum / 4096); // rms = square root of average 
    //}
}