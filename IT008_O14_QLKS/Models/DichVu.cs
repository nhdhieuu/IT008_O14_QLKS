using System.Collections.Generic;

namespace IT008_O14_QLKS.Models
{
    public class DichVu
    {
        public List<string> _ttdichvu = new List<string>();
        public DichVu(string dichvu, string soluong)
        {
            _ttdichvu.Add(dichvu);
            _ttdichvu.Add(soluong);
        }
        

    }
}