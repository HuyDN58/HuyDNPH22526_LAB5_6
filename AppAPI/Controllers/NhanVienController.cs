using AppData.IRepositories;
using AppData.Model;
using AppData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private IAllRepositories<NhanVien> irepos;
        private HuyDNPH22526_LAB5_6Context context = new HuyDNPH22526_LAB5_6Context();
        public NhanVienController()
        {
            AllRepositories<NhanVien> repos = new AllRepositories<NhanVien>(context, context.NhanViens);
            irepos = repos;
        }
        [HttpGet]
        public IEnumerable<NhanVien> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public NhanVien Get(Guid id)
        {
            return irepos.GetAll().First(c => c.Id == id);
        }
        [HttpPost("Create-mausac")]


        public bool Create(string Ten, int Tuoi, int Role, string Email, int Luong, bool Trangthai)
        {
            NhanVien nv = new NhanVien();
            nv.Id = Guid.NewGuid();
            nv.Ten = Ten;
            nv.Tuoi = Tuoi;
            nv.Role = Role;
            nv.Email = Email;
            nv.Luong = Luong;
            nv.TrangThai = Trangthai;
            return irepos.CreateItem(nv);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id, string Ten, int Tuoi, int Role, string Email, int Luong, bool Trangthai)
        {
            var nv = irepos.GetAll().First(c => c.Id == id);
            nv.Id = id;
            nv.Ten = Ten;
            nv.Tuoi = Tuoi;
            nv.Role = Role;
            nv.Email = Email;
            nv.Luong = Luong;
            nv.TrangThai = Trangthai;
            return irepos.UpdateItem(nv);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var nv = context.NhanViens.Find(id);
            return irepos.DeleteItem(nv);
        }
    }
}
