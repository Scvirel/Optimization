﻿using Sentry;
using UnityEngine;

public sealed class SentryPerformanceTraceInit : MonoBehaviour
{
    [SerializeField] private float TracesSampleRate = 1.0f;

    private void Start()
    {
        SentryOptions options = new SentryOptions();
        options.TracesSampleRate = 1.0;

        // Transaction can be started by providing, at minimum, the name and the operation
        var transaction = SentrySdk.StartTransaction(
              "test-transaction-name",
              "test-transaction-operation"
            );

        // Transactions can have child spans (and those spans can have child spans as well)
        var span = transaction.StartChild("test-child-operation");

        // ...
        // (Perform the operation represented by the span/transaction)
        // ...

        span.Finish(); // Mark the span as finished
        transaction.Finish();
    }
}
