using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingFormsDotNet_3_1.Models.Entities.Base;

namespace TestingFormsDotNet_3_1.Models.ViewModels
{
    public class FormViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public byte[] Rowversion { get; set; }
        public List<FormControlFormViewModel> FormControlForms { get; set; }
    }

    public class FormControlFormViewModel
    {
        public bool IsActive { get; set; }
        public FormControlNavigationViewModel FormControlNavigation { get; set; }
    }

    public class FormControlNavigationViewModel
    {
        public int ControlId { get; set; }
        public string FormName { get; set; }
        public string Data { get; set; }
        public int? FormSectionId { get; set; }
        public bool IsActive { get; set; }

        public int FormDataTypeId { get; set; }
    }

}
