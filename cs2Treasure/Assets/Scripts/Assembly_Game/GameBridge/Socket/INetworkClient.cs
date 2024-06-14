using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INetworkClient
{
    void Init(string ip, int port);
    void Close();
    bool IsConnected { get; }
}
