using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player : MonoBehaviour
{
    [SerializeField] private _UIManager uimanager;
    public float _Speed = 5;
    public Animator maleAnimation;
    public Animator femaleAnimation;

    public bool lineTouched = false;
    public bool FinishLineTouched = false;

    float horizontalMove;
    public Transform male, female;

    float t = 90;

    private void Start()
    {
        uimanager = FindObjectOfType<_UIManager>();
    }
    void Update()
    {
        if (transform.position.x >= 2.5f)
        {
            transform.position = new Vector3(2.5f,transform.position.y,transform.position.z);
        }
        
        if(transform.position.x<= -1.6f)
        {
            transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);
        }

        transform.Translate(Vector3.forward * (_Speed *2)* Time.deltaTime);
        horizontalMove = Input.GetAxis("Horizontal");

        if (lineTouched && !FinishLineTouched)
        {
            uimanager.button[0].GetComponent<Animator>().SetBool("Hide",true);
            uimanager.button[1].GetComponent<Animator>().SetBool("Hide",true);
            uimanager.button[2].GetComponent<Animator>().SetBool("Hide",true);

            transform.Translate(Vector3.right * horizontalMove * (_Speed * 3) * Time.deltaTime);
            female.localPosition = Vector3.Lerp(female.localPosition, new Vector3(0, female.localPosition.y, female.localPosition.z), 5f * Time.deltaTime);
            male.localPosition = Vector3.Lerp(male.localPosition, new Vector3(0, male.localPosition.y, -0.765f), 5f * Time.deltaTime);
        }

        if (FinishLineTouched)
        {
            
            female.localPosition = Vector3.Lerp(female.localPosition, new Vector3(1.5f, female.localPosition.y, female.localPosition.z), 2.5f * Time.deltaTime);
            male.localPosition = Vector3.Lerp(male.localPosition, new Vector3(-0.5f, male.localPosition.y, -0.1700001f), 2.5f * Time.deltaTime);

            female.localEulerAngles = new Vector3(female.localEulerAngles.x, t, female.localEulerAngles.z);
            male.localEulerAngles = new Vector3(male.localEulerAngles.x, t, male.localEulerAngles.z);
            if (t > -90)
            {
                t -= 5;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("line"))
        {
            lineTouched = true;
            maleAnimation.SetTrigger("line");
            femaleAnimation.SetTrigger("line");
        }
        if (other.CompareTag("coin"))
            Destroy(other.gameObject);

        if (other.CompareTag("finishLine"))
        {
            _Speed = 0;
            FinishLineTouched = true;
            maleAnimation.Play("Male Walking Bboy");
            femaleAnimation.Play("Female Walking Bboy");
        }
    }
}
