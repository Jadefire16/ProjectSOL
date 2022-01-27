using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILateUpdate: IStateUpdate
{
    void LateUpdate();
}
