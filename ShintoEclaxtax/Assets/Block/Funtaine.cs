using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funtaine : MonoBehaviour
{
    [SerializeField] Transform iceBlock = null;

    public void Enable()
    {
        Transform _iceBlock = Instantiate(iceBlock, transform.position, transform.rotation);
        _iceBlock.localScale = transform.lossyScale;
        Destroy(gameObject);
    }
}
