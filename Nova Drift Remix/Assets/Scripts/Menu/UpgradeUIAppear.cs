using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUIAppear : MonoBehaviour
{
    [SerializeField] private GameObject upgradeUI;

    [SerializeField] private GameObject upgradeUI2;

    [SerializeField] private GameObject upgradeUI3;

    //turns upgrade UI on
    public void ActivateUI()
    {
        upgradeUI.SetActive(true);
        upgradeUI2.SetActive(true);
        upgradeUI3.SetActive(true);
    }
}
