using UnityEngine;

//Attach to empty GameObject.

public class EnvelopModel
{
    //Model Objects
    public Venue decoder;

    public EnvelopModel()
    {
        //Octagon, Midway
        decoder = new Octagon();
    }
}
