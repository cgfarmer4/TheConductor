using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Octagon : Venue
{
    //Constants
    private static float METER = 1.0f;
    private static float SPEAKER_CIRCLE_RADIUS = 100f;
    private static float HEIGHT = 10f;

    private static int NUM_INPUTS = 16;
    private static int NUM_CHANNELS = 8;

    public ArrayList COLUMN_POSITIONS;

    ArrayList columns;
    GameObject EnvelopModel;

    // Use this for initialization  
    public Octagon()
    {
        inputs = new GameObject[NUM_INPUTS];
        outputChannels = new GameObject[NUM_CHANNELS];

        cx = 0f;
        cy = 65.1f * .02f;
        cz = 0f;

        xRange = 228.24f * .02f;
        yRange = 141.73f * .02f;
        zRange = 329.972f * .02f;

        COLUMN_POSITIONS = new ArrayList();
        float radiansDegrees = (float)Math.PI / 180;
        //calculate XY  points around the center of a circle to match our decoder angles.
        COLUMN_POSITIONS.Add(new Vector3(SPEAKER_CIRCLE_RADIUS * (float)Math.Cos(30 * radiansDegrees), SPEAKER_CIRCLE_RADIUS * (float)Math.Sin(30 * radiansDegrees), 101));
        COLUMN_POSITIONS.Add(new Vector3(SPEAKER_CIRCLE_RADIUS * (float)Math.Cos(75 * radiansDegrees), SPEAKER_CIRCLE_RADIUS * (float)Math.Sin(75 * radiansDegrees), 102));
        COLUMN_POSITIONS.Add(new Vector3(SPEAKER_CIRCLE_RADIUS * (float)Math.Cos(105 * radiansDegrees), SPEAKER_CIRCLE_RADIUS * (float)Math.Sin(105 * radiansDegrees), 103));
        COLUMN_POSITIONS.Add(new Vector3(SPEAKER_CIRCLE_RADIUS * (float)Math.Cos(150 * radiansDegrees), SPEAKER_CIRCLE_RADIUS * (float)Math.Sin(150 * radiansDegrees), 104));
        COLUMN_POSITIONS.Add(new Vector3(SPEAKER_CIRCLE_RADIUS * (float)Math.Cos(210 * radiansDegrees), SPEAKER_CIRCLE_RADIUS * (float)Math.Sin(210 * radiansDegrees), 105));
        COLUMN_POSITIONS.Add(new Vector3(SPEAKER_CIRCLE_RADIUS * (float)Math.Cos(255 * radiansDegrees), SPEAKER_CIRCLE_RADIUS * (float)Math.Sin(255 * radiansDegrees), 106));
        COLUMN_POSITIONS.Add(new Vector3(SPEAKER_CIRCLE_RADIUS * (float)Math.Cos(285 * radiansDegrees), SPEAKER_CIRCLE_RADIUS * (float)Math.Sin(285 * radiansDegrees), 107));
        COLUMN_POSITIONS.Add(new Vector3(SPEAKER_CIRCLE_RADIUS * (float)Math.Cos(330 * radiansDegrees), SPEAKER_CIRCLE_RADIUS * (float)Math.Sin(330 * radiansDegrees), 108));

        GenerateModel();
    }

    public void GenerateModel()
    {
        EnvelopModel = new GameObject("HomeOctagon");
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
            sphere.transform.localScale += new Vector3(10f, 10f, 10f);
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
            cylinder.transform.localScale += new Vector3(1f, HEIGHT / 2, 1f);
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
            channelBox2.transform.localScale = new Vector3(21, 16, 15);
            channelBox2.transform.position = new Vector3(column.transform.position.x, 40, column.transform.position.z);
            channelBox2.transform.LookAt(new Vector3(0, cy / 2, 0));
            channelBox2.name = "Speaker" + speakerNum;
            channelBox2.tag = "Speaker";
            outputChannels[speakerNum] = channelBox2;
            speakerNum++;
        }
    }
}
