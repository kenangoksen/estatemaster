using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Shared;
using EstateMaster.Server.Adaptor.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstateMaster.Server.Adaptor
{

    /// <summary>
    /// Veri tabanı üzerinde fiziksel değişiklikler (alan ekleme, silme vb.) 
    /// yapabilmek için kullanılır.
    /// </summary>
    public class DDL
    {

        private IDatabaseAdaptor adaptor { get; set; }

        public DDL(IDatabaseAdaptor adaptor)
        {
            this.adaptor = adaptor;
        }

        public AdaptorTypes GetAdaptorType()
        {
            return adaptor.GetAdaptorType();
        }

        /// <summary>
        /// Var olan bir tablo üzerinde fiziksel değişiklikler yapmak için kullanılır.
        /// </summary>
        /// <param name="command"></param>
        public void Execute(IAlterTable command)
        {
            string sql = adaptor.ToSQL(command);
            adaptor.Execute(sql);
        }

        public void Execute(CreateBITField item)
        {
            string sql = adaptor.AddBITField(item);
            adaptor.Execute(sql);
        }

        /// <summary>
        /// Fiziksel olarak yeni bir tablo oluşturmak için kullanılır.
        /// </summary>
        /// <param name="command"></param>
        public void Execute(ICreateTable command)
        {
            string sql = adaptor.ToSQL(command);
            adaptor.Execute(sql);
        }

        /// <summary>
        /// Fiziksel olarak yeni bir veri tabanı oluşturmak için kullanılır.
        /// </summary>
        /// <param name="command"></param>
        public void Execute(ICreateDatabase command)
        {
            string sql = adaptor.ToSQL(command);
            adaptor.Execute(sql);
        }

        /// <summary>
        /// Drop database işlemi
        /// </summary>
        /// <param name="command"></param>
        public void Execute(IDropDatabase command)
        {
            adaptor.DropDatabase(command);
        }

        /// <summary>
        /// Fiziksel bir tabloyu silme işlemi.
        /// </summary>
        /// <param name="command"></param>
        public void Execute(IDropTable command)
        {
            string sql = adaptor.ToSQL(command);
            adaptor.Execute(sql);
        }

        public void Execute(IRenameTable command)
        {
            string sql = adaptor.ToSQL(command);
            adaptor.Execute(sql);
        }

        public void Execute(IChangeColumn command)
        {
            adaptor.ChangeColumn(command);
        }

        public void Execute(IAddIndex command)
        {
            string sql = adaptor.ToSQL(command);
            adaptor.Execute(sql);
        }

        public void Execute(IDropIndex command)
        {
            string sql = adaptor.ToSQL(command);
            adaptor.Execute(sql);
        }

        public void Execute(IModifyColumn command)
        {
            adaptor.ModifyColumn(command);
        }

        public void DropAndCreateStoreProcedures()
        {
            adaptor.DropAndCreateStoreProcedures();
        }

        public void ModifyColumnAsTimeStamp(IChangeColumnSpecial command)
        {
            adaptor.ModifyColumnAsTimeStamp(command);
        }

        public void Execute(IDropForeignKey command)
        {
            adaptor.DropForeignKey(command);
        }

        public void Execute(IAddUniqueIndex command)
        {
            string sql = adaptor.ToSQL(command);
            adaptor.Execute(sql);
        }

        public void Execute(IDropPrimaryKey command)
        {
            adaptor.DropPrimaryKey(command);
        }

        /// <summary>
        /// Temel componentleri içeren bir tablo oluşturulur.
        /// </summary>
        /// <param name="tableName"></param>
        public void CreateBasicTable(string tableName)
        {
            adaptor.CreateBasicTable(tableName);
        }

        /// <summary>
        /// Şema üzerinde bulunan tabloların listesi.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public List<TableItem> GetTables(string schema)
        {
            return adaptor.GetTables(schema);
        }

        /// <summary>
        /// Şema üzerinde bulunan kullanıcı tabloları listesi
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public List<TableItem> GetUserDefinedTables(string schema)
        {
            return adaptor.GetUserDefinedTables(schema);
        }

        public TableItem GetUserDefinedTable(string schema, string name)
        {
            return adaptor.GetUserDefinedTable(schema, name);
        }

        public List<ColumnItem> GetAllColumns(string schema)
        {
            return adaptor.GetAllColumns(schema);
        }

        /// <summary>
        /// Tablo sütunlarını listeleme işlemi.
        /// </summary>
        /// <param name="schemaName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<ColumnItem> GetTableColumns(string schemaName, string tableName)
        {
            return adaptor.GetTableColumns(schemaName, tableName);
        }

        /// <summary>
        /// Şema veri tabanı üzerinde bulunuyor mu?
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public bool IsExists(string schema)
        {
            string sql = adaptor.IsExists(schema);
            List<Dictionary<string, dynamic>> items = adaptor.Query(sql);
            return items.Count > 0;
        }

        /// <summary>
        /// Sistem tabloları arasındaki foreign key tanımları öğrenilir.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public List<ConstraintItem> GetSystemForignKeys(string schema)
        {
            return adaptor.GetSystemForignKeys(schema);
        }

        /// <summary>
        /// Kullanıcı tarafından oluşturulan tabloların foreing key bilgileri öğrenilir.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public List<ForeignKeyItem> GetUserForignKeys(string schema)
        {
            return adaptor.GetUserForignKeys(schema);
        }

        /// <summary>
        /// Stored procedure ya da fonksiyonların görüntülenmesi işlemi.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<StoredProcedureItem> GetProcedures(string schema, StoredProcedureTypes type)
        {
            return adaptor.GetProcedures(schema, type);
        }

        /// <summary>
        /// Stored procedure ya da Function script detayını getirir.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetStoredProcedureDetail(string schema, string name)
        {
            return adaptor.GetStoredProcedureDetailAsQuery(schema, name);
        }

        /// <summary>
        /// Şema üzerinde kayıtlı olan triggerların listesi alınır.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="eventType"></param>
        /// <param name="timeType"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<TriggerItem> GetTriggers(string schema, TriggerTypes? eventType, TriggerTimeTypes? timeType, string tableName)
        {
            return adaptor.GetTriggers(schema, eventType, timeType, tableName);
        }

        /// <summary>
        /// Trigger içeriğini getir.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetTriggerDetail(string schema, string name)
        {
            return adaptor.GetTriggerDetail(schema, name);
        }

        /// <summary>
        /// Veri tabanı üzerinde bulunan şemaları getirir.
        /// </summary>
        /// <returns></returns>
        public List<string> GetSchemas()
        {
            return adaptor.GetSchemas();
        }

        public List<ForeignKeyItem> GetAllForignKeys(string schema = null)
        {
            return adaptor.GetAllForignKeys(schema);
        }

        public List<TableSizeInformation> GetTableInformations(string schema)
        {
            return adaptor.GetTableInformations(schema);
        }

        public List<TableSizeInformation> GetTableInformations(string schema, string tableName)
        {
            return adaptor.GetTableInformations(schema, tableName);
        }

        public List<TableRelationshipItem> GetTableRelations(string schema)
        {
            return adaptor.GetTableRelations(schema);
        }

        public List<IndexItem> GetUniqueIndexesByTable(string tableName)
        {
            return adaptor.GetUniqueIndexesByTable(tableName);
        }

        public List<IndexItem> GetUserDefinedIndexes(string schema)
        {
            return adaptor.GetUserDefinedIndexes(schema);
        }

        /// <summary>
        /// Nested List Model yapısına sahip bir tabloya yeni bir nod ekleme işlemi.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="right"></param>
        public void AddNode(string table, int right)
        {
            adaptor.AddNode(table, right);
        }

        /// <summary>
        /// Nested List Model yapısına sahip bir tablodan bir node silme işlemi.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void DeleteNode(string table, int left, int right)
        {
            adaptor.DeleteNode(table, left, right);
        }

        public List<IndexItem> GetUserDefinedUniqueIndexes(string schema)
        {
            return adaptor.GetUserDefinedUniqueIndexes(schema);
        }

        public ColumnItem GetUserDefinedTableColumn(string schema, string tableName, string name)
        {
            return adaptor.GetUserDefinedTableColumn(schema, tableName, name);
        }

        public List<ColumnItem> GetUserDefinedColumns(string schema)
        {
            return adaptor.GetUserDefinedColumns(schema);
        }

    }

}
