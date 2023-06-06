using System.Collections.Generic;
using CatCity.DialogueElements;
using UnityEngine.Events;

namespace UnityEngine.EventSystems
{
    [AddComponentMenu("Event/Dialogue Events")]
    public class DialogueEvents : MonoBehaviour
    {
        /// <summary>
        /// current events list to use in aplication
        /// </summary>
        public List<DialogueEvent> EventsLists { private get; set; }

        public DialogueEvent[] events;

        void Start()
        {
            if(EventsLists != null)
            {
                return;
            }

            Debug.Log("a");

            EventsLists = new List<DialogueEvent>();

            for(int i = 0; i < events.Length; i++)
            {
                EventsLists.Add(events[i]);
            }

            Debug.Log("b");

        }

        /// <summary>
        /// Call the event in event list
        /// </summary>
        /// <param name="eventId">index of event in events list</param>
        public void CallEvent(int eventId)
        {
            if(eventId > EventsLists.Count || eventId < 0)
            {
                return;
            }

            EventsLists[eventId].@event.Invoke();
        }

        /// <summary>
        /// Call the event in event list
        /// </summary>
        /// <param name="name">name og event in events list</param>
        public void CallEvent(string name)
        {
            int eventId = -1;

            for(int i = 0; i < EventsLists.Count && eventId == -1; i++)
            {
                if(EventsLists[i].eventName == name)
                {
                    eventId = i;
                }
            }

            if(eventId != -1)
            {
                EventsLists[eventId].@event.Invoke();
            }
        }
    }
}