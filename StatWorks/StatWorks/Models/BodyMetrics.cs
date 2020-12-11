using Xamarin.Forms.Internals;

namespace StatWorks.Models
{
    [Preserve(AllMembers = true)]
    public class BodyMetrics
    {
        public Weight weight { get; set; }

        public Height height { get; set; }

        public string sex { get; set; }

        public int age { get; set; }

        public double waist { get; set; }

        public double hip { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class Weight
    {
        public double value { get; set; }

        public string unit { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class Height
    {
        public double value { get; set; }

        public string unit { get; set; }
    }
}
