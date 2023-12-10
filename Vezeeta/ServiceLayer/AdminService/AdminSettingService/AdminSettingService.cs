using DomainLayer.DTO.AdminDTO.SettingDTO;
using DomainLayer.Models;
using RepositoryLayer.Repository.AdminRepository.DoctorRepository;
using RepositoryLayer.Repository.AdminRepository.SettigRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.AdminRepository.SettingRepository
{
    public class AdminSettingService : IAdminSettingService
    {
        private readonly IAdminSettingRepository _adminSettingRepository;



        public AdminSettingService(IAdminSettingRepository adminSettingRepository)
        {
            _adminSettingRepository = adminSettingRepository;
                
        }



        public bool AddCoupon(AddCouponDTO NewModel)
        {

            Coupon coupon = new Coupon();
            if (NewModel != null)
            {
                coupon.DiscoundCode = NewModel.DiscoundCode;
                coupon.NumberOfCompletedRequest = NewModel.NumberOfCompletedRequest;
                coupon.DiscountTypeId = NewModel.DiscoundTypeId;
                coupon.DiscoundValue= NewModel.DiscoundValue;

                _adminSettingRepository.AddCoupon(coupon);
                return true;
            }
            else
            {
                return false;

            }

           
        }

       

        public bool UpdateCoupon(UpdateCouponDTO NewModel, int id)
        {
            var CouponOnDB = _adminSettingRepository.GetCouponByID(id);
            if (CouponOnDB != null)
            {
               // CouponOnDB.Id = NewModel.Id;
                CouponOnDB.DiscoundCode= NewModel.DiscoundCode;
                CouponOnDB.NumberOfCompletedRequest= NewModel.NumberOfCompletedRequest;
                CouponOnDB.DiscountTypeId = NewModel.DiscoundTypeId;
                CouponOnDB.DiscoundValue = NewModel.DiscoundValue;

                _adminSettingRepository.UpdateCoupon(CouponOnDB);
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public bool DeleteCoupon(int id)
        {
            var CouponOnDB = _adminSettingRepository.GetCouponByID(id);
            if (CouponOnDB != null && CouponOnDB.IsActive)
            {
                _adminSettingRepository.DeleteCoupon(CouponOnDB);
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool DeactiveCoupon(int id)
        {
            var CouponOnDB = _adminSettingRepository.GetCouponByID(id);
            if (CouponOnDB.IsActive==true)
            {
                CouponOnDB.IsActive= false; 
                _adminSettingRepository.DeactiveCoupon(CouponOnDB);
                return true;

            }
            else
            {
                return false;
            }

        }
    }
}
