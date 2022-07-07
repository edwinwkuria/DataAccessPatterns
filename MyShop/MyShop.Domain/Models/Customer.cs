using System;

namespace MyShop.Domain.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        private byte[] profilepicture;
        public byte[] ProfilePicture
        {
            get
            {
                if (profilepicture == null)
                {
                    profilepicture = ProfilePictureService.GetFor("hello");
                }
                return profilepicture;
            }
            set
            {
                profilepicture = value;
            }
        }

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}
