using UnityEngine;

public class GameController : MonoBehaviour
{
    enum GameState
    {
       None,
       DecideQueuePosition,
       ShotBall,
       WaitBallStop,
    }

    [SerializeField] private DecideQueuePosition decideQueuePosition;

    [SerializeField]
    QueueDetectBallController queueDetectBallController;

    private GameState currentState = GameState.None;

    void StateChange(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.DecideQueuePosition:
                StartDesiceQueuePosition();
                break;
            case GameState.ShotBall:
                StartShotBall();
                break;
            case GameState.WaitBallStop:
                StartWaitBallStop();
                break;
        }
    }

    void StateUpdate(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.DecideQueuePosition:
                DesiceQueuePositionRoutine();
                break;
            case GameState.ShotBall:
                ShotBallRoutine();
                break;
            case GameState.WaitBallStop:
                WaitBallStopRoutine();
                break;
        }
    }

    void StartDesiceQueuePosition()
    {
        decideQueuePosition.SetActive(true);
    }

    void EndDecideQueuePosition()
    {
        decideQueuePosition.SetActive(false);
        StateChange(GameState.ShotBall);
    }

    void StartShotBall()
    {
        decideQueuePosition.SetActive(false);
        queueDetectBallController.SetActive(true);
    }

    void EndShotBall()
    {
    }

    void StartWaitBallStop()
    {

    }

    void DesiceQueuePositionRoutine()
    {
    }

    void ShotBallRoutine()
    {

    }

    void WaitBallStopRoutine()
    {

    }

    void Awake()
    {
        decideQueuePosition.OnEndDragCallback += EndDecideQueuePosition;
    }

    void Start()
    {
        StateChange(GameState.DecideQueuePosition);
    }

    void LateUpdate()
    {
        StateUpdate(currentState);
    }
}
