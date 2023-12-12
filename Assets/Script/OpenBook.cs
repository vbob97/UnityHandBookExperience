using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OpenBook : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button openBtn = null;
    [SerializeField] Button closeBtn = null;
    [SerializeField] GameObject openendBook = null;
    [SerializeField] GameObject insideBackCover = null;

    [SerializeField] AudioSource audioSource = null;
    [SerializeField] AudioClip openBook = null;   
    private Vector3 rotationVector;
    private  bool isOpenClicked;
    private  bool isCloseClicked;

    private DateTime startTime;
    private DateTime endTime;
    void Start()
    {
        if (openBtn != null)
            openBtn.onClick.AddListener(() => openBtn_Click());
        
        AppEvents.CloseBook += new EventHandler(closeBook_Click);

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenClicked || isCloseClicked)
        {
            transform.Rotate(rotationVector * Time.deltaTime);
            endTime = DateTime.Now;

            if (isOpenClicked)
            {
                if ((endTime - startTime).TotalSeconds >= 1)
                {
                    isOpenClicked = false;
                    gameObject.SetActive(false);
                    insideBackCover.SetActive(false);
                    openendBook.SetActive(true);

                    AppEvents.OpenBookFunction();
                }
            }
            if (isCloseClicked)
            {
                 if ((endTime - startTime).TotalSeconds >= 1)
                 {
                        isCloseClicked = false;

                 }
            }
        }
    }

    private void openBtn_Click(){
        isOpenClicked = true;
        startTime = DateTime.Now;

        rotationVector = new Vector3(0, 180, 0);

        playSound();
    }

    private void closeBook_Click(object sender, EventArgs e){
          
           gameObject.SetActive(true);
           openendBook.SetActive(false);
           insideBackCover.SetActive(true);

           isCloseClicked = true;
           startTime = DateTime.Now; 
           rotationVector = new Vector3(0, -180, 0);

           playSound();
    }

    private void playSound(){
        if (audioSource != null && openBook != null)
        {
            audioSource.PlayOneShot(openBook);
        }
    }

    void OnEnable()
    {
        HandTracking.OnSwipe += HandleSwipe;
    }

    void OnDisable()
    {
        HandTracking.OnSwipe -= HandleSwipe;
    }

    private void HandleSwipe(string direction)
    {
        if (direction == "Destra")
        {
            openBtn_Click();
        }
        else if (direction == "Sinistra")
        {
            // Logica per sfogliare le pagine verso sinistra o chiudere il libro
            AppEvents.CloseBook += new EventHandler(closeBook_Click);
        }
    }
}
