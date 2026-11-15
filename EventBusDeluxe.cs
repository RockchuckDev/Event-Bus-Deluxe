using System;
using System.Collections.Generic;

namespace EventBusDeluxe
{
    /// <summary> A "fire and forget" based event bus system that allows different parts of your C# projects to communicate in a fully decoupled way.
    /// Event types are structs that contain relevant information for the event that just ocurred. They typically end with "Event," but this is not necessary
    /// See Samples.cs for examples of how this system works
    ///  </summary>
    public static class EventBusDeluxe
    {
        private static readonly Dictionary<Type, List<Delegate>> subscriberDict = new Dictionary<Type, List<Delegate>>();

        /// <summary> Subscribes an action to the event bus for a given event type
        /// </summary>
        public static void Subscribe<TEvent>(Action<TEvent> action)
        {
            Type eventType = typeof(TEvent);
            if (!subscriberDict.ContainsKey(eventType))
            {
                subscriberDict[eventType] = new List<Delegate>();
            }
            subscriberDict[eventType].Add(action);
        }
        /// <summary> Unsubscribes an action from the event bus for a given event type </summary>
        public static void Unsubscribe<TEvent>(Action<TEvent> action)
        {
            Type eventType = typeof(TEvent);
            if (subscriberDict.ContainsKey(eventType))
            {
                subscriberDict[eventType].Remove(action);
            }
        }

        /// <summary> Fires an event of a given type, invoking all subscribed actions with the provided event data </summary>
        public static void Fire<TEvent>(TEvent eventData)
        {
            Type eventType = typeof(TEvent);
            if (subscriberDict.ContainsKey(eventType))
            {
                foreach (var action in subscriberDict[eventType])
                {
                    (action as Action<TEvent>)?.Invoke(eventData);
                }
            }
        }
    }
}
