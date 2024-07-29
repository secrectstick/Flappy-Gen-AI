using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public double Theta
        {
            get { return theta; }
        }


        public Formula(double theta)
        {
            this.theta = theta;
        }


        private double dist(double x1, double y1, double x2, double y2)
        {
            double xdiff = x1-x2;
            double ydiff = y1-y2;
            xdiff = xdiff * xdiff;
            ydiff = ydiff * ydiff;

            return Math.Sqrt(xdiff+ydiff);
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
            double a = dist(bX, bY, tX, tY);
            double b = dist(pX, pY, bX, bY);
            double c = dist(pX, pY, tX, tY);

            double ratio = BTheta(a,b,c) / CTheta(a,b,c);

            if(ratio< theta)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public double BTheta(double a, double b, double c)
        {
            
            return 0.0;
        }


        public double CTheta(double a, double b, double c)
        {
            return 0.0;
        }

    }
}
