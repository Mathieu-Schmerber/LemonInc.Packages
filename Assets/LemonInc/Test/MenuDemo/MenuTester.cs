using System;
using System.Collections;
using LemonInc.Core.Utilities.Ui.Menu;
using UnityEngine;

namespace LemonInc.Test.MenuDemo
{
    public class MenuTester : MonoBehaviour
    {
        private LoaderMenuUi _loader;

        private void Awake()
        {
            _loader = GetComponentInChildren<LoaderMenuUi>();
        }

        private void Start()
        {
            _loader.RunWithTransition(onFadedIn: OnFadedIn, onFadedOut: () => Debug.Log("Faded Out"));
        }

        private IEnumerator OnFadedIn()
        {
            Debug.Log("Process start");
            yield return new WaitForSeconds(1f);
            Debug.Log("Process end");
        }
    }
}