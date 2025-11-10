using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firepoint;
    public GameObject bullet;
    public AudioClip fireSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void FireGun()
    {
        GameObject newBullet = Instantiate(bullet, firepoint.position, firepoint.rotation);
        audioSource.Play();
        Destroy(newBullet, 5f);

    }
}
