using System.ComponentModel.DataAnnotations.Schema;
using TestingFormsDotNet_3_1.Models.Entities.Base;

namespace TestingFormsDotNet_3_1.Models.Entities
{
    public class FormControlForm : EntityBase
    {
        public int FormId { get; set; }
        [ForeignKey(nameof(FormId))]
        public Form FormNavigation { get; set; }        
        
        public int FormControlId { get; set; }
        [ForeignKey(nameof(FormControlId))]
        public FormControl FormControlNavigation { get; set; }
    }
}
