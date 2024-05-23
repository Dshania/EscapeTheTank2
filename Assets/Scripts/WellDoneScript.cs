using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WellDoneScript : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI FinaltimeText;

    private void Update()
    {
        FinaltimeText.text = timeText.text;
       
    }
}
