using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTeam.PewPew;

namespace RedTeam {

    public partial class EngineFactory {

        partial void GenerateEngineFor(EngineData data) {

            if (data is GameEngineData)
                generatedEngine = new GameEngine(data as GameEngineData);
            else
                generatedEngine = null;
        }
    }
}