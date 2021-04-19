using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingFormsDotNet_3_1.Models.Entities.Base;

namespace TestingFormsDotNet_3_1.Models.Entities
{
    public class Form : EntityBase
    {
        public string Name { get; set; }
        public List<FormControlForm> FormControlForms { get; set; }

        //[Display(Name="Date of Death")]
        //public DateTime DateOfDeath { get; set; }

        //[Display(Name = "Case Number")]
        //public int CaseNumber { get; set; }

        //[Display(Name = "Manner of Death Sub Type")]
        //public int MannerOfDeathSubType { get; set; }

        //[Display(Name = "Total Numbers Reported")]
        //public int TotalNumbersReported { get; set; }
    }
}
