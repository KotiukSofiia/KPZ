using System;
using System.Collections.Generic;

namespace LightHTML
{
    public abstract class LightNode
    {
        public List<EventListener> EventListeners { get; set; } = new List<EventListener>();

        public abstract string GetOuterHtml(int indentLevel = 0);
        public abstract string GetInnerHtml(int indentLevel = 0);

        public void AddEventListener(string eventType, Action eventHandler)
        {
            EventListeners.Add(new EventListener(eventType, eventHandler));
        }

        public void TriggerEvent(string eventType)
        {
            foreach (var listener in EventListeners)
            {
                if (listener.EventType == eventType)
                {
                    listener.Handler.Invoke();
                }
            }
        }
    }

    public class EventListener
    {
        public string EventType { get; }
        public Action Handler { get; }

        public EventListener(string eventType, Action handler)
        {
            EventType = eventType;
            Handler = handler;
        }
    }
}
