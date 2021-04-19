using System;
using TestingFormsDotNet_3_1.Models.Entities.Base;

namespace TestingFormsDotNet_3_1.Models.Entities
{
    public class Person : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
    }
}
