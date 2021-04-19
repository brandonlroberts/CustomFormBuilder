using System.ComponentModel.DataAnnotations.Schema;
using TestingFormsDotNet_3_1.Models.Entities.Base;

namespace TestingFormsDotNet_3_1.Models.Entities
{
    public class FormControl : EntityBase
    {
        public string FormName { get; set; }
        public string Data { get; set; }
        public int FormSectionId { get; set; }

        [ForeignKey(nameof(FormSectionId))]
        public FormSection FormSectionNavigation { get; set; }

        public int FormDataTypeId { get; set; }

        [ForeignKey(nameof(FormDataTypeId))]
        public FormDataType FormDataType { get; set; }

        public bool IsVisible { get; set; }
        public int Order { get; set; }

        public string CssClass { get; set; }
    }
}
