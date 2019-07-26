using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    /*
     * To-DO:
     * If there are only a few blocks left,
     * activate color changing
     * else,
     * deactivate
     * apply this script to all blocks
     */

    private Color lerpedColor;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        lerpedColor = Color.black;
    }

    void Update()
    {
        lerpedColor = Color.Lerp(Color.black, Color.cyan, Mathf.PingPong(Time.time, 1));
        rend.material.color = lerpedColor;
    }
}
