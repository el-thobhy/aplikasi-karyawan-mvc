namespace aplikasi_karyawan_fe_mvc.AddOns
{
    public class Pagination<T> : List<T>
    {
        public int PageNum { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalData { get; set; }
        public bool HasPreviousPage => PageNum > 1;
        public bool HasNextPage => PageNum < TotalPages;
        public Pagination(List<T> pageData, int totalPages, int pageNum)
        {
            PageNum = pageNum;
            TotalPages = totalPages;

            AddRange(pageData);
        }

        public static Pagination<T> Create(List<T> data, int totalPages, int pageNum)
        {
            return new Pagination<T>(data, totalPages, pageNum);
        }
    }
}