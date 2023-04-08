using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class CheckCollider : MonoBehaviour
{
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip failureSound;
    [SerializeField] ParticleSystem succeededParticle;
    [SerializeField] ParticleSystem failedParticle;

    AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!GameManager.instance.isAlive) { return; }
        switch (collision.gameObject.tag)
        {
            case "Start":
                print("Game start");
                break;
            case "Finish":
                IsFinishCheck();
                break;
            case "Obstacle":
                DestroyCheck();
                break;
            case "Ground":
                DestroyCheck();
                break;
            case "Fuel":
                print("Add fuel");
                break;
        }
    }

    void IsFinishCheck()
    {
        succeededParticle.Play();
        sound.PlayOneShot(successSound);
        GameManager.instance.DelayCall("Finish");
    }
    void DestroyCheck()
    {
        failedParticle.Play();
        sound.PlayOneShot(failureSound);
        GameManager.instance.DelayCall("Obstacle");
    }
}
