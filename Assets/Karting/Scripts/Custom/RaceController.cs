using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class RaceController : MonoBehaviour
{

    public TextMeshProUGUI[] positionsText;

    public static RaceController instance;

    public List<Kart> racers;
    public List<Kart> racersPositions;

    void Awake()
    {
        instance = this;
        SetPositionsText();
        InvokeRepeating("UpdatePositions", 1, 1);
    }

    void UpdatePositions()
    {
        racersPositions = racers.OrderByDescending(racer => racer.totalCheckpoints).ThenBy(racer => racer.lastTime).ToList();
        SetPositionsText();
    }

    void SetPositionsText()
    {
        for (int i = 0; i < positionsText.Length; i++)
        {
            positionsText[i].text = racersPositions[i].racerName;
        }
    }
}
