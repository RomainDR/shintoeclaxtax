using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funtaine : MonoBehaviour
{
    [SerializeField] Transform iceBlock = null;

    public void Enable()
    {
        Instantiate(iceBlock, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
