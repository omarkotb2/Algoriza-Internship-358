using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.AdminRepository.SettigRepository
{
    public interface IAdminSettingRepository
    {
        Coupon AddCoupon(Coupon NewModel);
        Coupon UpdateCoupon(Coupon NewModel);
        Coupon GetCouponByID(int id);
        void DeleteCoupon(Coupon NewModel);
        void DeactiveCoupon (Coupon NewModel);  
    }
}
