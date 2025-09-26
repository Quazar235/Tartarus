using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherPlatform : MonoBehaviour
{
    public float Crusher_Speed; // Speed of crusher
    public int Crusher_Start_Point; // Starting position of crusher
    public Transform[] Crusher_Points; // Points that crusher moves to and from
    private int Crusher_Index; // Index of crusher array

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Crusher_Points[Crusher_Start_Point].position; // Sets crusher to start at the starting point
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Crusher_Points[Crusher_Index].position) < 0.01f)
        {
            Crusher_Index++;
            if (Crusher_Index == Crusher_Points.Length)
            {
                Crusher_Index = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Crusher_Points[Crusher_Index].position, Crusher_Speed * Time.deltaTime);
    }
}
