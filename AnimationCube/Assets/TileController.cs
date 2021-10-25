using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public Transform endPoint;
    public float speed;
    public float resetPosition;
   // [Space]

    private void MoveTile()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

        if (transform.position.z>=resetPosition)
        {
            GamePlayManager.instance.ChangeParent();
        }
    }

}
