using CsvHelper.Configuration.Attributes;

namespace DataNormalisedReFormatter.Models
{
    public class OutputDataModel
    {
        [Index(0)]
        public int ID { get; set; }

        [Index(1)]
        public string LastName { get; set; }


        [Index(2)]
        public string FirstName { get; set; }

        [Index(3)]
        public string MiddleName { get; set; }

        [Index(4)]
        public string PreferredName { get; set; }

        [Index(5)]
        public string Address { get; set; }

        [Index(6)]
        public string Email { get; set; }

        [Index(7)]
        public string Phone { get; set; }

        [Index(8)]
        public string Mobile { get; set; }

        [Index(9)]
        public string CategoryNumber { get; set; }

        [Index(10)]
        public string Cateogry { get; set; }

        [Index(11)]
        public string Method { get; set; }

        [Index(12)]
        public int LDCID { get; set; }

    }
}