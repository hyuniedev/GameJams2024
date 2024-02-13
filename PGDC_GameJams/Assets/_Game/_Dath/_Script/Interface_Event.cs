using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEvent
{
    void HasEvent(float time);

}

public interface IEventHappen
{
    void EventHappen(bool isHappen);
}