using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Responses
{
    public class TableSizeInformation
    {

        public string name { get; set; }

        /// <summary>
        /// Tablo içerisinde bulunan satır sayısı
        /// </summary>
        public Int64 rowCount { get; set; }

        /// <summary>
        /// Tablonun veri büyüklüğü
        /// </summary>
        public Int64 size { get; set; }

        /// <summary>
        /// Veri içerikleri ay nı mı?
        /// </summary>
        public bool isSame { get; set; }

        /// <summary>
        /// Kayıtlar hedef tabloya aktarıldı mı?
        /// </summary>
        public bool isInserted { get; set; }

        /// <summary>
        /// Aktarma işlemlerinde Foreign Key sorunu çıkabiliyor. Bu nedenle
        /// ilgili tablonun nerelerle ilişkisi olduğunun tespit edilmesi 
        /// gerekiyor. Kayıt ekleme anında önce tüm ilişkiler ekleniyor,
        /// daha sonra kendisi ekleniyor. Bu değişken ilgili tablonun
        /// ilişki bilgisini tutmaktadır.
        /// </summary>
        public List<string> relations { get; set; }

        /// <summary>
        /// Kayıt ekleme ve silme anında hangi sütuna göre bu işlemler 
        /// yapılacak bilmemiz gerekiyor. Bu nedenle ilgili tablonun
        /// primary key alanını bu değişken aracılığı ile tutuyoruz.
        /// </summary>
        public string primaryKeyColumn { get; set; }

        public TableSizeInformation()
        {
            isSame = true;
            isInserted = false;
            relations = new List<string>();
        }

        public static TableSizeInformation MySQLConverter(Dictionary<string, dynamic> item)
        {
            return new TableSizeInformation()
            {
                name = item["TABLE_NAME"],
                rowCount = ToInt64(item["TABLE_ROWS"]),
                size = ToInt64(item["TABLE_SIZE"]),
                primaryKeyColumn = item["PRIMARY_KEY"]
            };
        }

        public static TableSizeInformation MSSQLConverter(Dictionary<string, dynamic> item)
        {
            return new TableSizeInformation()
            {
                name = item["TABLE_NAME"],
                rowCount = ToInt64(item["TABLE_ROWS"]),
                size = ToInt64(item["TABLE_SIZE"]),
                primaryKeyColumn = item["PRIMARY_KEY"]
            };
        }

        private static Int64? ToInt64(dynamic value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return Convert.ToInt64(value);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
