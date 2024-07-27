using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GenAI
{
    internal class PipeManager
    {

        Random rng;

        // six default pipes
        public Pipe p1;
        public Pipe p2;
        public Pipe p3;
        public Pipe p4;
        public Pipe p5;
        public Pipe p6;


        public Texture2D pipeTexture;


        public List<Pipe> pipes;
        public Queue<Pipe> queue;


        private int count;

        // loadcontent

        public void loadContent(ContentManager content)
        {
            pipeTexture = content.Load<Texture2D>("purple");
        }

        // default ctor

        public PipeManager()
        {
            p1 = new Pipe();
            p2 = new Pipe();
            p3 = new Pipe();
            p4 = new Pipe();
            p5 = new Pipe();
            p6 = new Pipe();
            pipes = new List<Pipe>();
            queue = new Queue<Pipe>();
            count = 0;
            rng= new Random();
        }

        // reset method 
        public void reset() 
        {

        }

        // update (adds new pipes and finds the next pipe(use a queue))
        public void update(Player player)
        {
            count++;


            //creating new pipes
            if (count > 100)
            {
                count = 0;
                int temp = rng.Next(0, 6);
                Pipe newPipe = new Pipe();
                switch (temp)
                {
                    case 0:
                        newPipe = p1;
                        break;
                    case 1:
                        newPipe = p2;
                        break;
                    case 2:
                        newPipe = p3;
                        break;
                    case 3:
                        newPipe = p4;
                        break;
                    case 4:
                        newPipe = p5;
                        break;
                    case 5:
                        newPipe = p6;
                        break;
                }
                // add a new pipe to pipes. then add to queue as well(randomly)
                pipes.Add(newPipe);
                queue.Enqueue(newPipe);
            }

            // foreach pipe in pipes x-=3
            foreach (Pipe pipe in pipes)
            {
                pipe.topRect.X-=3;
                pipe.botRect.X-=3;
            }

            //Pipe temp = queue.Peek();

            // foreach pipe if player rect intersects the player die

            // peek the queue if it past the player dequeue
            Pipe tempPipe = queue.Peek();
            if(tempPipe.topRect.Right < 0)// change 0 to player.x
            {
                queue.Dequeue();
            }

        }

        // draw all pipes but next pipe as a diff color

        // peek queue to get which pipe to draw red

        public void draw(SpriteBatch sb)
        {
            foreach (Pipe pipe in pipes)
            {
                pipe.drawPipe(sb, Color.White);
            }

            Pipe temp = queue.Peek();

            temp.drawPipe(sb, Color.Red);

        }

    }
}
