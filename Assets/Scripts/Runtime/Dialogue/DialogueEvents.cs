using System;
using System.Runtime.CompilerServices;
using CatCity.DialogueElements;
using System.Collections.Generic;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.EventSystems
{
    [AddComponentMenu("Event/Dialogue Events")]
    public class DialogueEvents : UIBehaviour
    {
        public List<DialogueEvent> events;

        public void CallEvent(int eventId)
        {
            if(eventId > events.Count || eventId < 0)
            {
                return;
            }
            
            events[eventId].@event.Invoke();
        }

        public void CallEvent(string name)
        {
            int eventId = -1;

            for(int i = 0; i < events.Count && eventId == -1; i++)
            {
                if(events[i].eventName == name)
                {
                    eventId = i;
                }
            }

            if(eventId != -1)
            {
                events[eventId].@event.Invoke();
            }
        }
    }
}