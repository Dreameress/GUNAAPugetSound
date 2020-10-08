using System;
using GUNAAPugetSound.Entities.Enums;

namespace Entities.Models
{
    public class Content
    {
        public int Id { get; set; }

        public View View { get; set; }
        public string HomeSubHeader { get; set; }
        public string HomeLine1 { get; set; }
        public string HomeLine2 { get; set; }
        public string HomeLine3 { get; set; }
        public string CalendarSubHeader { get; set; }
        public string OfficersSubHeader { get; set; }
        public string CommitteesSubHeader { get; set; }
        public string MembershipSubHeader { get; set; }
        public string MemberShipName1 { get; set; }
        public string Membership1Amount1 { get; set; }
        public string Membership1Amount2 { get; set; }
        public string Membership1Amount3 { get; set; }
        public string MemberShipName2 { get; set; }
        public string Membership2Amount1 { get; set; }
        public string Membership2Amount2 { get; set; }
        public string Membership2Amount3 { get; set; }
        public string ScholarshipSubHeader { get; set; }
        public string ScholarshipLine1 { get; set; }
        public string ScholarshipDocumentName1 { get; set; }
        public string ScholarshipDocumentName2 { get; set; }
        public string ScholarshipDocumentName3 { get; set; }
        public string PhotoSubHeader { get; set; }
        public string AboutUsSubHeader { get; set; }
        public string AboutUsQuote { get; set; }
        public string ContactUsSubHeader { get; set; }
        public string ContactUsAddressName1 { get; set; }
        public string ContactUsAddressName2 { get; set; }
        public string ContactUsStreetAddress { get; set; }
        public string ContactUsCityStateZip { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int LastUpdatedUserId { get; set; }
    }

}
