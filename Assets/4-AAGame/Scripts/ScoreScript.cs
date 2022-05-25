using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int PinCount = 0;
    [SerializeField] Text _scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        PinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = PinCount.ToString();
    }
}
