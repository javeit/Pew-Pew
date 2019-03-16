using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTeam.PewPew;

namespace RedTeam {

    public partial class EngineFactory {

        partial void GenerateEngineFor(EngineData data) {

            if (data is GameEngineData)
                generatedEngine = new GameEngine(data as GameEngineData);
            else if (data is MainMenuEngineData)
                generatedEngine = new MainMenuEngine(data as MainMenuEngineData);
            else
                generatedEngine = null;
        }
    }
}