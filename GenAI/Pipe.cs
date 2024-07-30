using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GenAI
{
    internal class Pipe
    {
        //rect for top pipe
        public Rectangle topRect;
        // rect for bot
        public Rectangle botRect;

        public Texture2D pipeTexture;


        //properties to get the vector2 for the top of the bot and the bot of the top

        public Vector2 topPos
        {
            get
            {
                return new Vector2(topRect.Center.X, topRect.Bottom);
            }
        }

        public Vector2 botPos
        {
            get
            {
                return new Vector2(botRect.Center.X, botRect.Top);
            }
        }


        public Pipe()
        {
            
        }


        public void loadContent(ContentManager content)
        {
            pipeTexture = content.Load<Texture2D>("purple");
        }

        // ctor that takes in two rects for top and bot

        public Pipe(Rectangle topRect,Rectangle botRect,Texture2D pipeTexture)
        {
            this.topRect = topRect;
            this.botRect = botRect;
            //this.pipeTexture = pipeTexture;
        }

        // methd that checks if a rect hits either of the pipes

        public bool hitPipe(Rectangle player)
        {
            return player.Intersects(botRect) || player.Intersects(topRect);    
        }


        // make a move func

        public void move()
        {
            
            topRect.X -= 3 ;
            botRect.X -= 3 ; 
        }

        // draw pipe
        public void drawPipe(SpriteBatch sb,Color color)
        {
            sb.Draw(pipeTexture, topRect, color);
            sb.Draw(pipeTexture, botRect, color);
        }

    }
}
