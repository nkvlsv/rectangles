using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
            // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
            if (FirstSQ(r1.Left, r2.Left, r1.Width, r2.Width) && FirstSQ(r1.Top, r2.Top, r1.Height, r2.Height))
                return true;
            else
                return false;
        }
        
        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            if (!AreIntersected(r1, r2)) return 0;
            else if ((r1.Left <= r2.Left) && (r1.Top <= r2.Top))
                return Math.Min((r1.Top + r1.Height - r2.Top), Math.Min(r1.Height, r2.Height)) * Math.Min((r1.Left + r1.Width - r2.Left), Math.Min(r1.Width, r2.Width));
            else if ((r1.Left <= r2.Left) && (r1.Top >= r2.Top))
                return Math.Min((r1.Left + r1.Width - r2.Left), Math.Min(r1.Width, r2.Width)) * Math.Min((r2.Top + r2.Height - r1.Top), Math.Min(r1.Height, r2.Height));
            else if ((r1.Left >= r2.Left) && (r1.Top >= r2.Top))
                return Math.Min((r2.Top + r2.Height - r1.Top), Math.Min(r1.Height, r2.Height)) * Math.Min((r2.Left + r2.Width - r1.Left), Math.Min(r1.Width, r2.Width));
            else return Math.Min((r2.Left + r2.Width - r1.Left), Math.Min(r1.Width, r2.Width)) * Math.Min((r1.Top + r1.Height - r2.Top), Math.Min(r1.Height, r2.Height));
        }

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
            if ((IntersectionSquare(r1, r2)) == (r1.Left * r1.Top) && (r1.Left * r1.Top >= r1.Width * r1.Height))
            {
                if ((r1.Left == 1) || (r1.Top == 1)) return -1;
                else return 0;
            }
            if ((IntersectionSquare(r1, r2)) == (r2.Left * r2.Top) && (r2.Left * r2.Top >= r2.Width * r2.Height))
            {
                if ((r2.Left == 1) || (r2.Top == 1)) return 1;
                else return 1;
            }
            if ((IntersectionSquare(r1, r2)) == (r1.Width * r1.Height) && (r1.Width * r1.Height >= r1.Left * r1.Top))
            {
                if ((r1.Width == 1) || (r1.Height == 1)) return -1;
                else return 0;
            }
            if ((IntersectionSquare(r1, r2)) == (r2.Width * r2.Height) && (r2.Width * r2.Height >= r2.Left * r2.Top))
            {
                if ((r2.Width == 1) || (r2.Height == 1)) return -1;
                else return 1;
            }
            else return -1;
        }
        static bool FirstSQ(int x1, int x2, int y1, int y2)
        {
            return ((x1 + y1 - x2) >= 0) && ((y1 + y2) >= (x1 + y1 - x2));
        }
    }
}