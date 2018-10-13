using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MessageData { };
public enum MessageTypes { DAMAGED, HEALTHCHANGED, DIED };
public delegate void MessageDelegate(MessageTypes msgType, GameObject go, MessageData msgData);


public class MessageHandler : MonoBehaviour {

    public List<MessageTypes> messages;

    List<MessageDelegate> m_messageDelegates = new List<MessageDelegate>();

    public void RegisterDelegate(MessageDelegate msgDele)
    {
        m_messageDelegates.Add(msgDele);

    }

    public bool GiveMessage(MessageTypes msgType, GameObject go, MessageData msgData)
    {
        bool approved = false;

        for(int i = 0; i < messages.Count; i++)
        {
            if (messages[i] == msgType)
            {
                approved = true;
                break;
                
            }
        }

        if (!approved)
        {
            return false;
        }


        for (int i = 0; i < m_messageDelegates.Count; i++)
        {
            m_messageDelegates[i](msgType, go, msgData);
        }
        return true;
    }
}


public class DeathhData : MessageData
{
    public GameObject attacker;
    public GameObject attaked;

}

public class HealthData : MessageData
{
    public float maxHealth;
    public float curHealth;
}

public class DamageData : MessageData
{
    public float damage;
}