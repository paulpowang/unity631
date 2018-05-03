﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextComboScript : MonoBehaviour {  // SHOULD CHANGE NAME OF SCRIPT TO SOMETHING MORE ACCURATE


    public Text countText;
    public Text winText;
    public Text pointCollect;

	private AudioSource[] AS;
    private bool inWater;
	//private int previousCount = 0;

    private Rigidbody rb;
    private int count;

    // Use this for initialization
    void Start () {
        inWater = false;
        rb = GetComponent<Rigidbody>();
        count = 0;
        //SetCountText();
        countText.text = "Count: " + count.ToString();
        winText.text = "";
        pointCollect.text = "";
		AS = GetComponents<AudioSource>();

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WaterTag"))// for when user enters water
        {
            pointCollect.color = Color.white;
            DisplayPointCollected("-1");
            count = count - 1;
            AudioSource PickBad = AS[0];
            PickBad.Play();
            countText.text = "Count: " + count.ToString();
        }
        countText.text = "Count: " + count.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Red"))
        {
            other.gameObject.SetActive(false);
            pointCollect.color = Color.red;
            DisplayPointCollected("+1");
            count = count + 1; 
            AudioSource Pick1 = AS[1];
            Pick1.Play();
           // SetCountText();
        }
        if (other.gameObject.CompareTag("Yellow"))
        {
            other.gameObject.SetActive(false);
            pointCollect.color = Color.yellow;
            DisplayPointCollected("+2");
            count = count + 2;
            AudioSource Pick2 = AS[2];
            Pick2.Play();
            //SetCountText();
        }
        else if (other.gameObject.CompareTag("Green"))
        {
            other.gameObject.SetActive(false);
            pointCollect.color = Color.green;
            DisplayPointCollected("+3");
            count = count + 3;
            AudioSource Pick3 = AS[3];
            Pick3.Play();
            //SetCountText();
        }
        else if (other.gameObject.CompareTag("Pink"))
        {
            other.gameObject.SetActive(false);
            pointCollect.color = Color.magenta;
            DisplayPointCollected("+4");
            count = count + 4;
            AudioSource Pick4 = AS[4];
            Pick4.Play();
            //SetCountText();
        }
        else if (other.gameObject.CompareTag("Blue"))
        {
            other.gameObject.SetActive(false);
            pointCollect.color = Color.blue;
            DisplayPointCollected("+5");
            count = count + 5;
            AudioSource Pick5 = AS[5];
            Pick5.Play();
            //SetCountText();
        }
        else if (other.gameObject.CompareTag("Purple"))
        {
            other.gameObject.SetActive(false);
            pointCollect.color = Color.cyan;
            DisplayPointCollected("+10");
            count = count + 10;
            AudioSource Pick10 = AS[6];
            Pick10.Play();
            //SetCountText();
        }
        else if (other.gameObject.CompareTag("Black") || other.gameObject.CompareTag("Zombie"))//no specific sound file so used -1
        {
            other.gameObject.SetActive(false);
            pointCollect.color = Color.black;
            DisplayPointCollected("-10");
            count = count - 10;
            AudioSource PickBad = AS[0];
            PickBad.Play();
            //SetCountText();
        }
        else if (other.gameObject.CompareTag("WaterTag"))// for when user enters water
        { 
            pointCollect.color = Color.white;
            DisplayPointCollected("-1");
            count = count - 1;
            AudioSource PickBad = AS[0];
            PickBad.Play();
            countText.text = "Count: " + count.ToString();
        }
        else if (other.gameObject.CompareTag("RainbowCube"))
        {
            other.gameObject.SetActive(false);
            pointCollect.color = Color.red;
            DisplayPointCollected("+30");
            count = count + 30;
            AudioSource PickWin = AS[7]; // was 50 one but we nerfed rainbow
            PickWin.Play();
            // SetCountText();
        }

        //Going to do you win somewhere else
        /*
        if (count >= 176) //1*9 + 2*12 + 3*15 + 4*12 + 5*8 + 10 = 9 + 24 + 45 + 48 + 40 + 10
        {
            winText.text = "You Win!";
        }
        */ 
            countText.text = "Count: " + count.ToString();
    }
    /*
	void SetCountText()// could of done switch , besides just playing sound when you increase count -- From Matthew
	{
		countText.text = "Count: " + count.ToString();
		if (count - previousCount >= 10)//
		{
			AudioSource Pick10 = AS[6];
			Pick10.Play();
		}else if (count - previousCount >= 5)//
		{
			AudioSource Pick5 = AS[5];
			Pick5.Play();
		}
		else if (count - previousCount >= 4)//
		{
			AudioSource Pick4 = AS[4];
			Pick4.Play();
		}
		else if (count - previousCount >= 3)//
		{
			AudioSource Pick3 = AS[3];
			Pick3.Play();
		}
		else if (count - previousCount >= 2)//
		{
			AudioSource Pick2 = AS[2];
			Pick2.Play();
		}
		else if (count - previousCount >= 1)//
		{
			AudioSource Pick1 = AS[1];
			Pick1.Play();
		}
		else if (count - previousCount <= -1)//
		{
			AudioSource PickBad = AS[0];
			PickBad.Play();
		}
		if (count >= 176) //1*9 + 2*12 + 3*15 + 4*12 + 5*8 + 10 = 9 + 24 + 45 + 48 + 40 + 10    //
		{
			AudioSource PickWin = AS[7];
			PickWin.Play();
			winText.text = "You Win!";
		}
		previousCount = count;
	}
    */
    void DisplayPointCollected(string point){
        pointCollect.text = point;
        StartCoroutine("WaitOneSec");
    }


    IEnumerator WaitOneSec()
    {
        yield return new WaitForSeconds(1);
        pointCollect.text = "";

    }

}