using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Play(){
        CutsceneManager.Instance.StartCutscene("PlayCutscene"); // Запуск катсцены по ключу
    }
}
