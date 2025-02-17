using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Interfaces
{
    public interface IPackagingService
    {
        Task<IEnumerable<PackagingDto>> GetAllPackagingsAsync();
        Task<PackagingDto> GetPackagingByIdAsync(int id);
        Task<PackagingDto> CreatePackagingAsync(PackagingDto packagingDto);
        Task<bool> UpdatePackagingAsync(PackagingDto packagingDto);
        Task<bool> DeletePackagingAsync(int id);
        Task<PagedResult<PackagingDto>> GetPagedPackagingsAsync(PageRequest pageRequest);
    }

}
