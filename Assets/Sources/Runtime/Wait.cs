using System;
using System.Collections;
using UnityEngine;

namespace Optimization.Client.Runtime
{
    public sealed class Wait
    {
        public static IEnumerator Until(Func<bool> condition, float timeout = 30f)
        {
            float timePassed = 0f;

            while (!condition() && timePassed < timeout)
            {
                yield return new WaitForEndOfFrame();
                timePassed += Time.deltaTime;
            }
            if (timePassed >= timeout)
            {
                throw new TimeoutException("Condition was not fulfilled for " + timeout + " seconds.");
            }
        }
    }
}
