using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    public agentScript agent;
    private void Awake()
    {
        Transform checkpointsgoodTransform = transform.Find("Good");
        Transform checkpointswrongTransform = transform.Find("Wrong");
        foreach (Transform checkgoodTransform in checkpointsgoodTransform)
        {
            checkgood checkpoint1 = checkgoodTransform.GetComponent<checkgood>();
            checkpoint1.SetTrackCheckpoints(this);
        }

        foreach (Transform checkwrongTransform in checkpointswrongTransform)
        {
            checkwrong checkpoint2 = checkwrongTransform.GetComponent<checkwrong>();
            checkpoint2.SetTrackCheckpoints(this);
        }

    }

    public void PlayerThroughCheckpoint(checkgood checkSingle)
    {
        Debug.Log(checkSingle.transform.name);
        //agent.Positive_reward();
    }

    public void PlayerThroughCheckpoint(checkwrong checkSingle)
    {
        Debug.Log(checkSingle.transform.name);
        //agent.Negative_reward();
        //agent.ResetCar();
    }
}