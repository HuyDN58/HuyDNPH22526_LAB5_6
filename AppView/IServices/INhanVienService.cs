using AppData.Model;


namespace AppView.IServices
{
    public interface INhanVienService
    {
            public bool Create(NhanVien p);
            public bool Update(NhanVien p);
            public bool Delete(Guid id);
            public List<NhanVien> GetAllProducts();
            public NhanVien GetProductById(Guid id);
            public List<NhanVien> GetProductByName(string name);


    }
}
