using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam {

    public partial class EngineFactory {

        IEngine generatedEngine;

        public IEngine GenerateEngine(EngineData data) {

            GenerateEngineFor(data);

            // generatedEngine must be set in the project-specific portion of this class
            return generatedEngine;
        }

        partial void GenerateEngineFor(EngineData data);
    }
}