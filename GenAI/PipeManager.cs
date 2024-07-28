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
            p1.loadContent(content);
            p2.loadContent(content);
            p3.loadContent(content);
            p4.loadContent(content);
            p5.loadContent(content);
            p6.loadContent(content);
        }

        // default ctor

        public PipeManager()
        {
            p1 = new Pipe(new Rectangle(900, 0, 40, 250), new Rectangle(900, 450, 40, 350),pipeTexture);
            p2 = new Pipe(new Rectangle(900, 0, 40, 400), new Rectangle(900, 600, 40, 200),pipeTexture);
            p3 = new Pipe(new Rectangle(900, 0, 40, 200), new Rectangle(900, 400, 40, 400), pipeTexture);
            p4 = new Pipe(new Rectangle(900, 0, 40, 250), new Rectangle(900, 450, 40, 350), pipeTexture);
            p5 = new Pipe(new Rectangle(900, 0, 40, 400), new Rectangle(900, 600, 40, 200), pipeTexture);
            p6 = new Pipe(new Rectangle(900, 0, 40, 200), new Rectangle(900, 400, 40, 400), pipeTexture);
            pipes = new List<Pipe>();
            

            queue = new Queue<Pipe>();
            count = 0;
            rng= new Random();
        }

        // reset method 
        public void reset() 
        {
            pipes.Add(p1);
            pipes.Add(p2);
            pipes.Add(p3);
            pipes.Add(p4);
            pipes.Add(p5);
            pipes.Add(p6);
            queue.Enqueue(p1);
            queue.Enqueue(p2);
            queue.Enqueue(p3);
            queue.Enqueue(p4);
            queue.Enqueue(p5);
            queue.Enqueue(p6);
        }

        // update (adds new pipes and finds the next pipe(use a queue))
        public void update(Player player,ContentManager content)
        {
            count++;

            //if (count == 1)
            //{
            //    reset();
            //}

            // it goes super sonic bc i make multiple of the same pipe then they gcall move multiple times on the same pipe


            // why does it stop spawning pipes

            // creating new pipes
            if (count == 100)
            {
                count = 0;
                int temp = rng.Next(0, 6);
                Pipe newPipe = new Pipe();
                switch (temp)
                {
                    case 0:
                        newPipe = new Pipe(new Rectangle(900, 0, 40, 250), new Rectangle(900, 450, 40, 350), pipeTexture);

                        break;
                    case 1:
                        newPipe = new Pipe(new Rectangle(900, 0, 40, 400), new Rectangle(900, 600, 40, 200), pipeTexture);

                        break;
                    case 2:
                        newPipe = new Pipe(new Rectangle(900, 0, 40, 200), new Rectangle(900, 400, 40, 400), pipeTexture);

                        break;
                    case 3:
                        newPipe = new Pipe(new Rectangle(900, 0, 40, 250), new Rectangle(900, 450, 40, 350), pipeTexture);

                        break;
                    case 4:
                        newPipe = new Pipe(new Rectangle(900, 0, 40, 400), new Rectangle(900, 600, 40, 200), pipeTexture);

                        break;
                    case 5:
                        newPipe = new Pipe(new Rectangle(900, 0, 40, 200), new Rectangle(900, 400, 40, 400), pipeTexture);

                        break;
                }
                // add a new pipe to pipes. then add to queue as well(randomly)
                newPipe.loadContent(content);
                pipes.Add(newPipe);
                queue.Enqueue(newPipe);
            }

            // foreach pipe in pipes x-=3
            foreach (Pipe pipe in pipes)
            {
                pipe.move();
            }

            //Pipe temp = queue.Peek();

            // foreach pipe if player rect intersects the player die

            // peek the queue if it past the player dequeue
            if (queue.Count > 0)
            {
                Pipe tempPipe = queue.Peek();
                if (tempPipe.topRect.Right < player.Position.Right)// change 0 to player.x
                {
                    queue.Dequeue();
                    // increment score
                }
            }

            // make this a for loop not foreach
            for (int i = 0; i < pipes.Count; i++)
            {
                if (pipes[i].topRect.Right < 0)
                {
                    pipes.RemoveAt(i);
                    i--;
                }
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


            if (queue.Count > 0)
            {
                Pipe temp = queue.Peek();

                temp.drawPipe(sb, Color.Red);
            }
        }

    }
}
