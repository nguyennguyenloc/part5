namespace part5.data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(500)]
        public string PasswordEncrypted { get; set; }

        [StringLength(10)]
        public string PasswordSalt { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(10)]
        public string LastName { get; set; }

        public short? Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public bool? IsDeleted { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }
    }
}
