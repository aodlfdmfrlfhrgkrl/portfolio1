using System;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objectDictionarry = new Dictionary<Type, UnityEngine.Object[]>();

    enum Button
    {
        PointButton
    }
    enum Text
    {
        PointText,
        ScoreText
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objectDictionarry.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            objects[i] = Utility.FindChild<T>(gameObject, names[i], true);

        }
    }
}
