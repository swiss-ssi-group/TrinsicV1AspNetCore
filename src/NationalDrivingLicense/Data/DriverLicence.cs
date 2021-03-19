using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NationalDrivingLicense.Data
{
    public class DriverLicence
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTimeOffset IssuedAt { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Issuedby { get; set; }
        public bool Valid { get; set; }
        public string DriverLicenceCredentials { get; set; }
    }
}
