using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers
{
    public enum CultureError
    {

        /// <summary>
        /// {name} tablosu daha önce tanımlanmış!
        /// </summary>
        TABLE_DEFINED = 1000,

        /// <summary>
        /// Kullanıcı tablosu daha önce belirlenmiş: {name}
        /// </summary>
        USER_TABLE_DEFINED = 1001,

        /// <summary>
        /// Bu kullanıcı tablosu üzerinde en az bir tane tekil alan bulunmak zorundadır!
        /// </summary>
        USER_TABLE_SINGULAR_FIELD = 1002,

        /// <summary>
        /// Tablo bulunamadı!
        /// </summary>
        TABLE_NOT_FOUND = 1003,

        /// <summary>
        /// İçeri aktarılan bir tablo için bu işlem geçersizdir.
        /// </summary>
        INVALID_FOR_IMPORTED_TABLE = 1004,

        /// <summary>
        /// Geçersiz bir liste bulundu : {0}
        /// </summary>
        INVALID_LIST_FOUND = 1005,

        /// <summary>
        /// {0} kodu daha önce kullanılmış.
        /// </summary>
        USED_CODE = 1006,

        /// <summary>
        /// Parolalar uyumşuyor.
        /// </summary>
        INCOMPATIBLE_PASSWORD = 1007,

        /// <summary>
        /// E-posta adresi başka bir kullanıcı tarafından kullanılıyor!
        /// </summary>
        USED_MAIL = 1008,

        /// <summary>
        /// Kullanıcı adı başka bir kullanıcı tarafından kullanılıyor!
        /// </summary>
        USED_USERNAME = 1009,

        /// <summary>
        /// {} kullanıcısı bulunamadı.
        /// Düzeltme: Güvenlik önlemleri gereği bu bilgiyi artık vermiyoruz.
        /// </summary>
        USER_NOT_FOUND = 1010,

        /// <summary>
        /// Geçersiz kod gönderdiniz: {0}
        /// </summary>
        INVALID_CODE = 1011,

        /// <summary>
        /// {0} kodu başka bir stilde kullanılıyor!
        /// </summary>
        CODE_USED_ANOTHER_STYLE = 1012,

        /// <summary>
        /// {0} alan adı rezerve edildiği için kullanılamaz!
        /// </summary>
        FIELD_NAME_RESERVED = 1013,

        /// <summary>
        /// Kod alanı zorunludur!
        /// </summary>
        CODE_REQUIRED = 1014,

        /// <summary>
        /// Ana formul daha önce tanımlanmış!
        /// </summary>
        MAIN_FORMULA_DEFINED = 1015,

        /// <summary>
        /// Kayıt bulunamadı!
        /// </summary>
        NOT_FOUND = 1016,

        /// <summary>
        /// Eksik bilgi gönderdiniz!
        /// </summary>
        MISSING_INFO = 1017,

        /// <summary>
        /// Yalnızca bir liste verisi varsayılan olarak seçilebilir.
        /// </summary>
        ONE_LIST_DATA_DEFAULT = 1018,

        /// <summary>
        /// Geçersiz reference seçimi!
        /// </summary>
        INVALID_REFERENCE = 1019,

        /// <summary>
        /// Geçersiz ana liste seçimi!
        /// </summary>
        INVALID_MAIN_LIST = 1020,

        /// <summary>
        /// Sadece bir tane dosya seçebilirsiniz!
        /// </summary>
        ONLY_ONE_FILE = 1021,

        /// <summary>
        /// {0} dosyası başka bir yerde kullanılıyor!
        /// </summary>
        USED_FILE = 1022,

        /// <summary>
        /// Sistem metot adı geçerli değil: {0}
        /// </summary>
        INVALID_SYSTEM_METHOD = 1023,

        /// <summary>
        /// Bu bağlantı daha önceden tanımlanmış.
        /// </summary>
        LINK_DEFINED = 1024,

        /// <summary>
        /// Metot parametreleri uyuşmuyor.
        /// </summary>
        METHOD_PARAMETERS_NOT_MATCH = 1025,

        /// <summary>
        /// LiveWorld yönetim veri tabanını içeri aktaramazsınız!
        /// </summary>
        LW_DB_NOT_IMPORTING = 1026,

        /// <summary>
        /// Enjekte olunacak şema bulunamadı.
        /// </summary>
        NOT_FOUND_INJECTED_SCHEMA = 1027,

        /// <summary>
        /// {0} dosyası bulunamadı!
        /// </summary>
        FILE_NOT_FOUND = 1028,

        /// <summary>
        /// {0} şeması kullanılıyor!
        /// </summary>
        USED_SCHEMA = 1029,

        /// <summary>
        /// İçeri aktarılmış olan projeleri silemezsiniz.
        /// </summary>
        CANT_REMOVE_PROJECT = 1030,

        /// <summary>
        /// Bu alan tekil bir grup içinde bulunuyor!
        /// </summary>
        FIELD_IN_THE_SINGULAR_GROUP = 1031,

        /// <summary>
        /// En az 2 tane alan seçimi zorunludur.
        /// </summary>
        MIN_TWO_SELECTION = 1032,

        /// <summary>
        /// Tekil olarak işaretlenmiş bir alanı bir tekil grup içerisine dahil edemezsiniz!
        /// </summary>
        SINGULAR_NOT_IN_SINGULAR = 1033,

        /// <summary>
        /// Kilitli wizard üzerinde değişiklik yapılamaz!
        /// </summary>
        ERR_LOCKED_WIZARD = 1034,

        /// <summary>
        /// Hiç alan seçilmemiş.
        /// </summary>
        FIELD_NOT_SELECTED = 1035,

        /// <summary>
        /// Belirttiğiniz görünüm türü bulunamadı.
        /// </summary>
        VIEW_TYPE_NOT_FOUND = 1036,

        /// <summary>
        /// İçeri aktarılan bir alan tipi için bu işlem geçersizdir.
        /// </summary>
        INVALID_FOR_IMPORTED_FIELD_TYPES = 1037,

        /// <summary>
        /// {0} koduna sahip alan tipi tanımlı değil.
        /// </summary>
        UNDEFINED_FIELD_TYPE = 1038,

        /// <summary>
        /// {0} componenti düzenlenemez!
        /// </summary>
        NONEDITABLE_COMPONENT = 1039,

        /// <summary>
        /// Bir Tip Yapısı için boyut girmek zorunludur.
        /// </summary>
        REQUIRED_LENGTH_OF_TYPE = 1040,

        /// <summary>
        /// İlişkili parametre türü bulunamadı: {0}
        /// </summary>
        RELATIONAL_PARAMETER_NOT_FOUND = 1041,

        /// <summary>
        /// Özel wizard olarak belirlenen wizardlar formlarda kullanılamaz. Örnek: Oturum Açma, Kayıt Olma vb.
        /// </summary>
        REQUIRED_SPECIAL_WIZARD_RULE = 1042,

        /// <summary>
        /// {0} isminde bir komut daha önce kaydedilmiş.
        /// </summary>
        USED_COMMAND = 1044,

        /// <summary>
        /// DLL metot türü bulunamadı: {0}
        /// </summary>
        DLL_METHOD_NOT_FOUND = 1045,

        /// <summary>
        /// Birden fazla sistem metodu bağlantısı mevcut: {0}
        /// </summary>
        TOO_MANY_SYSTEM_METHODS = 1046,

        /// <summary>
        /// {0} parametresi bulunamadı!
        /// </summary>
        PARAMETER_NOT_FOUND = 1047,

        /// <summary>
        /// Geçersiz liste tipi!
        /// </summary>
        INVALID_LIST_TYPE = 1048,

        /// <summary>
        /// Varsayılan dil seçimi yapılmamış!
        /// </summary>
        SELECTED_DEFAULT_LANGUAGE = 1049,

        /// <summary>
        /// Girilen liste kodu çok uzun!
        /// </summary>
        LIST_CODE_IS_TOO_LONG = 1050,

        /// <summary>
        /// Ana tablodan bir değer seçmek zorunlu.
        /// </summary>
        REQUIRED_MAIN_TABLE_VALUE_SELECTION = 1051,

        /// <summary>
        /// Ana liste değerinin seçlimesi zorunludur.
        /// </summary>
        REQUIRED_MAIN_LIST_VALUE_SELECTION = 1052,

        /// <summary>
        /// Bölge seçimi bulunamadı!
        /// </summary>
        REGION_NOT_FOUND = 1053,

        /// <summary>
        /// Şehir seçimi bulunamadı!
        /// </summary>
        CITY_NOT_FOUND = 1054,

        /// <summary>
        /// Geçersiz bir işlem gerçekleştiriniz!
        /// </summary>
        PERFORMED_INVALID_OPERATION = 1055,

        /// <summary>
        /// Ana alan bulunamadı!
        /// </summary>
        MAIN_FIELD_NOT_FOUND = 1056,

        /// <summary>
        /// Bu işlem için görünüm tipi seçmek zorunludur!
        /// </summary>
        REQUIRED_VISUAL_TYPE = 1057,

        /// <summary>
        /// 'Para Birimi Kodu' geçersiz!
        /// </summary>
        INVALID_CURRENCY_CODE = 1058,

        /// <summary>
        /// 'Tarih Formatı' geçersiz!
        /// </summary>
        INVALID_DATE_FORMAT = 1059,

        /// <summary>
        /// 'Ondalık Ayracı' için bir karakterlik bir seçim zorunludur.
        /// </summary>
        INVALID_DECIMAL_SEPARATOR = 1060,

        /// <summary>
        /// Geçersiz bir wizard seçimi gerçekleştirildi!
        /// </summary>
        INVALID_WIZARD_SEELCTION = 1061,

        /// <summary>
        /// Alan tipi bulunamadı!
        /// </summary>
        FIELD_TYPE_NOT_FOUND = 1062,

        /// <summary>
        /// Varsayılan Değer için geçerli bir veri girmek zorunludur.
        /// </summary>
        REQUIRED_DEFAULT_FIELD_VALUE = 1063,

        /// <summary>
        /// 'Tam Basamak Sayısı' için geçerli bir sayısal değer (2-4 arası) girişi zorunludur.
        /// </summary>
        INTEGER_LENGTH = 1064,

        /// <summary>
        /// E-posta adresi geçersiz: {0}
        /// </summary>
        INVALID_MAIL = 1065,

        /// <summary>
        /// 'Filtre Listesi' için seçilen liste geçerli değil.
        /// </summary>
        SELECTED_LIST_INVALID = 1066,

        /// <summary>
        /// Haftanın İlk Günü parametresi için geçerli bir değer seçilmesi zorunludur.
        /// </summary>
        FIRST_DAY_OF_WEEK_REQUIREMENT = 1067,

        /// <summary>
        /// Haftanın İlk Günü parametresi için seçilen değer geçersiz.
        /// </summary>
        FIRST_DAY_OF_WEEK_INVALID_VALUE = 1068,

        /// <summary>
        /// 'Değerden Büyük' doğrulaması için geçerli bir sayısal değer zorunludur.
        /// </summary>
        GREATER_REQUIREMENT = 1069,

        /// <summary>
        /// 'Değerden Küçük' doğrulaması için geçerli bir sayısal değer zorunludur.
        /// </summary>
        LESS_REQUIREMENT = 1070,

        /// <summary>
        /// Maske için geçerli bir şablon girmek zorunludur.
        /// </summary>
        MASK_REQUIREMENT = 1071,

        /// <summary>
        /// Maksimum Uzunluk için geçerli bir sayısal değer zorunludur.
        /// </summary>
        MAX_LENGTH_REQUIREMENT = 1072,

        /// <summary>
        /// Üzerinde çalıştığınız alan tipinin boyutu, seçmiş olduğunuz maksimum alan boyutundan daha küçük.
        /// </summary>
        LESS_THAN_MAX_LENGTH = 1073,

        /// <summary>
        /// Minumum Uzunluk için geçerli bir sayısal değer zorunludur.
        /// </summary>
        MAX_LENGTH_INTEGER_REQUIREMENT = 1074,

        /// <summary>
        /// Satır Sayısı özelliği için geçerli bir sayısal değer zorunludur.
        /// </summary>
        ROW_COUNT_INTEGER_REQUIREMENT = 1075,

        /// <summary>
        /// 'Değişiklik Olayı Tetiklemesi' için geçersiz bir veri seçtiniz.
        /// </summary>
        ON_CHANGE_INVALID_VALUE = 1076,

        /// <summary>
        /// Sadece ID ve tekil alanlar için Kayıt Getirme Kutusu özelliği aktif edilebilir.
        /// </summary>
        ID_SINGULAR_FIELD_CALL_RECORD_ACTIVE = 1077,

        /// <summary>
        /// Regex Karakter kontrolü için geçerli bir şablon girmek zorunludur.
        /// </summary>
        REGEX_CHARACTER_REQUIREMENT = 1078,

        /// <summary>
        /// Regex String için geçerli bir şablon girmek zorunludur.
        /// </summary>
        REGEX_STRING_REQUIREMENT = 1079,

        /// <summary>
        /// Liste verisi geçersiz ({0}):  {1}
        /// </summary>
        LIST_DATA_NOT_VALID = 1080,

        /// <summary>
        /// Liste verisi kayıtlı değil ({0}): {1}
        /// </summary>
        LIST_DATA_NOT_REGISTERED = 1081,

        /// <summary>
        /// Geçersiz değer seçtiniz: {0}
        /// </summary>
        INVALID_VALUE = 1082,

        /// <summary>
        /// Bu liste üzerinde TÜMÜ seçimi yapılamaz: {0}
        /// </summary>
        CANNOT_ALL_SELECTION = 1083,

        /// <summary>
        /// Bu liste üzerinde HİÇBİRİ seçimi yapılamaz: {0}
        /// </summary>
        CANNOT_NONE_SELECTION = 1084,

        /// <summary>
        /// Liste verisi kayıtlı değil ({0}): {1}
        /// </summary>
        LIST_VALUE_NOT_REGISTERED = 1085,

        /// <summary>
        /// Kayıt yapılacak wizard üzerinde Primary Key olarak tanımlı alan bulunmak zorundadır.
        /// </summary>
        WIZARD_PRIMARY_KEY_REQUIREMENT = 1086,

        /// <summary>
        /// Çoklu seçim alanları Gizli olarak işaretlenemez!
        /// </summary>
        MULTIPLE_FIELD_NOT_CHECK_HIDDEN = 1087,

        /// <summary>
        /// İlişkili alan verisi ilişkili tabloda bulunamadı: [{0}] => {1}
        /// </summary>
        RELATED_FIELD_DATA_NOT_FOUND = 1088,

        /// <summary>
        /// Kayıt Getirme Kutusu bulunan wizardlarda ID alanının bulunması zorunludur.
        /// </summary>
        RECORD_BOX_IN_WIZARD_ID_REQUIRED = 1089,

        /// <summary>
        /// Girilen değer sayısal değil: {value}
        /// </summary>
        VALUE_IS_NOT_NUMERIC = 1090,

        /// <summary>
        /// Görünüm türü geçersiz: {visualType}
        /// </summary>
        INVALID_VISUAL_TYPE = 1091,

        /// <summary>
        /// Bu bir liste wizardı değil: {0}
        /// </summary>
        NOT_WIZARD = 1092,

        /// <summary>
        /// Şart alanı değeri null olarak gönderilemez: {0}
        /// </summary>
        CONDITION_VALUE_NOT_NULL = 1093,

        /// <summary>
        /// Liste wizardına en az bir tablo bağlanması zorunludur: [{0}] {1}
        /// </summary>
        LIST_WIZARD_LINK_TABLE_REQUIREMENT = 1094,

        /// <summary>
        /// Bu referans alanı {count} adet component üzerinde kullanılmaktadır.
        /// </summary>
        REFERENCE_COMPONENT_RELATION_COUNT = 1095,

        /// <summary>
        /// İçeri aktarılan alan için bu işlem geçersizdir.
        /// </summary>
        INVALID_PROCESS_IMPORTED_FIELD = 1096,

        /// <summary>
        /// Indexlenmemiş ya da İVT olarak işaretlenmemiş bir alanı ilişkili alan olarak tanımlayamazsınız.
        /// </summary>
        INDEX_OR_RDB_NOT_REGISTER_RELATED = 1097,

        /// <summary>
        /// ID alanı üzerinde bu işlemi gerçekleştiremezsiniz.
        /// </summary>
        CANNOT_DO_THAT_ON_ID = 1098,

        /// <summary>
        /// Bu alanı silemezsiniz.
        /// </summary>
        CANNOT_REMOVE_THAT_FIELD = 1099,

        /// <summary>
        /// Tekil alanlar için index tanımı kaldırılamaz.
        /// </summary>
        CANNOT_REMOVE_INDEX_SINGULAR_FIELDS = 1100,

        /// <summary>
        /// Bu alan için Index tanımı bulunmuyor.
        /// </summary>
        NOT_FOUND_INDEX_THAT_FIELD = 1101,

        /// <summary>
        /// Tekil alanlar için index tanımı zaten bulunmaktadır.
        /// </summary>
        INDEX_AVAILABLE_INDEX_SINGULAR_FIELDS = 1102,

        /// <summary>
        /// Bu alan için Index tanımı mevcut.
        /// </summary>
        INDEX_AVAILABLE_THIS_FIELD = 1103,

        /// <summary>
        /// Başka bir wizard Oturum Aç wizardı olarak belirlenmiş: [{0}] {1}
        /// </summary>
        ANOTHER_WIZARD_DEFINED_LOGIN_WIZARD = 1104,

        /// <summary>
        /// Bu wizard başka formlar üzerinde kullanılıyor.
        /// </summary>
        THIS_WIZARD_USED_ANOTHER_FORMS = 1105,

        /// <summary>
        /// Başka bir wizard Kullanıcı Kaydı wizardı olarak belirlenmiş: [{0}] {1}
        /// </summary>
        ANOTHER_WIZARD_DEFINED_REGISTER_WIZARD = 1106,

        /// <summary>
        /// Liste türündeki wizardlar için sadece bir adet tablo seçebilirsiniz!
        /// </summary>
        ONLY_ONE_SELECTION_FOR_LIST_WIZARDS = 1107,

        /// <summary>
        /// Değer maskeye uymuyor ({0}): {1}
        /// </summary>
        MASK_VALUE_NOT_MATCH = 1108,

        /// <summary>
        /// Komut bulunamadı: {0}
        /// </summary>
        COMMAND_NOT_FOUND = 1109,

        /// <summary>
        /// Geçersiz bir ana grup seçimi!
        /// </summary>
        INVALID_GROUP_SELECTION = 1110,

        /// <summary>
        /// Proje seçimi geçersiz!
        /// </summary>
        INVALID_PROJECT_SELECTION = 1111,

        /// <summary>
        /// Bu alan tip manuel olarak tabloya eklenemez: {0}
        /// </summary>
        THIS_FIELD_TYPE_NOT_ADD_TABLE = 1112,

        /// <summary>
        /// Kullanıcı Aktifleştirilmedi: {0}. Lütfen yetkilendirme için Proje Yöneticiniz ile irtibata geçiniz.
        /// </summary>
        USER_NOT_ACTIVATED = 1113,

        /// <summary>
        /// Bu işlem için yetkiniz bulunmuyor: {0}
        /// </summary>
        UNAUTHORIZED = 1114,

        /// <summary>
        /// Bir parola alanı seçmek zorundasınız!
        /// </summary>
        PASSWORD_FIELD_MUST_BE_SELECTED = 1115,

        /// <summary>
        /// Kullanıcı tablonun parola alanını silemezsiniz.
        /// </summary>
        CANNOT_DELETE_USER_PASSWORD_FIELD = 1116,

        /// <summary>
        /// Bu servis zaten tanımlı.
        /// </summary>
        SERVICE_ALREADY_DEFINED = 1117,

        /// <summary>
        /// Bu işlem şu an arka planda çalışıyor.
        /// </summary>
        PROCESS_ALREADY_RUNNING = 1118,

        /// <summary>
        /// Desteklenmeyen listeleme türü: {0}
        /// </summary>
        UNSUPPORTED_ORDER_TYPE = 1119,

        /// <summary>
        /// Seçilen proje içeri aktarılmış bir proje değil: {0}
        /// </summary>
        UNIMPORTED_PROJECT = 1120,

        /// <summary>
        /// Aradığınız değer bulunamadı: {0}
        /// </summary>
        NOT_FOUND_FIELD = 1121,

        /// <summary>
        /// Dahili bir hata oluştu: {0}
        /// </summary>
        AN_INTERNAL_ERROR = 1122,

        /// <summary>
        /// The password must be strong: {0}
        /// </summary>
        PASSWORD_MUST_BE_STRONG = 1123,

        /// <summary>
        /// Kendi kullanıcı hesabınızı silemezsiniz.
        /// </summary>
        CANNOT_DELETE_YOURSELF = 1124,

        /// <summary>
        /// Bu tablo adı kullanılamaz: {0}
        /// </summary>
        RESERVER_TABLE_NAME = 1125,

        /// <summary>
        /// Bu wizarda sadece bir tablo bağlayabilirsiniz: {0}
        /// </summary>
        ONLY_ONE_TABLE_BIND_ERROR = 1126,

        /// <summary>
        /// Bu alan primary key olarak işaretlenmelidir: {0}
        /// </summary>
        MUST_BE_PRIMARY_KEY = 1127,

        /// <summary>
        /// Bu türde wizard zaten eklenmiş. Yalnızca bir wizard ekleyebilirsiniz.
        /// </summary>
        WIZARD_ALREADY_ADDED = 1128,

        /// <summary>
        /// Bu veri zaten eklenmiş.
        /// </summary>
        ALREADY_DEFINED = 1129,

        /// <summary>
        /// Bu veri tipi için ölçek alanına veri girişi zorunludur.
        /// </summary>
        SCALE_VALUE_IS_REQUIRED = 1130,

        /// <summary>
        /// ENUM ya da SET türündeki alanlar için değer girişi zorunludur.
        /// </summary>
        ENUM_VALUES_REQUIRED = 1131,

        /// <summary>
        /// Tüm bilgiler zorunludur!
        /// </summary>
        INFORMATION_REQUIRED = 1132,

        /// <summary>
        /// Login wizardı olmadan Login işlemi gerçekleştiremezsiniz!
        /// </summary>
        LOGIN_LOGIN_WIZARD_REQUIRED = 1133,

        /// <summary>
        /// Login wizardına sadece bir tablo bağlanabilir!
        /// </summary>
        LOGIN_TABLE_COUNT = 1134,

        /// <summary>
        /// Login wizardı için belirlenen tablolar arasında kullanıcı tablosu bulunamadı!
        /// </summary>
        USER_TABLE_REQUIRED = 1135,

        /// <summary>
        /// Parola alanı olmadan login işlemi gerçekleştirilemez!
        /// </summary>
        NO_PASSWORD_FIELD = 1136,

        /// <summary>
        /// Login işlemi için en az iki alana ihtiyaç var!
        /// </summary>
        LOGIN_FIELDS_REQUIRED = 1137,

        /// <summary>
        /// Login alanları tekil olmalı ve kullanıcı tablosu içerisinde bulunmalı: {0}
        /// </summary>
        LOGIN_UNIQUE_REQUIRED = 1138,

        /// <summary>
        /// Kullanıcı tablosunda en az bir alan başlık alanı olarak seçilmek zorundadır.
        /// </summary>
        USER_TABLE_TITLE_REQUIRED = 1139,

        /// <summary>
        /// Kullanıcı bulunamadı!
        /// </summary>
        NO_USER_FOUND = 1140,

        /// <summary>
        /// Login işlemi kabul edilemez. Lütfen yöneticinizle irtibata geçiniz!
        /// </summary>
        LOGIN_NOT_AVAILABLE = 1141,

        /// <summary>
        /// Detay Profil wizardı belirli değil. Lütfen sistem yöneticisiyle irtibata geçiniz.
        /// </summary>
        DETAIL_WIZARD_REQUIRED = 1142,

        /// <summary>
        /// Bu kod daha önce tanımlanmış.
        /// </summary>
        CODE_ALREADY_DEFINED = 1143,

        /// <summary>
        /// Desteklenmeyen tip seçtiniz.
        /// </summary>
        UPSUPPORTED_TYPE = 1144,

        /// <summary>
        /// Girilen değer alfanumerik değil: {0}
        /// </summary>
        ALPHANUMERIC_ERROR = 1145,

        /// <summary>
        /// Bir değer girmek zorunludur: {0}
        /// </summary>
        REQUIRED = 1146,

        /// <summary>
        /// En azından bir sütun seçimi zorunludur.
        /// </summary>
        YOU_HAVE_TO_SELECT_AT_LEAST_ONE_COLUMN = 1147,

        /// <summary>
        /// Böyle bir special zaman tanımlamamış
        /// </summary>
        NO_SPECIAL_TIME_FOUND = 1148,

        /// <summary>
        /// Zaman formatı geçersiz!
        /// </summary>
        INVALID_TIME_FORMAT = 1149,

        /// <summary>
        /// Varsayılan dil seçimi yapılmamış!
        /// </summary>
        DEFAULT_COUNTRY_NOT_FOUND = 1150,

        /// <summary>
        /// Varsayılan
        /// </summary>
        DEFAULT_DEFINITION = 1151,

        /// <summary>
        /// Veri tabanı bağlantı anında bir hata meydana geldi.
        /// </summary>
        DB_CONNECTION_ERROR = 1152,

        /// <summary>
        /// Veri tabanı ayarları geçerli değil.
        /// </summary>
        DB_OPTIONS_ARE_NOT_VALID = 1153,

        /// <summary>
        /// Bu sayfa daha önce tanımlanmış
        /// </summary>
        PAGE_ALREADY_DEFINED = 1154,

        /// {0} özel listesine bağlı liste karşılıkları ve alan tipleri mevcut. Bu bağlantılar kaldırılmadan silme işlemi gerçekleştirilemez.
        /// </summary>
        RELATED_VALUES_EXISTS_ON_LIST = 1155,

        /// <summary>
        /// Henüz çalıştırılmamış güncelleme paketi bulunuyor.
        /// </summary>
        UNEXECUTED_UPDATE_PACK_ERROR = 1156,

        /// <summary>
        /// Bu kaydı silemezsiniz!
        /// </summary>
        CANNOT_DELETE = 1157,

        /// <summary>
        /// Bu forma daha önceden ayar kaydı yapılmış.
        /// </summary>
        USED_FORM_CUSTOMIZATION_EXISTS = 1158,

        /// <summary>
        /// Zamanlı kaynağa kaynak adresi eklenmemiş.
        /// </summary>
        TIMED_SOURCE_ADDRESS_NOT_FOUND = 1159,

        /// <summary>
        /// Zamanlı kaynağa veri tablosu eklenmemiş.
        /// </summary>
        TIMED_SOURCES_TABLE_NOT_FOUND = 1160,

        /// <summary>
        /// Dev ve prod üzerinde aynı veri tabanını kullanamazsınız.
        /// </summary>
        CANNOT_USE_SAME_SCHEMA_ON_DEV_AND_PROD = 1161,

        /// <summary>
        /// Geçersiz oturum bilgisi.
        /// </summary>
        INVALID_SESSION = 1162,

        /// <summary>
        /// Geçersiz resim dosyası
        /// </summary>
        INVALID_IMAGE_FILE = 1163,

        /// <summary>
        /// Girilen değer veri tabanında sınırlanan alandan [2] daha uzun: {0}, "{1}"
        /// </summary>
        TOO_LONG_TEXT = 1164,

        /// <summary>
        /// Tablolar daha önce eşleştirilmiş.
        /// </summary>
        ALREADY_MATCHED_TABLES = 1165,

        /// <summary>
        /// Tweet gönderilmedi.
        /// </summary>
        TWEET_WAS_NOT_SENT = 1166,

        /// Geçersiz ip adresi.
        /// </summary>
        INVALID_IP_ADDRESS = 1167,

        /// <summary>
        /// Bağlı tablo seçmelisiniz.
        /// </summary>
        REQUIRED_RELATED_TABLE_SELECTION = 1168,

        /// <summary>
        /// Geçersiz web soket adresi
        /// </summary>
        INVALID_WEB_SOCKET_ADDRESS = 1169,

        /// En üst seviye menülerde form seçimi yapamazsınız.
        /// </summary>
        MENU_FORM_SELECTION_ON_ROOT_LEVEL = 1170,

        /// <summary>
        /// Form seçimi zorunludur.
        /// </summary>
        FORM_SELECTION_REQUIRED = 1171,

        /// <summary>
        /// Aynı anda hem form hem de panel seçimi yapamazsınız.
        /// </summary>
        CANT_SELECT_FORM_AND_PANEL_AT_THE_SAME_TIME = 1172,

        /// <summary>
        /// Bu işlem için öncelikle format belirlenmelidir.
        /// </summary>
        MUST_BE_DEFINED_FORMAT = 1173,

        /// <summary>
        /// Bu işlem için öncelikle formül belirlenmelidir.
        /// </summary>
        MUST_BE_DEFINED_FORMULA = 1174,

        /// <summary>
        /// Bu işlem için format ve formül belirtilmiş olmalıdır.
        /// </summary>
        MUST_BE_DEFINED_FORMAT_AND_FORMULA = 1175,

        /// <summary>
        /// Bu sorgu zaten oluşturulmuş!
        /// </summary>
        QUERY_ALREADY_DEFINED = 1176,

        /// <summary>
        /// Özel isimlendirmeleri birden fazla wizard alanı üzerinde kullanamazsınız.
        /// </summary>
        CANNOT_USE_CUSTOM_NAME_ON_MULTIPLE_WIZARD_FIELD = 1177,

        /// <summary>
        /// Geçersiz dosya uzantısı
        /// </summary>
        INVALID_FILE_EXTENSION = 1178,

        /// <summary>
        /// Virüs bulundu!
        /// </summary>
        VIRUS_FOUND_IN_FILE = 1179,

        /// <summary>
        /// Virüs tarama anında bir hata meydana geldi.
        /// </summary>
        VIRUS_SCAN_ERROR_OCCURRED = 1180,

        /// <summary>
        /// Dosya uzantısı ve Mime Type uyuşmuyor.
        /// </summary>
        INVALID_FILE_MIME_TYPE = 1181,

        /// <summary>
        /// Bu eylemi gerçekleştiremezsiniz!
        /// </summary>
        CANNOT_EXECUTE_THIS_ACTION = 1182,

        /// <summary>
        /// Sunucu isteğe olumlu yanıt vermyior.
        /// </summary>
        SERVER_NOT_RESPOND_OK = 1183,

        /// <summary>
        /// Ulaşmaya çalıştığınız sunucu Polisoft.ServiceGateway altyapısını kullanmıyor.
        /// </summary>
        IS_NOT_POLISOFT_SERVICE_GATEWAY = 1184,

        /// <summary>
        /// Servis bulunamadı: {0}
        /// </summary>
        SERVICE_NOT_FOUND = 1185
    }
}

