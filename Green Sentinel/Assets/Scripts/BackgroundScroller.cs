using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform tBG1, tBG2;
    public float fScrollSpeed;

    private float fBgWidth;

    public bool bIsCredits;

    // Start is called before the first frame update
    void Start()
    {
        //assigns bgWidth the size of the SpriteRenderer component by looking at BG1 and it's sprite/bounds/size along the x axis
        //this tells us how wide the image at BG1 is
        fBgWidth = tBG1.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bIsCredits)
        {
            //code for moving BG1
            tBG1.position = new Vector3(tBG1.position.x - (fScrollSpeed * Time.deltaTime), tBG1.position.y, tBG1.position.z);
            //same as the above codes
            tBG2.position -= new Vector3(fScrollSpeed * Time.deltaTime, 0f, 0f);
            //checks if the position of BG1 has moved off the screen

            if (tBG1.position.x < -fBgWidth - 1)
            {
                //tells unity to move the position of BG1 two position to the right
                tBG1.position += new Vector3(fBgWidth * 2f, 0f, 0f);
            }

            if (tBG2.position.x < -fBgWidth - 1)
            {
                //tells unity to move the position of BG2 two position to the right
                tBG2.position += new Vector3(fBgWidth * 2f, 0f, 0f);
            }
        }
        else
        {
            //code for moving BG1
            tBG1.position = new Vector3(tBG1.position.x + (fScrollSpeed * Time.deltaTime), tBG1.position.y, tBG1.position.z);
            //same as the above codes
            tBG2.position += new Vector3(fScrollSpeed * Time.deltaTime, 0f, 0f);
            //checks if the position of BG1 has moved off the screen

            if (tBG1.position.x > fBgWidth - 1)
            {
                //tells unity to move the position of BG1 two position to the right
                tBG1.position += new Vector3(fBgWidth * -2f, 0f, 0f);
            }

            if (tBG2.position.x > fBgWidth - 1)
            {
                //tells unity to move the position of BG2 two position to the right
                tBG2.position += new Vector3(fBgWidth * -2f, 0f, 0f);
            }
        }
    }
}
