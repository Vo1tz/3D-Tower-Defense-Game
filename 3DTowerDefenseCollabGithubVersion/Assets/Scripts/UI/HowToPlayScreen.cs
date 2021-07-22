using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayScreen : MonoBehaviour
{
    public GameObject how2play;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;

    private int toporder = 5;
    private int lowerorder = 2;
    private int currentorder;

    void Start()
    {
        currentorder = 1;
    }

    void Update()
    {
        if (currentorder == 1)
        {
            panel1.SetActive(true);
            panel2.SetActive(false);
            panel3.SetActive(false);
            panel4.SetActive(false);
            panel5.SetActive(false);
        }
        if (currentorder == 2)
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
            panel3.SetActive(false);
            panel4.SetActive(false);
            panel5.SetActive(false);
        }
        if (currentorder == 3)
        {
            panel1.SetActive(false);
            panel2.SetActive(false);
            panel3.SetActive(true);
            panel4.SetActive(false);
            panel5.SetActive(false);
        }
        if (currentorder == 4)
        {
            panel1.SetActive(false);
            panel2.SetActive(false);
            panel3.SetActive(false);
            panel4.SetActive(true);
            panel5.SetActive(false);
        }
        if (currentorder == 5)
        {
            panel1.SetActive(false);
            panel2.SetActive(false);
            panel3.SetActive(false);
            panel4.SetActive(false);
            panel5.SetActive(true);
        }
    }

    public void Prev()
    {
        if (currentorder >= lowerorder)
        {
            currentorder -= 1;
        }
    }

    public void Next()
    {
        if (currentorder < toporder)
        {
            currentorder += 1;
        }
    }

    public void Skip()
    {
        how2play.SetActive(false);
    }
}
