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

        public List<BiodataViewModel>? GetAllFilter(string stringSearch)
        {
            try
            {
                var apiResponse = httpClient.GetStringAsync($"{apiMaster}/Biodata/Search?pageNum=1&rows=2&search={stringSearch}").Result;
                var responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
                return JsonConvert.DeserializeObject<List<BiodataViewModel>>(responseResult?.Data.ToString() ?? "");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
