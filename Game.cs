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
        private bool _gameOver;
        private Item _gun;
        private Item _bow;
        private Item _bullet;
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

        public Item[] PrintInventory()
        {
            _player.GetInventory();

        }

        public void InializePrices()
        {
            _gun.cost = 50;
            _gun.name = "Gun";
            _bow.cost = 25;
            _bow.name = "bow";
            _bullet.cost = 10;
            _bullet.name = "Bullet";
        }

        public void OpenShopMenu()
        {
            char input = ' ';
            input = Console.ReadKey().KeyChar;
            GetInput(out input, _gun.name, _bow.name, _bullet.name, "what're ya buying?");
            if(input == '1')
            {
                _player.Buy(_gun, 0);
                _shop.Sell(_player, 0, 0);
            }
            else if(input == '2')
            {
                _player.Buy(_bow, 1);
                _shop.Sell(_player, 1, 1);
            }
            else if(input == '3')
            {
                _player.Buy(_bullet, 2);
                _shop.Sell(_player, 2, 2);
            }
            
        }
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
                        
                        player.KeepItem(0);
                        break;
                    }
                case '2':
                    {
                        player.KeepItem(1);
                        break;
                    }
                case '3':
                    {
                        player.KeepItem(2);
                        break;
                    }

            }
        }
        public void AddPurchase(Shop item, Player player)
        {
            player.InitalizePlayer();
        }

        //Performed once when the game begins
        public void Start()
        {
            _player.InitalizePlayer();
            InializePrices();
        }

        //Repeated until the game ends
        public void Update()
        {
            SendToInventory(_player);
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
