using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Enemy : MonoBehaviour
{
    public float _Speed = 5;
    public Animator maleAnimation;
    public Animator femaleAnimation;

    public Transform male, female;

    private bool isLinbooPressed = false, isWaltzPressed = false;
    void Update()
    {
        transform.Translate(Vector3.forward * _Speed * Time.deltaTime);

        if (isLinbooPressed && !isWaltzPressed)
        {
            female.localPosition = Vector3.Lerp(female.localPosition, new Vector3(1.5f, female.localPosition.y, female.localPosition.z), 5f * Time.deltaTime);
            male.localPosition = Vector3.Lerp(male.localPosition, new Vector3(-0.5f, male.localPosition.y, male.localPosition.z), 5f * Time.deltaTime);
        }


        if (isWaltzPressed && !isLinbooPressed)
        {
            female.localPosition = Vector3.Lerp(female.localPosition, new Vector3(0.54f, female.localPosition.y, female.localPosition.z), 5f * Time.deltaTime);
            male.localPosition = Vector3.Lerp(male.localPosition, new Vector3(0f, male.localPosition.y, male.localPosition.z), 5f * Time.deltaTime);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "1":
                maleAnimation.SetTrigger("limboo");
                femaleAnimation.SetTrigger("limboo");
                isLinbooPressed = true;
                isWaltzPressed = false;
                _Speed = 2f;
                break;

            case "2":
                maleAnimation.SetTrigger("waltz");
                femaleAnimation.SetTrigger("waltz");
                isLinbooPressed = false;
                isWaltzPressed = true;
                _Speed = 3f;
                break;
            case "3":
                maleAnimation.SetTrigger("bboy");
                femaleAnimation.SetTrigger("bboy");
                isLinbooPressed = true;
                isWaltzPressed = false;
                _Speed = 1f;
                break;
            case "sBrecker":
                _Speed = 0.5f;
                break;
        }
    }
}
