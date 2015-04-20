using System;

namespace MastaClasta
{
    public class ImageClaster
    {
        public int ImageClass { set; get; }

        public int ResultImageClass { set; get; }
        public int Perimeter { set; get; }
        public int Square { set; get; }
        public double Compactness { get { return Math.Pow(Perimeter, 2) / Square; } }
        public double Elongation
        {
            get
            {
                return (Moment20 + Moment02 + Math.Sqrt(Math.Pow(Moment20 - Moment02, 2) + Math.Pow(2*Moment11, 2)))/
                    (Moment20 + Moment02 - Math.Sqrt(Math.Pow(Moment20 - Moment02, 2) + Math.Pow(2*Moment11, 2)));
            }
        }
        public double MassX { set; get; }
        public double MassY { set; get; }
        public double MassCenterX {  get { return MassX/Square; } }
        public double MassCenterY {  get { return MassY/Square; } }

        public double Moment20 { set; get; }
        public double Moment02 { set; get; }
        public double Moment11 { set; get; }

        public int RColorSum { set; get; }
        public int GColorSum { set; get; }
        public int BColorSum { set; get; }


        public double RAverageColor { get { return RColorSum / Square; } }
        public double GAverageColor { get { return GColorSum / Square; } }
        public double BAverageColor { get { return BColorSum / Square; } }


        public LightImageClaster ToLightImageClaster()
        {
            return new LightImageClaster
            {
                BasicImageClass = ImageClass,
                Compactness = Compactness,
                Elongation = Elongation,
                ResultImageClass = 0,
                Perimeter = Perimeter,
                Square = Square
            };
        }

        public override String ToString()
        {
            return String.Format("Image class {0} has Elongation = {1}, Compacness = {2} & Average Color = {3};{4};{5}", ImageClass, Elongation.ToString("F2"),
                Compactness.ToString("F2"),
            RAverageColor.ToString("F2"),
            GAverageColor.ToString("F2"),
            BAverageColor.ToString("F2"));
        }
    }

    public class LightImageClaster
    {
        protected bool Equals(LightImageClaster other)
        {
            return Compactness.Equals(other.Compactness) && Elongation.Equals(other.Elongation);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return obj.GetType() == GetType() && Equals((LightImageClaster) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Compactness.GetHashCode()*397) ^ Elongation.GetHashCode();
            }
        }

        public int BasicImageClass { set; get; }
        public int ResultImageClass { set; get; }
        public double Compactness { get; set; }
        public double Elongation { set; get; }
        public double Perimeter { set; get; }
        public double Square { set; get; }
        public double[] ColorMap { set; get; }

        public bool IsBadClaster()
        {
            return Double.IsNaN(Compactness) || Double.IsPositiveInfinity(Compactness) ||
                   Double.IsNaN(Elongation) || Double.IsPositiveInfinity(Elongation) ||
                   Double.IsNaN(Perimeter) || Double.IsPositiveInfinity(Perimeter) ||
                   Double.IsNaN(Square) || Double.IsPositiveInfinity(Square);
        }
        public double CalculateEuclideanDistance(LightImageClaster other)
        {
            return
               /* Math.Sqrt(Math.Pow(Compactness - other.Compactness, 2) + */  Math.Pow(Elongation - other.Elongation, 2) +
                          Math.Pow(Square - other.Square, 2) /*+ Math.Pow(Perimeter - other.Perimeter, 2))*/;
        }
        public static bool operator ==(LightImageClaster thisClaster, LightImageClaster otherClaster)
        {
            return ((thisClaster.Compactness.ToString("F3") == otherClaster.Compactness.ToString("F3")) &&
                    (thisClaster.Elongation.ToString("F3") == otherClaster.Elongation.ToString("F3")));
        }

        public static bool operator !=(LightImageClaster thisClaster, LightImageClaster otherClaster)
        {
            return !(((thisClaster.Compactness.ToString("F3") == otherClaster.Compactness.ToString("F3")) &&
                      (thisClaster.Elongation.ToString("F3") == otherClaster.Elongation.ToString("F3"))));
        }
    }
}
