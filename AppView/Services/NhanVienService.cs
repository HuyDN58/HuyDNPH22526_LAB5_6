using AppData.Model;
using AppView.IServices;

namespace AppView.Services
{
    public class NhanVienService:INhanVienService
    {
        HuyDNPH22526_LAB5_6Context context;// = new ShopDbContext();
        public NhanVienService()
        {
            context = new HuyDNPH22526_LAB5_6Context();
        }

        public bool Create(NhanVien p)
        {
            try
            {
                context.NhanViens.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {// Find(id) chỉ dùng cho thuộc tính khóa chính là id
                var nv = context.NhanViens.Find(id);
                context.NhanViens.Remove(nv);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<NhanVien> GetAllProducts()
        {
            return context.NhanViens.ToList();
        }

        public NhanVien GetProductById(Guid id)
        {
            return context.NhanViens.FirstOrDefault(p => p.Id == id);
            // return context.Products.SingleOrDefault(p => p.Id == id);
        }

        public List<NhanVien> GetProductByName(string name)
        {
            return context.NhanViens.Where(p => p.Ten.Contains(name)).ToList();
        }

        public bool Update(NhanVien p)
        {
            try
            {
                var nv = context.NhanViens.Find(p.Id);
                nv.Ten = p.Ten;
                nv.Tuoi = p.Tuoi;
                nv.Role = p.Role;
                nv.Email = p.Email;
                context.Update(nv);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
