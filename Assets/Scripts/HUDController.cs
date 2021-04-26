using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDController : MonoBehaviour
{
    public Text score;

    public void SetScore(string _score)
    {
        score.text = _score;
    }
}
