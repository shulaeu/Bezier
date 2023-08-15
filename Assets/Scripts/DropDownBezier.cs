using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownBezier : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private BezierListView bezierListView;

    void Start()
    {
        List<string> names = bezierListView.GetChildList();
        foreach (string childName in names)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(childName));
            //TODO
            //dropdown.options.Add(option);
        }
    }
}
