using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class MainMenuEngine : Engine {

        MainMenuEngineData _data;

        public MainMenuEngine(MainMenuEngineData data) : base(data) {

            _data = data;
        }
    }
}