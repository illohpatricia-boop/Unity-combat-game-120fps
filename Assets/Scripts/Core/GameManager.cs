using UnityEngine;

namespace CombatGame.Core
{
    /// <summary>
    /// Central game manager handling game states, initialization, and lifecycle.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private GameState currentGameState = GameState.Menu;
        [SerializeField] private float gameSpeed = 1f;

        public event System.Action<GameState> OnGameStateChanged;

        public enum GameState
        {
            Menu,
            Playing,
            Paused,
            GameOver,
            Loading
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }

        private void Initialize()
        {
            Debug.Log("[GameManager] Initializing game...");
            Time.timeScale = gameSpeed;
        }

        public void SetGameState(GameState newState)
        {
            if (currentGameState == newState) return;

            currentGameState = newState;
            OnGameStateChanged?.Invoke(newState);

            switch (newState)
            {
                case GameState.Playing:
                    Time.timeScale = gameSpeed;
                    break;
                case GameState.GameOver:
                    Time.timeScale = 0f;
                    break;
            }   case Gamestate.settings:
                     Basic:Hipfire
                           :Hold to scope and shoot
        }.           Graphics:Low. Medium. High. Very High. Max.
                     Frame Rate: Low. Medium. High. Very High. Max. ultra.

        public GameState GetCurrentGameState() => currentGameState;

        public void SetGameSpeed(float speed)
        {
            gameSpeed = Mathf.Clamp(speed, 0.1f, 2f);
            if (currentGameState == GameState.Playing)
            {
                Time.timeScale = gameSpeed;
            }
        }

        public void QuitGame()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
