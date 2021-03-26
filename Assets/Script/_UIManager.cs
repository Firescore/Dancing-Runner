using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _UIManager : MonoBehaviour
{
    public _Player player;

    bool isLinbooPressed = false;
    bool isWaltzPressed = false;
    void Start()
    {
        player = FindObjectOfType<_Player>();
    }


    private void Update()
    {
        
        if(isLinbooPressed && !isWaltzPressed)
            player.female.localPosition = Vector3.Lerp(player.female.localPosition, new Vector3(1f, player.female.localPosition.y, player.female.localPosition.z), 1f * Time.deltaTime);

        if(isWaltzPressed && !isLinbooPressed)
            player.female.localPosition = new Vector3(0.54f, player.female.localPosition.y, player.female.localPosition.z);
    }
    public void setLimbooDance()
    {
        //player.female.localPosition = new Vector3(0.73f, player.female.localPosition.y, player.female.localPosition.z);
        
        isLinbooPressed = true;
        isWaltzPressed = false;
        player.maleAnimation.SetTrigger("limboo");
        player.femaleAnimation.SetTrigger("limboo");
    }

    public void setWaltzDance()
    {

        isLinbooPressed = false;
        isWaltzPressed = true;
        player.maleAnimation.SetTrigger("waltz");
        player.femaleAnimation.SetTrigger("waltz");
    }

    public void setBboyDance()
    {
        isLinbooPressed = true;
        isWaltzPressed = false;
        player.maleAnimation.SetTrigger("bboy");
        player.femaleAnimation.SetTrigger("bboy");
    }
}
