using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rules : MonoBehaviour
{
    public GameObject rulesMenuUI;

    public void CloseRules()
    {
        rulesMenuUI.SetActive(false);
    }
}
