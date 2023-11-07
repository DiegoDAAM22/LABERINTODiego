using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System;


public class contador : MonoBehaviour
{
    public TMP_Text textoContador;
    public float tiempo = 0f;

    // Start is called before the first frame update
    void Start()
    {
        textoContador.text = "inicio";
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        //tiempo =Vtiempo + Time.deltaTime;
        //1s
        //2s
        //
        //3s
        textoContador.text = ((int) tiempo).ToString();
        //1 + 2 + 3 >
    }
}
