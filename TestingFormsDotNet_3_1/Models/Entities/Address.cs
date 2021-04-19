using System.ComponentModel.DataAnnotations.Schema;
using TestingFormsDotNet_3_1.Models.Entities.Base;

namespace TestingFormsDotNet_3_1.Models.Entities
{
    public class Address : EntityBase
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }

        [ForeignKey(nameof(StateId))]
        public State StateNavigation { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
    }
}
