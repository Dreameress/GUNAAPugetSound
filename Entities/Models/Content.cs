using System;
using System.ComponentModel.DataAnnotations;
using GUNAAPugetSound.Entities.Enums;

namespace Entities.Models
{
   
    public class Content
    {
        [Key]
        public Guid ContentId { get; set; }
        public string HomeMainHeader { get; set; }
        public string HomeSubHeader { get; set; }
        public string HomeLine1 { get; set; }
        public string HomeLine2 { get; set; }
        public string HomeLine3 { get; set; }
        public string HomeLine4 { get; set; }
        public string CalendarMainHeader { get; set; }
        public string CalendarSubHeader { get; set; }
        public string OfficersMainHeader { get; set; }
        public string OfficersSubHeader { get; set; }
        public string CommitteesMainHeader { get; set; }
        public string CommitteesSubHeader { get; set; }
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
        public string ScholarshipMainHeader { get; set; }
        public string ScholarshipSubHeader { get; set; }
        public string ScholarshipLine1 { get; set; }
        public string PhotoMainHeader { get; set; }
        public string PhotoSubHeader { get; set; }
        public string AboutUsHeader { get; set; }
        public string AboutUsSubHeader { get; set; }
        public string AboutUsQuoteLine1 { get; set; }
        public string AboutUsQuoteLine2 { get; set; }
        public string AboutUsQuoteLine3 { get; set; }
        public string AboutUsQuoteLine4 { get; set; }
        public string ContactUsHeader { get; set; }
        public string ContactUsSubHeader { get; set; }
        public string ContactUsAddressName1 { get; set; }
        public string ContactUsAddressName2 { get; set; }
        public string ContactUsStreetAddress { get; set; }
        public string ContactUsCity { get; set; }
        public string ContactUsState { get; set; }
        public string ContactUsZipCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int LastUpdatedUserId { get; set; }
    }

}
