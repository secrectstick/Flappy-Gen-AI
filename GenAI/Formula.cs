using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GenAI
{
    internal class Formula
    {
        private double theta;

        public Formula(double theta)
        {
            this.theta = theta;
        }


        private double dist(double x1, double y1, double x2, double y2)
        {
            return 0.0;
        }

        /// <summary>
        /// determines if the player should jump
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="tX"></param>
        /// <param name="tY"></param>
        /// <param name="bX"></param>
        /// <param name="bY"></param>
        /// <returns>if true then jump</returns>
        public bool formulate(double pX, double pY, 
            double tX, double tY,double bX,double bY)
        {
            return true;
        }
    }
}
