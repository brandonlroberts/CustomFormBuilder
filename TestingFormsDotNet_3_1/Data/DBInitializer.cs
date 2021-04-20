using System;
using System.Collections.Generic;
using System.Linq;
using TestingFormsDotNet_3_1.Data.Entities;
using TestingFormsDotNet_3_1.Models.Entities;

namespace TestingFormsDotNet_3_1.Data
{
    public class DBInitializer
    {
        public static void Initialize(FormsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any forms.
            if (context.Forms.Any())
            {
                return;   // DB has been seeded
            }

            List<FormSection> sections = new List<FormSection>
            {
                new FormSection { Id = 1, Name = "Person" },
                new FormSection { Id = 2, Name = "Address" }
            };
            context.FormSections.AddRange(sections);
            context.SaveChanges();

            List<FormDataType> data = new List<FormDataType>
            {
                new FormDataType { Id = 1, Name = "String" },
                new FormDataType { Id = 2, Name = "Int" },
                new FormDataType { Id = 3, Name = "Double" },
                new FormDataType { Id = 4, Name = "Bool" },
                new FormDataType { Id = 5, Name = "DateTime" }
            };
            context.FormDataTypes.AddRange(data);
            context.SaveChanges();

            List<MannerOfDeathType> mannerOfDeathTypes = new List<MannerOfDeathType>
            {
                new MannerOfDeathType { Id = 1, Name = "Accidental" },
                new MannerOfDeathType { Id = 2, Name = "Homicide" },
                new MannerOfDeathType { Id = 3, Name = "Natural" },
                new MannerOfDeathType { Id = 4, Name = "Suicide" },
                new MannerOfDeathType { Id = 5, Name = "Undetermined" }
            };
            context.MannerOfDeathTypes.AddRange(mannerOfDeathTypes);
            context.SaveChanges();

            List<MannerOfDeathSubType> mannerOfDeathSubType = new List<MannerOfDeathSubType>
            {
                new MannerOfDeathSubType { Id = 1, MannerOfDeathTypeId = 1,  Name = "Drug Overdose" },
                new MannerOfDeathSubType { Id = 2, MannerOfDeathTypeId = 1,  Name = "Fall" },
                new MannerOfDeathSubType { Id = 3, MannerOfDeathTypeId = 1,  Name = "Motor vehicle" },
                new MannerOfDeathSubType { Id = 4, MannerOfDeathTypeId = 1,  Name = "Other" },
                new MannerOfDeathSubType { Id = 5, MannerOfDeathTypeId = 1,  Name = "Asphyxia" },
                new MannerOfDeathSubType { Id = 6, MannerOfDeathTypeId = 1,  Name = "Drowning" },
                new MannerOfDeathSubType { Id = 7, MannerOfDeathTypeId = 1,  Name = "Thermal" },
                new MannerOfDeathSubType { Id = 8, MannerOfDeathTypeId = 1,  Name = "Hypothermia" },
                new MannerOfDeathSubType { Id = 9, MannerOfDeathTypeId = 1,  Name = "Accidental deaths by age (groups)" },

                new MannerOfDeathSubType { Id = 10, MannerOfDeathTypeId = 2, Name = "Firearm" },
                new MannerOfDeathSubType { Id = 11, MannerOfDeathTypeId = 2, Name = "Blunt Force" },
                new MannerOfDeathSubType { Id = 12, MannerOfDeathTypeId = 2, Name = "Sharp Force" },
                new MannerOfDeathSubType { Id = 13, MannerOfDeathTypeId = 2, Name = "Other" },
                new MannerOfDeathSubType { Id = 14, MannerOfDeathTypeId = 2, Name = "Homicide deaths by age (groups)" },
                new MannerOfDeathSubType { Id = 15, MannerOfDeathTypeId = 2, Name = "Homicide deaths by race & gender" },

                new MannerOfDeathSubType { Id = 16, MannerOfDeathTypeId = 3, Name = "Gastrointestinal" },
                new MannerOfDeathSubType { Id = 17, MannerOfDeathTypeId = 3, Name = "Cardiovascular Disease" },
                new MannerOfDeathSubType { Id = 18, MannerOfDeathTypeId = 3, Name = "Chronic alcohol/ drug use" },
                new MannerOfDeathSubType { Id = 19, MannerOfDeathTypeId = 3, Name = "Respiratory" },
                new MannerOfDeathSubType { Id = 20, MannerOfDeathTypeId = 3, Name = "Neurological" },
                new MannerOfDeathSubType { Id = 21, MannerOfDeathTypeId = 3, Name = "Metabolic Disorder" },
                new MannerOfDeathSubType { Id = 22, MannerOfDeathTypeId = 3, Name = "Other" },
                new MannerOfDeathSubType { Id = 23, MannerOfDeathTypeId = 3, Name = "Infectious diseases" },
                new MannerOfDeathSubType { Id = 24, MannerOfDeathTypeId = 3, Name = "Cancer" },
                new MannerOfDeathSubType { Id = 25, MannerOfDeathTypeId = 3, Name = "Genitourinary" },
                new MannerOfDeathSubType { Id = 26, MannerOfDeathTypeId = 3, Name = "Obesity" },
                new MannerOfDeathSubType { Id = 27, MannerOfDeathTypeId = 3, Name = "Natural deaths by age (groups)" },
                new MannerOfDeathSubType { Id = 28, MannerOfDeathTypeId = 3, Name = "Natural deaths by race & gender" },

                new MannerOfDeathSubType { Id = 29, MannerOfDeathTypeId = 4, Name = "Firearm" },
                new MannerOfDeathSubType { Id = 30, MannerOfDeathTypeId = 4, Name = "Hanging" },
                new MannerOfDeathSubType { Id = 31, MannerOfDeathTypeId = 4, Name = "Acute intoxication" },
                new MannerOfDeathSubType { Id = 32, MannerOfDeathTypeId = 4, Name = "Other" },
                new MannerOfDeathSubType { Id = 33, MannerOfDeathTypeId = 4, Name = "Blunt Force" },
                new MannerOfDeathSubType { Id = 34, MannerOfDeathTypeId = 4, Name = "Sharp Force" },
                new MannerOfDeathSubType { Id = 35, MannerOfDeathTypeId = 4, Name = "Suicide deaths by age" },
                new MannerOfDeathSubType { Id = 36, MannerOfDeathTypeId = 4, Name = "Suicide dealths by race & gender" },
                new MannerOfDeathSubType { Id = 37, MannerOfDeathTypeId = 4, Name = "Undetermined" },
                new MannerOfDeathSubType { Id = 38, MannerOfDeathTypeId = 4, Name = "Other" },
                new MannerOfDeathSubType { Id = 39, MannerOfDeathTypeId = 4, Name = "Drug Overdose" },
                new MannerOfDeathSubType { Id = 40, MannerOfDeathTypeId = 4, Name = "Undetermined deaths by age (groups)" },
                new MannerOfDeathSubType { Id = 41, MannerOfDeathTypeId = 4, Name = "Undetermined deaths by race & gender" }

            };
            context.MannerOfDeathSubTypes.AddRange(mannerOfDeathSubType);
            context.SaveChanges();

            List<State> states = new List<State>
            {
                new State { Id = 1, Name = "AL", Abbreviation = "Alabama" },
                new State { Id = 2, Name = "AK", Abbreviation = "Alaska" },
                new State { Id = 3, Name = "AZ", Abbreviation = "Arizona" },
                new State { Id = 4, Name = "AR", Abbreviation = "Arkansas" },
                new State { Id = 5, Name = "CA", Abbreviation = "California" },
                new State { Id = 6, Name = "CO", Abbreviation = "Colorado" },
                new State { Id = 7, Name = "CT", Abbreviation = "Connecticut" },
                new State { Id = 8, Name = "DE", Abbreviation = "Delaware" },
                new State { Id = 9, Name = "DC", Abbreviation = "District Of Columbia" },
                new State { Id = 10, Name = "FL", Abbreviation = "Florida" },
                new State { Id = 11, Name = "GA", Abbreviation = "Georgia" },
                new State { Id = 12, Name = "HI", Abbreviation = "Hawaii" },
                new State { Id = 13, Name = "ID", Abbreviation = "Idaho" },
                new State { Id = 14, Name = "IL", Abbreviation = "Illinois" },
                new State { Id = 15, Name = "IN", Abbreviation = "Indiana" },
                new State { Id = 16, Name = "IA", Abbreviation = "Iowa" },
                new State { Id = 17, Name = "KS", Abbreviation = "Kansas" },
                new State { Id = 18, Name = "KY", Abbreviation = "Kentucky" },
                new State { Id = 19, Name = "LA", Abbreviation = "Louisiana" },
                new State { Id = 20, Name = "ME", Abbreviation = "Maine" },
                new State { Id = 21, Name = "MD", Abbreviation = "Maryland" },
                new State { Id = 22, Name = "MA", Abbreviation = "Massachusetts" },
                new State { Id = 23, Name = "MI", Abbreviation = "Michigan" },
                new State { Id = 24, Name = "MN", Abbreviation = "Minnesota" },
                new State { Id = 25, Name = "MS", Abbreviation = "Mississippi" },
                new State { Id = 26, Name = "MO", Abbreviation = "Missouri" },
                new State { Id = 27, Name = "MT", Abbreviation = "Montana" },
                new State { Id = 28, Name = "NE", Abbreviation = "Nebraska" },
                new State { Id = 29, Name = "NV", Abbreviation = "Nevada" },
                new State { Id = 30, Name = "NH", Abbreviation = "New Hampshire" },
                new State { Id = 31, Name = "NJ", Abbreviation = "New Jersey" },
                new State { Id = 32, Name = "NM", Abbreviation = "New Mexico" },
                new State { Id = 33, Name = "NY", Abbreviation = "New York" },
                new State { Id = 34, Name = "NC", Abbreviation = "North Carolina" },
                new State { Id = 35, Name = "ND", Abbreviation = "North Dakota" },
                new State { Id = 36, Name = "OH", Abbreviation = "Ohio" },
                new State { Id = 37, Name = "OK", Abbreviation = "Oklahoma" },
                new State { Id = 38, Name = "OR", Abbreviation = "Oregon" },
                new State { Id = 39, Name = "PA", Abbreviation = "Pennsylvania" },
                new State { Id = 40, Name = "RI", Abbreviation = "Rhode Island" },
                new State { Id = 41, Name = "SC", Abbreviation = "South Carolina" },
                new State { Id = 42, Name = "SD", Abbreviation = "South Dakota" },
                new State { Id = 43, Name = "TN", Abbreviation = "Tennessee" },
                new State { Id = 44, Name = "TX", Abbreviation = "Texas" },
                new State { Id = 45, Name = "UT", Abbreviation = "Utah" },
                new State { Id = 46, Name = "VT", Abbreviation = "Vermont" },
                new State { Id = 47, Name = "VA", Abbreviation = "Virginia" },
                new State { Id = 48, Name = "WA", Abbreviation = "Washington"  },
                new State { Id = 49, Name = "WV", Abbreviation = "West Virginia"  },
                new State { Id = 50, Name = "WI", Abbreviation = "Wisconsin" },
                new State { Id = 51, Name = "WY", Abbreviation = "Wyoming" },
        };
            context.States.AddRange(states);
            context.SaveChanges();

            List<FormControl> controls = new List<FormControl>
        {

            // Address
            new FormControl { Data = "",  FormName = "Zip",        FormSectionId = 2, FormDataTypeId = 1, IsVisible = true, Order = 5, CssClass = "", IsActive = true },
            new FormControl { Data = "",  FormName = "State",      FormSectionId = 2, FormDataTypeId = 2, IsVisible = true, Order = 4, CssClass = "", IsActive = true },
            new FormControl { Data = "",  FormName = "City",       FormSectionId = 2, FormDataTypeId = 1, IsVisible = true, Order = 3, CssClass = "", IsActive = true },
            new FormControl { Data = "",  FormName = "Address 3",  FormSectionId = 2, FormDataTypeId = 1, IsVisible = true, Order = 2, CssClass = "", IsActive = true },
            new FormControl { Data = "",  FormName = "Address 2",  FormSectionId = 2, FormDataTypeId = 1, IsVisible = true, Order = 1, CssClass = "", IsActive = true },
            new FormControl { Data = "",  FormName = "Address 1",  FormSectionId = 2, FormDataTypeId = 1, IsVisible = true, Order = 0, CssClass = "", IsActive = true },

            // Person
            new FormControl { Data = "", FormName = "Height",     FormSectionId = 1, FormDataTypeId = 2, IsVisible = true, Order = 4, CssClass = "", IsActive = true },
            new FormControl { Data = "", FormName = "Weight",     FormSectionId = 1, FormDataTypeId = 3, IsVisible = true, Order = 3, CssClass = "", IsActive = true },
            new FormControl { Data = "", FormName = "DOB",        FormSectionId = 1, FormDataTypeId = 5, IsVisible = true, Order = 2, CssClass = "", IsActive = true },
            new FormControl { Data = "", FormName = "Last Name",  FormSectionId = 1, FormDataTypeId = 1, IsVisible = true, Order = 1, CssClass = "", IsActive = true },
            new FormControl { Data = "", FormName = "First Name", FormSectionId = 1, FormDataTypeId = 1, IsVisible = true, Order = 0, CssClass = "", IsActive = true },

        };
            context.FormControls.AddRange(controls);
            context.SaveChanges();

            List<Form> forms = new List<Form>
        {
            new Form
            {
                Name = "Roberts Death Cert",
            },
        };
            context.Forms.AddRange(forms);
            context.SaveChanges();

            List<FormControlForm> formControlForms = new List<FormControlForm>
        {
            new FormControlForm { FormId = 1, FormControlId = 1 , IsActive = true, Order = 0},
            new FormControlForm { FormId = 1, FormControlId = 2 , IsActive = true, Order = 1},
            new FormControlForm { FormId = 1, FormControlId = 3 , IsActive = true, Order = 2},
            new FormControlForm { FormId = 1, FormControlId = 4 , IsActive = true, Order = 3},
            new FormControlForm { FormId = 1, FormControlId = 5 , IsActive = true, Order = 4},
            new FormControlForm { FormId = 1, FormControlId = 6 , IsActive = true, Order = 0},
            new FormControlForm { FormId = 1, FormControlId = 7 , IsActive = true, Order = 1},
            new FormControlForm { FormId = 1, FormControlId = 8 , IsActive = true, Order = 2},
            new FormControlForm { FormId = 1, FormControlId = 9 , IsActive = true, Order = 3},
            new FormControlForm { FormId = 1, FormControlId = 10, IsActive = true, Order = 4},
            new FormControlForm { FormId = 1, FormControlId = 11, IsActive = true, Order = 5},
        };
            context.FormControlForms.AddRange(formControlForms);
            context.SaveChanges();

            List<FormSectionForm> formSectionForms = new List<FormSectionForm>
        {
            new FormSectionForm { FormId = 1, FormSectionId = 1 , IsActive = true, Order = 0},
            new FormSectionForm { FormId = 1, FormSectionId = 2 , IsActive = true, Order = 1},
        };
            context.FormSectionForms.AddRange(formSectionForms);
            context.SaveChanges();
        }
    }
}
