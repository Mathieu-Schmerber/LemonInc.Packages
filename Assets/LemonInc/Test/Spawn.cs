using System.Collections;
using System.Collections.Generic;
using Databases;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    Instantiate(RuntimeDatabase.Section.NewAsset);
    }
}