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
                if (instance == null) Debug.Log("No hay GameManager!");
                return instance;
            }

        }
        //Fin del Singletone

        //DECLARAMOS CUALQUIER VALOR GENERAL EN PUBLIC
        public float playerHealth;
        public float maxHealth = 100;
        public int playerPoints; 
        

        private void Awake()
        {
            if (instance == null)
            {
                //Sino hay GameManager lo refeenciuamosy hacem os que perdure entre escenas
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                //Si hay GameManager, el duplicado se destruye
                Destroy(gameObject);
            }

        }

        private void Update()
        {
            if (playerHealth > 0) playerHealth = 0;
        }

        public int coins = 4;
        public bool dashUnlocked = false;
      
        public void AddCoin()
        {
           coins++;
        
           if(coins > 4 && !dashUnlocked)
           {
            dashUnlocked = true;
            Debug.Log("Dash desbloaqueado!");
           }

        }
    




 }