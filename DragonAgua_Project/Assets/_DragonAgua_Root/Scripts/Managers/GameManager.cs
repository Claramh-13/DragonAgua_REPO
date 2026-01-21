using Unity.Hierarchy;
using UnityEngine;
 public class GameManager : MonoBehaviour
 {
        
        //Declaración del Singleton
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null) 
                Debug.Log("No hay GameManager!");
                return instance;
            }

        }
        //Fin del Singletone

        //Variables del jugador
        public float playerHealth;
        public float maxHealth = 100;
        public int playerPoints;

        //Sistema de Monedas y Dash
        public int coins = 0;
        public int coinsNeededForDash = 4;
        public bool dashUnlocked = false;

        private void Awake()
        {
            if ( instance == null)
            {
               instance = this;
               DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
               Destroy(gameObject);
            }

        }

        private void Update()
        {
           if (playerHealth < 0) playerHealth = 0;
        }

       
      
        public void AddCoin()
        {
           coins++;

           Debug.Log("Coins");

           if(coins >= coinsNeededForDash && !dashUnlocked)
           {
            dashUnlocked = true;

            PlayerController.Instance.UnlockDash();
            Debug.Log("Dash desbloqueado!");


           }

       

        }
    




 }