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
        public int radius = 5;
        public bool IsHit = false;

        public MovingBall(int initialX, int initialY) {
            this.x = initialX;
            this.y = initialY;
            this.delthaX=1;
            this.delthaY=1;
            this.limitMinX=0;
            this.limitMaxX=100;
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
        public double CalculateDistance(MovingBall ball)
        {
            return Math.Sqrt(Math.Pow((ball.x - this.x), 2) + Math.Pow((ball.y - this.y), 2));
        }

        public bool Hit(MovingBall ball)
        {
            if (this.CalculateDistance(ball) <= this.radius ||
                this.CalculateDistance(ball) <= ball.radius)
            {
                ball.color = "#FF0000";
                this.color = "#FF0000";
                ball.IsHit = true;
                this.IsHit = true;

                return true;
            }
            else return false;
        }
    }
}