using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenControl : MonoBehaviour
{
    private AbsoluteUnit leader;
    private Vector3 startingPos;
    private bool following;
    // Start is called before the first frame update
    void Start()
    {
        following = false;
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (following)
            transform.position = leader.transform.position;
    }

    public void Attach(AbsoluteUnit newDad)
    {
        leader = newDad;
        transform.position = leader.transform.position;
        following = true;
    }

    public void Detach()
    {
        following = false;
        transform.position = startingPos;
    }
}
