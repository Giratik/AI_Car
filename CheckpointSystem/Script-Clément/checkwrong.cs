using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkwrong : MonoBehaviour
{
    private TrackCheckpoints trackCheckpoints;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("wrong");
        trackCheckpoints.PlayerThroughCheckpoint(this);
    }

    /*private void OnTriggerStay(Collider other)
    {
        Debug.Log("stay wrong");
        trackCheckpoints.PlayerThroughCheckpoint(this);
    }
    */
    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
}