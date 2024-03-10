using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject[] cameras; // массив позиций камеры
    public int i = 0; // индекс активной позиции

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            cameras[i].SetActive(false);
            switch (i)
            {
                case 3:
                    i = 0;
                    break;
                default:
                    i++;
                    break;
            }
            cameras[i].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cameras[i].SetActive(false);
            switch (i)
            {
                case 0:
                    i = 3;
                    break;
                default:
                    i--;
                    break;
            }
            cameras[i].SetActive(true);
        }
    }
}
