using aplikasi_karyawan_fe_mvc.Models;
using Newtonsoft.Json;

namespace aplikasi_karyawan_fe_mvc.Services
{
    public class BiodataServices
    {
        private readonly string apiMaster;
        private readonly HttpClient httpClient = new HttpClient();

        private HttpContent content;
        private string jsonData;
        public BiodataServices(string apiMasterUrl)
        {
            apiMaster = apiMasterUrl;
        }

        public List<BiodataViewModel>? GetAll()
        {
            try
            {
                var apiResponse = httpClient.GetStringAsync($"{apiMaster}/Biodata/GetAll").Result;
                return JsonConvert.DeserializeObject<List<BiodataViewModel>>(apiResponse);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ResponseResult? GetAllFilter(string stringSearch, int pageNum, int rows)
        {
            try
            {
                var apiResponse = httpClient.GetStringAsync($"{apiMaster}/Biodata/Search?pageNum={pageNum}&rows={rows}&search={stringSearch}").Result;
                ResponseResult? responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
                return responseResult;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
