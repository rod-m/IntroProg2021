using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDController : MonoBehaviour
{
    public Text score;
    public Text keys;
    public void SetScore(string _score)
    {
        score.text = _score;
    }

    public void SetKeys(string _keys)
    {
        keys.text = _keys;
    }
}
