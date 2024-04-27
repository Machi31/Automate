using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Play(){
        CutsceneManager.Instance.StartCutscene("PlayCutscene"); // Запуск катсцены по ключу
    }

    public void Settings(){
        CutsceneManager.Instance.StartCutscene("SettingsCutscene"); // Запуск катсцены по ключу
    }

    public void ExitPlay(){
        CutsceneManager.Instance.StartCutscene("ExitPlayCutscene"); // Запуск катсцены по ключу
    }

    public void ExitSettings(){
        CutsceneManager.Instance.StartCutscene("ExitSettingsCutscene"); // Запуск катсцены по ключу
    }
}
