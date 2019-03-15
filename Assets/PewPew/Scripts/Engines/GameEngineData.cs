using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    [CreateAssetMenu(fileName = "GameEngineData", menuName = "RedTeam/PewPew/EngineData/GameEngineData")]
    public class GameEngineData : EngineData {

        public CourseSegment startingSegment;
    }
}
