﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Octagon : Venue
{
    //Constants
    private static float INCHES = 1.0f;
    private static float FEET = 12.0f * INCHES;
    private static float WIDTH = 20.0f * FEET + 10.25f * INCHES;
    private static float DEPTH = 41.0f * FEET + 6.0f * INCHES;
    private static float SPEAKER_ANGLE = 22.0f;
    private static float RADIUS = 20.0f * INCHES;
    private static float HEIGHT = 12.0f * FEET;

    private static int NUM_INPUTS = 16;
    private static int NUM_CHANNELS = 8;

    private static float INNER_OFFSET_X = WIDTH / 2.0f - 1.0f * FEET - 8.75f * INCHES;
    private static float OUTER_OFFSET_X = WIDTH / 2.0f - 5.0f * FEET - 1.75f * INCHES;
    private static float INNER_OFFSET_Z = -DEPTH / 2.0f + 15.0f * FEET + 10.75f * INCHES;
    private static float OUTER_OFFSET_Z = -DEPTH / 2.0f + 7.0f * FEET + 8.0f * INCHES;

    private static float SUB_OFFSET_X = 36.0f * INCHES;
    private static float SUB_OFFSET_Z = 20.0f * INCHES;

    public ArrayList COLUMN_POSITIONS;
    public ArrayList SUB_POSITIONS;

    public static float xRange = 228.24f * .02f;
    public static float yRange = 141.73f * .02f;
    public static float zRange = 329.972f * .02f;
    public static float cx = 0f;
    public static float cy = 70.1f * .02f;
    public static float cz = 0f;

    ArrayList columns;
    GameObject EnvelopModel;

    public new GameObject[] inputs = new GameObject[NUM_INPUTS];
    public new GameObject[] outputChannels = new GameObject[NUM_CHANNELS];

    // Use this for initialization  
    public Octagon()
    {
        COLUMN_POSITIONS = new ArrayList();
        COLUMN_POSITIONS.Add(new Vector3(-OUTER_OFFSET_X, -OUTER_OFFSET_Z, 101));
        COLUMN_POSITIONS.Add(new Vector3(-INNER_OFFSET_X, -INNER_OFFSET_Z, 102));
        COLUMN_POSITIONS.Add(new Vector3(-INNER_OFFSET_X, INNER_OFFSET_Z, 103));
        COLUMN_POSITIONS.Add(new Vector3(-OUTER_OFFSET_X, OUTER_OFFSET_Z, 104));
        COLUMN_POSITIONS.Add(new Vector3(OUTER_OFFSET_X, OUTER_OFFSET_Z, 105));
        COLUMN_POSITIONS.Add(new Vector3(INNER_OFFSET_X, INNER_OFFSET_Z, 106));
        COLUMN_POSITIONS.Add(new Vector3(INNER_OFFSET_X, -INNER_OFFSET_Z, 107));
        COLUMN_POSITIONS.Add(new Vector3(OUTER_OFFSET_X, -OUTER_OFFSET_Z, 108));

        SUB_POSITIONS = new ArrayList();
        SUB_POSITIONS.Add((Vector3)COLUMN_POSITIONS[0] + new Vector3(-SUB_OFFSET_X, -SUB_OFFSET_Z, 0));
        SUB_POSITIONS.Add((Vector3)COLUMN_POSITIONS[3] + new Vector3(-SUB_OFFSET_X, SUB_OFFSET_Z, 0));
        SUB_POSITIONS.Add((Vector3)COLUMN_POSITIONS[4] + new Vector3(SUB_OFFSET_X, SUB_OFFSET_Z, 0));
        SUB_POSITIONS.Add((Vector3)COLUMN_POSITIONS[7] + new Vector3(SUB_OFFSET_X, -SUB_OFFSET_Z, 0));

        GenerateModel();
    }

    public void GenerateModel()
    {
        EnvelopModel = new GameObject("EnvelopMidway");
        ColumnModels();
        ChannelModels();
        InputModels();
        EnvelopModel.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
    }

    void InputModels()
    {
        for (int x = 0; x < NUM_INPUTS; x++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale += new Vector3(RADIUS, RADIUS, RADIUS);
            sphere.transform.parent = EnvelopModel.transform;
            sphere.name = "Input" + x;
            sphere.tag = "EnvelopAudioInput";
            inputs[x] = sphere;
        }
    }

    void ColumnModels()
    {
        int numColumns = 0;
        columns = new ArrayList();
        foreach (Vector3 position in COLUMN_POSITIONS)
        {
            GameObject cylinder;
            cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylinder.transform.localScale += new Vector3(RADIUS, HEIGHT / 2, RADIUS);
            cylinder.transform.position = new Vector3(position.x, HEIGHT / 2, position.y);

            float theta = (float)Math.Atan2(cylinder.transform.position.x, cylinder.transform.position.y) - (float)Math.PI / 2;
            cylinder.transform.Rotate(0, theta * (180 / (float)Math.PI), 0, Space.Self);
            cylinder.transform.parent = EnvelopModel.transform;
            cylinder.name = "Column" + numColumns;
            cylinder.tag = "Column";
            cylinder.SetActive(false);
            columns.Add(cylinder);
            numColumns++;
        }
    }

    void ChannelModels()
    {
        int speakerNum = 0;

        foreach (GameObject column in columns)
        {
            GameObject channelBox2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            channelBox2.transform.parent = EnvelopModel.transform;
            channelBox2.transform.localScale = new Vector3(21 * INCHES, 16 * INCHES, 15 * INCHES);
            channelBox2.transform.position = new Vector3(column.transform.position.x, 6 * FEET, column.transform.position.z);
            channelBox2.transform.LookAt(new Vector3(0, HEIGHT / 2, 0));
            channelBox2.name = "Speaker" + speakerNum;
            channelBox2.tag = "Speaker";
            outputChannels[speakerNum] = channelBox2;
            speakerNum++;
        }
    }
}
