using System.ComponentModel.DataAnnotations.Schema;
using TestingFormsDotNet_3_1.Models.Entities.Base;

namespace TestingFormsDotNet_3_1.Models.Entities
{
    public class FormSectionForm : EntityBase
    {
        public int FormId { get; set; }
        [ForeignKey(nameof(FormId))]
        public Form FormNavigation { get; set; }        
        
        public int FormSectionId { get; set; }
        [ForeignKey(nameof(FormSectionId))]

        public FormSection FormSectionNavigation { get; set; }

        public int? Order { get; set; }
    }
}
