using System.Collections;

namespace RedTeam.PewPew {

    public class TestEngine : Engine {

        CourseSegment _startingSegment;

        public TestEngine(TestEngineData data) : base(data) {
            _startingSegment = data.startingSegment;
        }

        public override void InitGame() {

            base.InitGame();

            EventManager.AddBroadcastListener("StopGame", StopGame);
            EventManager.AddRequest<CourseSegment>("StartingSegment", () => _startingSegment);
        }

        public override IEnumerator StopEngine() {

            EventManager.RemoveBroadcastListener("StopGame", StopGame);
            EventManager.RemoveRequest<CourseSegment>("StartingSegment");

            yield return null;
        }
    }
}