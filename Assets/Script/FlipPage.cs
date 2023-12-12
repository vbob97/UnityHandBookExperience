using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class FlipPage : MonoBehaviour
{
    private enum ButtonType
    {
        NextButton,
        PrevButton
    }

    [SerializeField] AudioSource audioSource = null;
    [SerializeField] AudioClip flipPage = null;
    [SerializeField] Button nextBtn = null;
    [SerializeField] Button prevBtn = null;
    [SerializeField] Button closeBtn = null;
    private Vector3 rotationVector;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isClicked;

    private DateTime startTime;
    private DateTime endTime;
    private void Start()
    {
        startRotation = transform.rotation;
        startPosition = transform.position;
        if (nextBtn != null)
            nextBtn.onClick.AddListener(() => turnOnPageBtn_Click(ButtonType.NextButton));
        
        if (prevBtn != null)
            prevBtn.onClick.AddListener(() => turnOnPageBtn_Click(ButtonType.PrevButton));

        if( closeBtn != null)
            closeBtn.onClick.AddListener(() => closeBookBtn_Click()); 
    }

    //awake 
    private void Awake()
    {
        AppEvents.OpenBook += new EventHandler(openBookBtn_Click);
    }

    // Update is called once per frame
    private void Update()
    {
        if (isClicked)
        {
            transform.Rotate(rotationVector * Time.deltaTime * 2);

            endTime = DateTime.Now;
            if((endTime- startTime).TotalSeconds >= 1)
            {
                isClicked = false;
                transform.rotation = startRotation;
                transform.position = startPosition;
            }
        }
    }

    private void openBookBtn_Click(object sender, EventArgs e)
    {
        print("open book click in flip.cs");
    }
    private void turnOnPageBtn_Click(ButtonType type)
    {
        isClicked = true;
        startTime = DateTime.Now;

        if(type == ButtonType.NextButton){

            rotationVector = new Vector3(0, 180, 0);

        }
        else if(type == ButtonType.PrevButton){
             
            Vector3 newRotation = new Vector3(startRotation.x, 180, startRotation.z);
            transform.rotation = Quaternion.Euler(newRotation);
            rotationVector = new Vector3(0, -180, 0);
        }
    }


    private void closeBookBtn_Click(){
        AppEvents.CloseBookFunction();
    }
}
