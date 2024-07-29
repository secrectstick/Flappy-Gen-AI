using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Metadata;
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

        


        public Texture2D pipeTexture;
        public SpriteFont arial;

        public List<Pipe> pipes;
        public Queue<Pipe> queue;


        private int count;
        private int testscr;

        // loadcontent


        // genetic stuff

        //peope tracking
        int popCount;
        int genCount;

        // scores
        int curScore;
        int genBestScore;
        int bestScore;

        // formulas

        Formula curFormula;
        Formula genBestFormula;
        Formula bestFormula;

        public void loadContent(ContentManager content)
        {
            pipeTexture = content.Load<Texture2D>("purple");
            

            arial = content.Load<SpriteFont>("arial");
        }

        // default ctor

        public PipeManager()
        {
            
            pipes = new List<Pipe>();
            queue = new Queue<Pipe>();
            
            count = -1;
            rng= new Random();
            testscr = 0;

            genCount = 0;
            genBestScore = 0;
            bestScore = 0;

            curFormula = new Formula(1.0);
            genBestFormula = new Formula(1.0);  
            bestFormula = new Formula(1.0);
        }

        // reset method 
        public void reset(ContentManager content) 
        {
            

            queue.Clear();
            count = 0;
            pipes.Clear();
            testscr = 0;


            // make new pipe instantly
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

        // update (adds new pipes and finds the next pipe(use a queue))
        public void update(Player player,ContentManager content)
        {
            // adds pipe when player first starts
            if (count == -1)
            {
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



            count++;

            

            // it goes super sonic bc i make multiple of the same pipe then they gcall move multiple times on the same pipe


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

            // moves the pipes
            foreach (Pipe pipe in pipes)
            {
                pipe.move();
            }

            
            if(queue.Count > 0)
            {
                Pipe trigPipe = queue.Peek();
                //KeyboardState kb = Keyboard.GetState();

                // player jumping
                if (player.count < 1 && 
                    curFormula.formulate(
                    player.Position.Center.X, player.Position.Center.Y,
                    trigPipe.topPos.X, trigPipe.topPos.Y, 
                    trigPipe.botPos.X, trigPipe.botPos.Y))
                {
                    player.jump();
                }
            }

               

            //Pipe temp = queue.Peek();

            

            // peek the queue if it past the player dequeue
            if (queue.Count > 0)
            {
                Pipe tempPipe = queue.Peek();
                if (tempPipe.topRect.Right < player.Position.Right)// change 0 to player.x
                {
                    queue.Dequeue();
                    testscr++;
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

            // foreach pipe if player rect intersects the player die
            for (int i = 0; i < pipes.Count; i++)
            {
                if (pipes[i].hitPipe(player.Position))
                {
                    player.isAlive = false;
                }
            }

            // kills player if the leave the screen
            if (player.Position.Top < 0 || player.Position.Bottom > 800)
            {
                player.isAlive = false;
            }

            if (!player.isAlive)
            {   
                reset(content);
                player.Position.Y = 150;
                player.count = 0;
                player.isAlive = true;
            }

            // add genetic stuff here


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

            sb.DrawString(arial,$"score: {testscr}", new Vector2 (50,50), Color.White);
        }

    }
}
