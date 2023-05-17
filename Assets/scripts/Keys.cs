using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Keys : MonoBehaviour
{


    public TMP_Dropdown dropdown;


    public TMP_InputField key;


    // Start is called before the first frame update
    void Start()
    {
        dropdown = this.GetComponentInChildren<TMP_Dropdown>();

        key = this.GetComponentInChildren<TMP_InputField>();


        this.GetComponentInChildren<Button>().onClick.AddListener(() =>
        {



            try
            {
                KeyCode cd = Enum.Parse<KeyCode>(key.text);

                typeof(UIController).GetField(dropdown.options[dropdown.value].text).SetValue(null, cd);
            }
            catch (Exception e)
            {

            }

        });




        dropdown.onValueChanged.AddListener((s) =>
        {


            var c = (KeyCode)typeof(UIController).GetField(dropdown.options[s].text).GetValue(null);

            key.text = c.ToString();

        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
