using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedTeam.PewPew;

namespace RedTeam {

    public partial class EngineFactory {

        partial void GenerateEngineFor(EngineData data) {

            if (data is TestEngineData)
                generatedEngine = new TestEngine(data as TestEngineData);
            else
                generatedEngine = null;
        }
    }
}