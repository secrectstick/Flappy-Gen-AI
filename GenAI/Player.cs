using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GenAI
{
    internal class Player
    {
        // rect
        public Rectangle Position;
        private Texture2D Texture;
        // texture
        // isalive bool
        public bool isAlive;

        //loadContent
        private int count;

        

        // ctor
        public Player(Rectangle Position,Texture2D Texture)
        {
            this.Position = new Rectangle(50,150,50,50);
            this.Texture = Texture;
            isAlive = true;
            count = 0;
        }

        //update (transfer logic from game1 as well as add death detection)

        public void update()
        {
            KeyboardState kbstate = Keyboard.GetState();

            if (count < 1 && kbstate.IsKeyDown(Keys.Space))
            {
                count = 20;
            }


            Position.Y -= count / 2;

            count--;
        }

        // draw

        public void draw(SpriteBatch sb)
        {

            sb.Draw(Texture, Position, Color.White);

            
        }
    }
}
