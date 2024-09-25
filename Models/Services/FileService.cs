using FileStorage.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace FileStorage.Models.Services
{
    public class FileService
    {



        private readonly Context _db;


        public FileService(Context db)
        {
            _db = db;
        }



        //[HttpGet("customers/{phone}")]
        //[ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        //public IActionResult GetCustomerByPhone(string phone)
        //{
        //    var customer = _Services.GetCustomerByPhoneAsync(phone);

        //    return customer == null ? NotFound() : Ok(customer);
        //}

        //public async Task<FileModel> GetFileAsync(string phone)
        //{

        //    Customer? customer = await _db.Customers.FirstOrDefaultAsync(c => c.Phone == phone);
        //    return customer?.ToDto();
        //}

        //public async Task<FileModel> GetAllFileAsync(string phone)
        //{
        //    return await _db.Files.ToListAsync();

 
        //}

        public async Task<FileModel> CreateFileAsync(FileModel file)
        {

            FileModel newFile = new FileModel(file);
            await _db.Files.AddAsync(newFile);
            await _db.SaveChangesAsync();

            return newFile;


        }

        public async Task<FileModel?> DeleteFileAsync(int id)
        {
            FileModel? file = await _db.Files.FirstOrDefaultAsync(f => f.FileId == id);
            if (file != null)
            {
                _db.Files.Remove(file);
                await _db.SaveChangesAsync();
            }
            return file; //допускает null
        }

        public async Task<FileModel?> RenameFileAsync(int id, string Name)
        {
            FileModel? renamedFile = await _db.Files.FirstOrDefaultAsync(f => f.FileId == id);
            if (renamedFile != null)
            {
                renamedFile.Name = Name;
                _db.Files.Update(renamedFile);
                await _db.SaveChangesAsync();
            }
            return renamedFile;
        }









    }
}
