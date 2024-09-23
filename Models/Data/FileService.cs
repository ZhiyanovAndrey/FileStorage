namespace FileStorage.Models.Data
{
    public class FileService
    {



        private readonly Context _db;


        public FileService(Context db)
        {
            _db = db;

        }

     

        public async Task<File> CreateFileAsync(File file)
        {

            File newFile = new File(file);
            await _db.Files.AddAsync(newFile);
            await _db.SaveChangesAsync();

            return newFile;


        }

        //public async Task<Customer?> DeleteCustomerAsync(int id)
        //{
        //    Customer? customer = await _db.Customers.FirstOrDefaultAsync(c => c.Customerid == id);
        //    if (customer != null)
        //    {
        //        _db.Customers.Remove(customer);
        //        await _db.SaveChangesAsync();
        //    }
        //    return customer;
        //}









    }
}
