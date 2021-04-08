using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _cliff : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            GetComponent<Animator>().SetFloat("close", 1);
        }

        if (other.gameObject.name == "Enemy")
        {
            GetComponent<Animator>().SetFloat("close", 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            GetComponent<Animator>().SetFloat("close", 0);
        }

        if (other.gameObject.name == "Enemy")
        {
            GetComponent<Animator>().SetFloat("close", 0);
        }
    }
}
