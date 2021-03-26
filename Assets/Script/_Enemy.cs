using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Enemy : MonoBehaviour
{
    public float _Speed = 5;
    public Animator maleAnimation;
    public Animator femaleAnimation;

    public Transform male, female;
    void Update()
    {
        transform.Translate(Vector3.forward * _Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "1":
                maleAnimation.SetTrigger("limboo");
                femaleAnimation.SetTrigger("limboo");
                break;

            case "2":
                maleAnimation.SetTrigger("waltz");
                femaleAnimation.SetTrigger("waltz");
                _Speed = 1.2f;
                break;
        }
    }
}
