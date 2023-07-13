using Sentry;
using UnityEngine;
using static UnityEditor.Progress;

public class SentryTestEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SentrySdk.CaptureMessage("Test event");
    }
}
