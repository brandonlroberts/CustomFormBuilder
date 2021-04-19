using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingFormsDotNet_3_1.Models.Entities
{
    public class MannerOfDeathSubType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int MannerOfDeathTypeId { get; set; }

        [ForeignKey(nameof(MannerOfDeathTypeId))]
        public MannerOfDeathType MannerOfDeathTypeNavigation { get; set; }

        public string Name { get; set; }
    }
}
