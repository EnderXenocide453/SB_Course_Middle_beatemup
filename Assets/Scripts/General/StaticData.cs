using System.Collections.Generic;
using AI;
using Characteristics;

namespace DataProviding
{
    public class StaticData: IDataContainer
    {
        public Dictionary<EPlayerType, PlayerTemplate> PlayerTemplates;
        public Dictionary<EBehaviourType, float> BaseBehaviourWeights;
    }

    public enum EPlayerType
    {
        Player,
        AI,
    }
}
