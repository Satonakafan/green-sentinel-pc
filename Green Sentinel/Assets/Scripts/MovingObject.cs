using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float fMoveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(fMoveSpeed * Time.deltaTime, 0f, 0f);
    }

    //function that destroys objects once they disappear off the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
