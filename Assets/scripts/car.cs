using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    // Start is called before the first frame update
    private bool carOn;
    public Transform wheelDirection;
    public float speed;
   private void Start()
    {
        carOn = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(carOn)
        {
            transform.Translate(speed*wheelDirection.forward * Time.deltaTime);
        }
    }

    public void OnLeverActive()
        { carOn = true; }
    public void OnLeverDeActive()
    { carOn = false  ; }


}
