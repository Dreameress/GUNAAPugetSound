﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs.Scholarship
{
    public class ScholarshipFormSubmissionRequest : BaseModel<ScholarshipFormSubmissionRequest>
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "First Name is Required")]
        public string NameFirst { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [DataType(DataType.Text)]
        public string NameLast { get; set; }

        [DataType(DataType.Text)]
        public string Address { get; set; }

        [DataType(DataType.Text)]
        public string City { get; set; }

        [DataType(DataType.Text)]
        [StringLength(2)]
        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(9)]
        public int ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct Email Address")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        public string CurrentAddress { get; set; }

        [DataType(DataType.Text)]
        public string CurrentCity { get; set; }

        [DataType(DataType.Text)]
        [StringLength(2)]
        public string CurrentState { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(9)]
        public int CurrentZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string CurrentPhone { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct Email Address")]
        public string CurrentEmail { get; set; }

        public string LastSchool { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string SchoolPhone { get; set; }

        public string LastSchoolAddress { get; set; }
        public string LastSchooltAddress { get; set; }

        [DataType(DataType.Text)]
        public string LastSchoolCity { get; set; }

        [DataType(DataType.Text)]
        [StringLength(2)]
        public string LastSchoolState { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(9)]
        public int LastSchoolZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string LastSchoolPhone { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct Email Address")]
        public string LastSchoolEmail { get; set; }

        public string FieldOfStudy { get; set; }
        public string Source { get; set; }

        public string LegacyNameFirst1 { get; set; }
        public string LegacyNameLast1 { get; set; }

        [DataType(DataType.Text)]
        public string LegacyRelation1 { get; set; }

        [DataType(DataType.Text)]
        public string LegacyCity1 { get; set; }

        [DataType(DataType.Text)]
        [StringLength(2)]
        public string LegacyState1 { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(9)]
        public int LegacyZipCode1 { get; set; }
        [StringLength(4)]
        public int Year1 { get; set; }
        public string LegacyNameFirst2 { get; set; }
        public string LegacyNameLast2 { get; set; }

        [DataType(DataType.Text)]
        public string LegacyRelation2 { get; set; }

        [DataType(DataType.Text)]
        public string LegacyCity2 { get; set; }

        [DataType(DataType.Text)]
        [StringLength(2)]
        public string LegacyState2 { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(9)]
        public int LegacyZipCode2 { get; set; }
        [StringLength(4)]
        public int Year2 { get; set; }
        public string LegacyNameFirst3 { get; set; }
        public string LegacyNameLast3 { get; set; }

        [DataType(DataType.Text)]
        public string LegacyRelation3 { get; set; }

        [DataType(DataType.Text)]
        public string LegacyCity3 { get; set; }

        [DataType(DataType.Text)]
        [StringLength(2)]
        public string LegacyState3 { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(9)]
        public int LegacyZipCode3 { get; set; }
        [StringLength(4)]
        public int Year3 { get; set; }
        public string LegacyNameFirst4 { get; set; }
        public string LegacyNameLast4 { get; set; }

        [DataType(DataType.Text)]
        public string LegacyRelation4 { get; set; }

        [DataType(DataType.Text)]
        public string LegacyCity4 { get; set; }

        [DataType(DataType.Text)]
        [StringLength(2)]
        public string LegacyState4 { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(9)]
        public int LegacyZipCode4 { get; set; }
        [StringLength(4)]
        public int Year4 { get; set; }

        [DataType(DataType.MultilineText)]
        public string ExtraCurricular { get; set; }

        [DataType(DataType.MultilineText)]
        public string Leadership { get; set; }

        [DataType(DataType.MultilineText)]
        public string AcademicHonors { get; set; }

        [DataType(DataType.MultilineText)]
        public string Activities { get; set; }

        [DataType(DataType.Text)]
        public string Signature { get; set; }
        public bool Complete { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CompleteTime { get; set; }
    }
}
