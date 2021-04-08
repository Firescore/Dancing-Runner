using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _UIManager : MonoBehaviour
{
    public _Player player;

    public Animator male, female;
    public GameObject[] button;

    public float time;
    bool isLinbooPressed = false;
    bool isWaltzPressed = false;
    void Start()
    {
        player = FindObjectOfType<_Player>();
        button[1].GetComponent<Animator>().Play("Highlited");
    }


    private void Update()
    {
        
        if(isLinbooPressed && !isWaltzPressed && !player.lineTouched)
        {
            player.female.localPosition = Vector3.Lerp(player.female.localPosition, new Vector3(1.5f, player.female.localPosition.y, player.female.localPosition.z), 5f * Time.deltaTime);
            player.male.localPosition = Vector3.Lerp(player.male.localPosition, new Vector3(-0.5f, player.male.localPosition.y, player.male.localPosition.z), 5f * Time.deltaTime);
        }
        

        if(isWaltzPressed && !isLinbooPressed && !player.lineTouched)
        {
            player.female.localPosition = Vector3.Lerp(player.female.localPosition, new Vector3(0.54f, player.female.localPosition.y, player.female.localPosition.z), 5f * Time.deltaTime);
            player.male.localPosition = Vector3.Lerp(player.male.localPosition, new Vector3(0f, player.male.localPosition.y, player.male.localPosition.z), 5f * Time.deltaTime);
        }
    }

    public void resetButton(int a)
    {
        if (button[a].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Click"))
        {
            button[a].GetComponent<Animator>().SetTrigger("close");
        }
    }
    public void setLimbooDance()
    {        
        StartCoroutine(Limboo(time));
    }

    public void setWaltzDance()
    {
        StartCoroutine(Waltz(time));
    }

    public void setBboyDance()
    {
        StartCoroutine(Bboy(time));
    }

   IEnumerator Bboy(float a)
    {
        yield return new WaitForSeconds(0.2f);
        male.Play("Glow");
        female.Play("Glow");

        yield return new WaitForSeconds(a);


        isLinbooPressed = true;
        isWaltzPressed = false;

        player.maleAnimation.SetTrigger("bboy");
        player.femaleAnimation.SetTrigger("bboy");
    }

    IEnumerator Waltz(float a)
    {
        yield return new WaitForSeconds(0.2f);
        male.Play("Glow");
        female.Play("Glow");

        yield return new WaitForSeconds(a);


        isLinbooPressed = false;
        isWaltzPressed = true;

        player.maleAnimation.SetTrigger("waltz");
        player.femaleAnimation.SetTrigger("waltz");
    }

    IEnumerator Limboo(float a)
    {
        yield return new WaitForSeconds(0.2f);
        male.Play("Glow");
        female.Play("Glow");
        yield return new WaitForSeconds(a);


        isLinbooPressed = true;
        isWaltzPressed = false;

        player.maleAnimation.SetTrigger("limboo");
        player.femaleAnimation.SetTrigger("limboo");

    }
    }
