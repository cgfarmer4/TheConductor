using UnityEngine;
using System.Collections;

public class Divided : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        GameObject collidedWith = collision.gameObject;
        GameObject parent = collidedWith.transform.parent.gameObject;

        Vector3 newPosition = collidedWith.transform.position;
        newPosition.x += 3;
        newPosition.y = 7.16f;

        GameObject newTower = Instantiate(parent, newPosition, parent.transform.rotation);

        foreach (Transform child in newTower.transform)
        {
            if (child.gameObject.tag == "Sub")
            {
                child.gameObject.transform.position = new Vector3(child.gameObject.transform.position.x, 17f, child.gameObject.transform.position.z);
            }
        }

    }
}
