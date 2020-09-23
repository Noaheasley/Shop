using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Item
    {
        public int cost;
        public string name;
        
    }
    class Game
    {
        private Player _player;
        private Shop _shop;
        private bool _gameOver = false;
        private Item _gun;
        private Item _bow;
        private Item _bullet;
        private Item[] _shopInventory;
        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }
            End();
        }

        
        //easy way to get player input
        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            input = ' ';
            //prints out the question
            Console.WriteLine(query);
            //prints out the option
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.WriteLine(">");

            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("invalid input");
                }
            }
        }

       //prints the inventory for the shop
        public void PrintInventory(Item[] inventory)
        {
            for(int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine();
            }
        }

        //initializes the prices for the shop
        public void InializePrices()
        {
            _gun.cost = 50;
            _gun.name = "Gun";
            _bow.cost = 25;
            _bow.name = "bow";
            _bullet.cost = 10;
            _bullet.name = "Bullet";
        }

        //menu for the shop
        public void OpenShopMenu()
        {
            Console.WriteLine("What're ya buying?");
            PrintInventory(_shopInventory);
        }

        //sends spent shop items to the player inventory
        public void SendToInventory(Player player)
        {
            Item[] inventory = player.GetInventory();

            char input = ' ';
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name);
            }
            Console.WriteLine(">");
            input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    {
                        Console.WriteLine("1." + 0);
                        player.KeepItem(0);
                        break;
                    }
                case '2':
                    {
                        Console.WriteLine("2." + 1);
                        player.KeepItem(1);
                        break;
                    }
                case '3':
                    {
                        Console.WriteLine("3." + 2);
                        player.KeepItem(2);
                        break;
                    }

            }
        }


        

        //Performed once when the game begins
        public void Start()
        {
            _player = new Player();
            _player.InitalizePlayer(ref _player);
            _shop = new Shop();
            InializePrices();
        }

        //Repeated until the game ends
        public void Update()
        {
            OpenShopMenu();
            SendToInventory(_player);
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
