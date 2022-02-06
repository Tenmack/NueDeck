using NueDeck.Scripts.Card;
using NueDeck.Scripts.Collection;
using NueDeck.Scripts.Data.Collection;
using NueDeck.Scripts.Data.Containers;
using NueDeck.Scripts.Data.Settings;
using NueDeck.Scripts.EnemyBehaviour;
using NueExtentions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NueDeck.Scripts.Managers
{
    [DefaultExecutionOrder(-5)]
    public class GameManager : MonoBehaviour
    { 
        public GameManager(){}
        public static GameManager Instance { get; private set; }
        
        [Header("Settings")] 
        [SerializeField] private Camera mainCam;
        [SerializeField] private GameplayData gameplayData;
        [SerializeField] private EncounterData encounterData;
        [SerializeField] private SceneData sceneData;

        public SceneData SceneData => sceneData;
        public EncounterData EncounterData => encounterData;
        public GameplayData GameplayData => gameplayData;
        public PersistentGameplayData PersistentGameplayData { get; private set; }
        public Camera MainCam => mainCam;
        
        #region Setup
        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
               
            }
            else
            {
                transform.parent = null;
                Instance = this;
                DontDestroyOnLoad(gameObject);
                CardActionProcessor.Initialize();
                EnemyActionProcessor.Initialize();
                InitGameplayData();
                SetInitalHand();
            }
        }
        #endregion
        
        #region Public Methods
        public void InitGameplayData() => PersistentGameplayData = new PersistentGameplayData(gameplayData);
        public CardObject BuildAndGetCard(CardData targetData, Transform parent)
        {
            var clone = Instantiate(GameplayData.cardPrefab, parent);
            clone.SetCard(targetData);
            return clone;
        }
        public void SetInitalHand()
        {
            PersistentGameplayData.CurrentCardsList.Clear();
            
            if (PersistentGameplayData.IsRandomHand)
                for (var i = 0; i < GameplayData.randomCardCount; i++)
                    PersistentGameplayData.CurrentCardsList.Add(GameplayData.allCardsList.RandomItem());
            else
                foreach (var cardData in GameplayData.initalDeck.CardList)
                    PersistentGameplayData.CurrentCardsList.Add(cardData);
        }
        public void NextEncounter()
        {
            PersistentGameplayData.CurrentEncounterId++;
            if (PersistentGameplayData.CurrentEncounterId>=EncounterData.enemyEncounterList[PersistentGameplayData.CurrentStageId].enemyEncounterList.Count)
            {
                PersistentGameplayData.CurrentEncounterId = Random.Range(0,
                    EncounterData.enemyEncounterList[PersistentGameplayData.CurrentStageId].enemyEncounterList.Count);
            }
        }
        public void OnExitApp()
        {
            
        }
        #endregion
      

    }
}
