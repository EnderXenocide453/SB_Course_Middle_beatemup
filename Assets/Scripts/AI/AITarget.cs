using System;
using DataProviding;
using UnityEngine;

namespace AI
{
    //Заглушка, чтобы не заморачиваться над определением ближайшей цели и т.д.
    public class AITarget : MonoBehaviour
    {
        private void Awake()
        {
            DataProvider.GetData<AIGlobalData>().Target = this;
        }
    }
}