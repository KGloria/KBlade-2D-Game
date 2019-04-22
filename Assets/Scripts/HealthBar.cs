using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform hbar;
    // Start is called before the first frame update
    private void Start()
    {
        hbar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized)
    {
        hbar.localScale = new Vector3(sizeNormalized, 1f);
    }

}
