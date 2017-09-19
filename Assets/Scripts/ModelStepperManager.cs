﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModelStepperManager : MonoBehaviour
{
    private static ModelStepperManager m_Instance;
    public static ModelStepperManager Instance { get { return m_Instance; } }

    //Get references to all the rows.
    public List<GameObject> rows;
    List<List<GameObject>> columns = new List<List<GameObject>>();

    void Awake()
    {
        m_Instance = this;

        //Parse the row data into the individual columns
        for (int x = 0; x < 16; x++)
        {
            columns.Add(new List<GameObject>());

            for (int y = 0; y < 5; y++)
            {
                columns[x].Add(rows[y].transform.GetChild(x).gameObject);
            }
        }
    }


    void OnDestroy()
    {
        m_Instance = null;
    }

    //Send message to iterate all the objects in each column. Unselect all that should not be active.
    void UpdateColumnModel(List<float> stepperData)
    {
        int columnNumber = (int)stepperData[0] - 1;
        int rowPitch = (int)stepperData[1];

        //Iterate the column game objects turning off all but the active one.
        foreach (GameObject child in columns[columnNumber])
        {
            int childPitch = child.GetComponent<ModelStepper>().rowPitch;
            if (childPitch != rowPitch)
            {
                child.SendMessage("Unselected");
            }
        }
    }
}
