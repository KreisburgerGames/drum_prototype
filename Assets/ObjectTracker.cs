using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenCVForUnity.CoreModule;
using OpenCVForUnity.ImgprocModule;
using OpenCVForUnity.UnityUtils;
using UnityEngine;

public class ObjectTracker : MonoBehaviour
{
    OVRAnchor.Tracker _tracker;

    async void Start()
    {
        // Create a tracker
        _tracker = new OVRAnchor.Tracker();

        // Configure it to detect keyboards
        var result = await _tracker.ConfigureAsync(new OVRAnchor.TrackerConfiguration
        {
            
        });

        if (result.Success)
        {
            UpdateTrackables();
        }
    }

    List<OVRAnchor> _anchors = new();

    async void UpdateTrackables()
    {
        while (enabled)
        {
            var result = await _tracker.FetchTrackablesAsync(_anchors);
            if (result.Success)
            {
                foreach (var anchor in _anchors)
                {
                    Debug.Log($"Anchor {anchor} a trackable of type {anchor.GetTrackableType()}");
                }
            }

            // Wait one second, then query again
            await Task.Delay(1000);
        }
    }
}
