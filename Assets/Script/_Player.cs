using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player : MonoBehaviour
{
    public float _Speed = 5;
    public Animator maleAnimation;
    public Animator femaleAnimation;

    public Transform male, female;
    void Update()
    {
        transform.Translate(Vector3.forward * _Speed * Time.deltaTime);
    }
}
