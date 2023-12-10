using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository.AdminRepository.SettigRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.AdminRepository.SettingRepository
{
    public class AdminSettingRepository : IAdminSettingRepository
    {
        private readonly ApplicationDbContext _Context;

        public AdminSettingRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }


        public Coupon AddCoupon(Coupon NewModel)
        {

            _Context.Add(NewModel);
            _Context.SaveChanges();
            return NewModel;
          
        }

      

        public Coupon GetCouponByID(int id)
        {
          var  CouponInDb= _Context.Coupons .Include(D=>D.DiscountType)
                                   .FirstOrDefault(Cou=>Cou.Id==id);


            return CouponInDb;

        }

        public Coupon UpdateCoupon(Coupon UpdatedModel)
        {
            _Context.SaveChanges();
            return UpdatedModel;
        }
        public void DeleteCoupon(Coupon coupon)
        {
            _Context.Coupons.Remove(coupon);
            _Context.SaveChanges();
        }

        public void DeactiveCoupon(Coupon CouponStatus)
        {
            _Context.Coupons.Update(CouponStatus);
            _Context.SaveChanges();
            
        }
    }
}
