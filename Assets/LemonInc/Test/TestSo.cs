using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TestSo", menuName = "TestSo", order = 1)]
public class TestSo : ScriptableObject
{
    [Serializable]
    public class TestProp
    {
        public string TestField;
    }

    public GameObject Prefab;
    public TestProp TestProperty;
}
