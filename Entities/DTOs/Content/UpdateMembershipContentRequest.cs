﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Content
{
    public class UpdateMembershipContentRequest : BaseModel<UpdateMembershipContentRequest>
    {
        [Required]
        public Guid Id { get; set; }
        public string MembershipMainHeader { get; set; }
        public string MembershipSubHeader { get; set; }
        public string MemberShipName1 { get; set; }
        public string Membership1Amount1 { get; set; }
        public string Membership1Amount2 { get; set; }
        public string Membership1Amount3 { get; set; }
        public string MemberShipName2 { get; set; }
        public string Membership2Amount1 { get; set; }
        public string Membership2Amount2 { get; set; }
        public string Membership2Amount3 { get; set; }
    }
}
