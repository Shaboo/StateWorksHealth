using Xamarin.Forms.Internals;

namespace StatWorks.Models
{
    [Preserve(AllMembers = true)]
    public class BMIApiResponse
    {
        public BMIRes bmi { get; set; }

        public string ideal_weight { get; set; }

        public double surface_area { get; set; }

        public double ponderal_index { get; set; }

        public BMR bmr { get; set; }

        public Whr whr { get; set; }

        public Whtr whtr { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class BMIRes
    {
        public double value { get; set; }

        public string status { get; set; }

        public string risk { get; set; }

        public double prime { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class BMR
    {
        public double value { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class Whr
    {
        public double value { get; set; }

        public string status { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class Whtr
    {
        public double value { get; set; }

        public string status { get; set; }
    }
}
