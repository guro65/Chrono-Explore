using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Texto : MonoBehaviour
{
    string myText =$"Ei estou trocando de roupa, não olhe!!.";
    char[] crt;
    public int time = 2;
    public Text viewer;
    List<string> elements = new List<string>()
    {"posso n to sem dinheiro","fas o L",};

    // Start is called before the first frame update
    void Start()
    {
        crt = myText.ToCharArray();

        StartCoroutine(ShowText());
    }
 IEnumerator ShowText()
   {
    int count = 0;
    while(count < crt.Length) 
    {
        yield return new WaitForSeconds(0);
        viewer.text += crt[count];
        count++;
    }
   }
}
