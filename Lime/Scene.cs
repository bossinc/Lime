using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lime
{
    internal class Scene
    {
        private GameManager _gameManager;
        internal GameManager GameManager
        {
            get
            {
                return this._gameManager;
            }
            set
            {
                this._gameManager = value;
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public Scene(GameManager gameManager, string name)
        {
            this.GameManager = gameManager;
            this.Name = name;
            Console.WriteLine("New Scene: " + name);
        }
    }
}
