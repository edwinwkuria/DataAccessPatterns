using MyShop.Domain;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Proxy
{
    public class CustomerProxy : Customer
    {
        public override byte[] ProfilePicture
        {
            get
            {
                if (base.ProfilePicture == null)
                {
                    base.ProfilePicture = ProfilePictureService.GetFor("test");
                }
                return base.ProfilePicture;
            }
        }
    }
}
