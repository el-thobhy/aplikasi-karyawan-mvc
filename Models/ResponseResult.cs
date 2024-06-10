namespace aplikasi_karyawan_fe_mvc.Models
{
    public class ResponseResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = default!;
        public List<BiodataViewModel> Data { get; set; } = default!;
        public int Pages { get; set; }
    }
}
