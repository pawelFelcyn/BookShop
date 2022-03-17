using System;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime Registered { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
        public string PasswordHash { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
