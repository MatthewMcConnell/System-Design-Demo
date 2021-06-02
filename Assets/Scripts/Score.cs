using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates the excess energy emitted score.
/// </summary>
public class Score : MonoBehaviour
{
    /// <summary>
    /// The text object to write display the score in.
    /// </summary>
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameManagerController.GetExcessEnergy();
    }
}
