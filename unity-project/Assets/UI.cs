using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonSelect1 = root.Q<Button>("ButtonSelect1"); 
        Button buttonSelect2 = root.Q<Button>("ButtonSelect2"); 
        Button buttonSelect3 = root.Q<Button>("ButtonSelect3");

        buttonSelect1.clicked += () => Debug.Log("Selected Character 1");
        buttonSelect2.clicked += () => Debug.Log("Selected Character 2");
        buttonSelect3.clicked += () => Debug.Log("Selected Character 3");
    }
}
