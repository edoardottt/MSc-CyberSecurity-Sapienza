using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1CS
{
    class Ball
    {
        private int width;
        private int height;
        private int x;
        private int y;
        private int stepx;
        private int stepy;
        

        public Ball(int w, int h, int xVar, int yVar, int stepxVar, int stepyVar)
        {
            width = w;
            height = h;
            x = xVar;
            y = yVar;
            stepx = stepxVar;
            stepy = stepyVar;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public int GetStepX()
        {
            return stepx;
        }

        public int GetStepY()
        {
            return stepy;
        }

        public void SetWidth(int w)
        {
            width = w;
        }

        public void SetHeight(int h)
        {
            height = h;
        }

        public void SetX(int xVar)
        {
            x= xVar;
        }

        public void SetY(int yVar)
        {
            y = yVar;
        }

        public void SetStepX(int stepxVar)
        {
            stepx = stepxVar;
        }

        public void SetStepY(int stepyVar)
        {
            stepy = stepyVar;
        }
    }
}
