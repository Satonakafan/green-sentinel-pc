using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompletionScene : MonoBehaviour
{
    public GameObject gOLine1, gOLine2;
    public GameObject gOPlayerShip;
    public GameObject gOMainMenuBtn;

    public float fShipMovement = 5;

    public void Start()
    {
        StartCoroutine(EndScreenDisplayCo());
    }

    public void  MainMenu()
    {
        UIManager.instance.QuitToMainMenu();
    }

    public IEnumerator EndScreenDisplayCo()
    {
        gOPlayerShip.GetComponent<MovingObject>().fMoveSpeed = 2;

        yield return new WaitForSeconds(3f);

        gOLine1.SetActive(true);

        yield return new WaitForSeconds(3f);

        gOLine2.SetActive(true);

        yield return new WaitForSeconds(3f);


        //yield return new WaitForSeconds(3f);

        gOMainMenuBtn.SetActive(true);
    }
}
