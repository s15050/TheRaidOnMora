using UnityEngine;

public class AbsoluteUnit : Unit
{
    public Color LeadingColor;
    public string className;
    public string unitName;
    public GameObject token;

    public override void Initialize()
    {
        base.Initialize();

        transform.position += new Vector3(0, 1, 0);
        //GetComponent<Renderer>().material.color = LeadingColor;
    }

    public override void MarkAsAttacking(Unit other)
    {
        throw new System.NotImplementedException();
    }

    public override void MarkAsDefending(Unit other)
    {
        throw new System.NotImplementedException();
    }

    public override void MarkAsDestroyed()
    {
        throw new System.NotImplementedException();
    }

    public override void MarkAsFinished()
    {
        throw new System.NotImplementedException();
    }

    public override void MarkAsFriendly()
    {
        //GetComponent<Renderer>().material.color = LeadingColor;// + new Color(0.1f, 0.1f, 0.1f);
    }
    public override void MarkAsReachableEnemy()
    {
        //GetComponent<Renderer>().material.color = LeadingColor + Color.red;
    }
    public override void MarkAsSelected()
    {
        UINameText.text = className;
        UIIndivNameText.text = unitName;
        token.GetComponent<TokenControl>().Attach(this);
        //GetComponent<Renderer>().material.color = LeadingColor + Color.green;
    }
    public override void UnMark()
    {
        token.GetComponent<TokenControl>().Detach();
        //GetComponent<Renderer>().material.color = LeadingColor;
    }
}
