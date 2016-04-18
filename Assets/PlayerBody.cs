﻿using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class PlayerBody : MonoBehaviour {

    public GameObject playerRoot;

    MethodInfo FindMethod(Type type, Type returnType, string name, params Type[] parameterTypes)
    {
        MethodInfo methodInfo = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (methodInfo != null)
        {
            if (methodInfo.ReturnType != returnType)
            {
                methodInfo = null;
            }
            else
            {
                ParameterInfo[] paramInfo = methodInfo.GetParameters();
                if (parameterTypes.Length != paramInfo.Length)
                {
                    methodInfo = null;
                }
                else
                {
                    for (int i = 0; i < paramInfo.Length; i++)
                    {
                        if (paramInfo[i].ParameterType != parameterTypes[i])
                        {
                            methodInfo = null;
                            break;
                        }
                    }
                }
            }
        }

        return methodInfo;
    }

    bool InvokeMethod(System.Object target, MethodInfo methodInfo, params System.Object[] values)
    {
        System.Object retVal = methodInfo.Invoke(target, values);
        return (retVal is bool) ? (bool)retVal : false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = playerRoot.GetComponent<Player>();
        bool continueProcessing = true;

        Component[] components = gameObject.GetComponents<Component>();
        foreach (Component component in components)
        {
            if (component.GetInstanceID() == player.GetInstanceID())
                continue;

            MethodInfo methodInfo = FindMethod(component.GetType(), typeof(bool), "OnObstacleEnter", typeof(Collider2D));
            if (methodInfo != null)
            {
                continueProcessing = InvokeMethod(component, methodInfo, collider);
                if (!continueProcessing)
                    break;
            }
        }

        if (continueProcessing)
        {
            MethodInfo methodInfo = FindMethod(player.GetType(), typeof(bool), "OnObstacleEnter", typeof(Collider2D));
            if (methodInfo != null)
                InvokeMethod(player, methodInfo, collider);
        }
            
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerRoot.GetComponent<Player>().dk.RollingOnGround(Time.deltaTime);
        }
    }
}
