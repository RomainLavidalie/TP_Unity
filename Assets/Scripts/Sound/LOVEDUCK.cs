using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOVEDUCK : MonoBehaviour
{
    public float MinSoundDelay = 1;
    public float RandomDelay = 5;
    public float MinSoundPitch = 0;
    public float RandomPitch = 1;
    private float NextSoundDelay = 0;
    private float NextSoundPitch = 0;
    private AudioSource aSource;
    
    [Range(0.0f, 5.0f)]
    public float vitesseAvance = 2;
    [Range(0.0f, 360.0f)]
    public float vitesseTourne = 20;

    private void computeNextSoundDelay()
    {
        NextSoundDelay = MinSoundDelay + Random.Range(0, RandomDelay);
    }
    
    private void computeNextSoundPitch() 
    {
        NextSoundPitch = MinSoundPitch + Random.Range(0, RandomPitch);
    }

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        computeNextSoundDelay();
        computeNextSoundPitch();
    }
    
    void Update()
    {
        NextSoundDelay -= Time.deltaTime;
        if (NextSoundDelay <= 0)
        {
            aSource.pitch = NextSoundPitch;
            aSource.Play();
            computeNextSoundDelay();
            computeNextSoundPitch();
        }
        transform.position += transform.forward * Time.deltaTime * vitesseAvance;
        transform.rotation = Quaternion.AngleAxis(vitesseTourne * Time.deltaTime, Vector3.up) * transform.rotation;
    }
}