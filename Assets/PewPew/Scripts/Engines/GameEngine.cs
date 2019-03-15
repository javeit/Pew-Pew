using System.Collections;

namespace RedTeam.PewPew {

    public class GameEngine : Engine {

        GameEngineData _data;
        CourseSegment _startingSegment;

        public GameEngine(GameEngineData data) : base(data) {
            _data = data;
            _startingSegment = data.startingSegment;
        }

        public override void InitGame() {

            base.InitGame();

            EventManager.AddRequest<CourseSegment>("StartingSegment", () => _startingSegment);
        }

        public override IEnumerator StopEngine() {

            EventManager.RemoveRequest<CourseSegment>("StartingSegment");

            yield return null;
        }
    }
}