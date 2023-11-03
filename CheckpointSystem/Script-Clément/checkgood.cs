using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkgood : MonoBehaviour
{
    private TrackCheckpoints trackCheckpoints;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("good");
        trackCheckpoints.PlayerThroughCheckpoint(this);
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
}