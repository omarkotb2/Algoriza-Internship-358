using DomainLayer.DTO.AdminDTO.SettingDTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.AdminRepository.SettigRepository
{
    public interface IAdminSettingService
    {
        bool AddCoupon(AddCouponDTO NewModel);
        bool UpdateCoupon(UpdateCouponDTO NewModel , int id);
        bool DeleteCoupon(int id);
        bool DeactiveCoupon(int id);
    }
}
