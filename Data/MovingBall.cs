using System;

namespace BouncingBalls.Data
{

    public class MovingBall
    {
        public int x { get; set; }
        public int y { get; set; }
        public string color { get; set; } ="#0000BB";
        private int delthaX, delthaY;
        private int limitMinX, limitMaxX;
        private int limitMinY, limitMaxY;
        
        private double rightBoundrey;
        private double topBoundry;
        private double leftBoundry;
        private double bottomBoundry;
        private double radius;

        public MovingBall(int initialX, int initialY) {
            this.x = initialX;
            this.y = initialY;
            this.delthaX=1;
            this.delthaY=1;
            this.limitMinX=0;
            this.limitMaxX=100;
            this.radius=1;
        }

        public void setVelocity(int diffX,int diffY) {
            this.delthaX = diffX;
            this.delthaY = diffY;
        }

        public void setLimitX(int min,int max) {
            this.limitMinX = min;
            this.limitMaxX = max;
        }

        public void setLimitY(int min,int max) {
            this.limitMinY = min;
            this.limitMaxY = max;
        }

        public void next() {
            this.x += this.delthaX;
            this.y += this.delthaY;
            if(this.x<this.limitMinX || this.x>this.limitMaxX)
            this.delthaX *= -1;
            if(this.y<this.limitMinY || this.y>this.limitMaxY)
            this.delthaY *= -1;
        }

        // Boundaries

        public void setBounds(double right, double top, double left, double bottom) 
        {
            this.rightBoundrey = right - this.radius - Math.Abs(this.delthaX);
            this.topBoundry = top - this.radius - Math.Abs(this.delthaY);
            this.leftBoundry = left + this.radius + Math.Abs(this.delthaX);
            this.bottomBoundry = bottom + this.radius + Math.Abs(this.delthaY);
        }
    }
}