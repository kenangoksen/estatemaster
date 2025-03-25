using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.CreateTableParts;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Types;
using EstateMaster.Server.Adaptor.Types.QueryTypes;
using EstateMaster.Server.Adaptor.Types.QueryTypes.JoinParts;
using System.Collections.Generic;

namespace EstateMaster.Server.Adaptor.Shared
{

    public interface IDatabaseAdaptor
    {

        AdaptorTypes GetAdaptorType();

        List<DataTypes> GetSupportedDataTypes();

        void BeginTransaction();

        void CloseTransaction();

        void Commit();

        void Rollback();

        string GetLastSQL();

        void Execute(string sql);

        void ExecuteScript(string content);

        List<Dictionary<string, dynamic>> Query(string sql, Dictionary<string, dynamic> arguments = null);

        string ToSQL(IAlterTable item);

        string ToSQL(ICreateTable item);

        string ToSQL(List<dynamic> definitions, string endOfLine);

        string ToSQL(ICreateDefinitionPart item);

        string ToSQL(IAddColumn item);

        string ToSQL(IColumn item);

        string ToSQL(IAddIndex item);

        string ToSQL(IAddUniqueIndex item);

        string ToSQL(List<ColumnItem> columns);

        void ChangeColumn(IChangeColumn item);

        string ToSQL(IDropColumn item);

        string ToSQL(IQueryWhereSide whereSide, Dictionary<string, dynamic> parameters);

        void DropForeignKey(IDropForeignKey item);

        string ToSQL(IDropIndex item);

        void DropPrimaryKey(IDropPrimaryKey item);

        void ModifyColumn(IModifyColumn item); 
        
        void DropAndCreateStoreProcedures();

        void ModifyColumnAsTimeStamp(IChangeColumnSpecial item);

        string ToSQL(IRenameIndex item);

        string ToSQL(IAddConstraint item);

        string ToSQL(IPrimaryKey item);

        string ToSQL(IDefaultCharacterSet item);

        string ToSQL(IDefaultCollate item);

        string ToSQL(ICreateDatabase item);

        void DropDatabase(IDropDatabase item);

        string ToSQL(IDropTable item);

        string ToSQL(IRenameTable item);

        string ToSQL(IAddPrimaryKey item);

        string ToSQL(ICharacterSet item);

        string ToSQL(ICollate item);

        string ToSQL(IEngine item);

        string ToSQL(JoinCondition item, Dictionary<string, dynamic> parameters);

        string ToSQL(LogicTypes? item);

        string ToSQL(ConditionTypes item);

        string ToSQL(JoinTypes item);

        string ToSQL(List<JoinCondition> items, Dictionary<string, dynamic> parameters);

        string ToSQL(Join item, Dictionary<string, dynamic> parameters);

        string ToSQL(List<Join> items, Dictionary<string, dynamic> parameters);

        string ToSQL(Dictionary<string, Query> subQueries, Dictionary<string, dynamic> parameters);

        CompiledQueryItem ToSQL(Query query);

        void CreateBasicTable(string tableName);

        string IsExists(string schema);

        List<ForeignKeyItem> GetAllForignKeys(string schema);

        List<ConstraintItem> GetSystemForignKeys(string schema);

        List<ForeignKeyItem> GetUserForignKeys(string schema);

        List<StoredProcedureItem> GetProcedures(string schema, StoredProcedureTypes type);

        string GetStoredProcedureDetailAsQuery(string schema, string name);

        List<TriggerItem> GetTriggers(string schema, TriggerTypes? eventType, TriggerTimeTypes? timeType, string tableName);

        string GetTriggerDetail(string schema, string name);

        List<string> GetSchemas();

        List<string> GetIndexNames(string schema, string tableName, string columnName);

        List<TableSizeInformation> GetTableInformations(string schema, string tableName = null);

        List<TableRelationshipItem> GetTableRelations(string schema);

        List<IndexItem> GetUniqueIndexesByTable(string tableName);

        string GetDeleteRowsSQL(string tableName, string key, dynamic value);

        void AddNode(string table, int right);

        void DeleteNode(string table, int left, int right);

        List<TableItem> GetUserDefinedTables(string schema);

        List<ColumnItem> GetUserDefinedColumns(string schema);

        List<ColumnItem> GetAllColumns(string schema);

        List<ColumnItem> GetTableColumns(string schemaName, string tableName);

        List<TableItem> GetTables(string schema);

        Dictionary<string, dynamic> Find(string table, string key, string value);

        Dictionary<string, dynamic> Find(string table, string key, dynamic value);

        long Insert(
            string table, 
            Dictionary<string, dynamic> row, 
            AutoIncrementTypes autoIncrementType = AutoIncrementTypes.ON
        );

        TableItem GetUserDefinedTable(string schema, string name);

        string InsertAsQuery(
            string table, 
            Dictionary<string, dynamic> row, 
            AutoIncrementTypes autoIncrementType = AutoIncrementTypes.ON
        );

        void Insert(
            string table, 
            List<Dictionary<string, dynamic>> rows, 
            AutoIncrementTypes autoIncrementType = AutoIncrementTypes.ON
        );

        void Update(string table, List<Where> wheres, Dictionary<string, dynamic> row);

        void Update(string table, string key, dynamic value, Dictionary<string, dynamic> row);

        string UpdateAsQuery(string table, string key, dynamic value, Dictionary<string, dynamic> row);

        void Delete(string table, List<Where> wheres);

        void DeleteForce(string table, List<Where> wheres);

        bool IsDefined(string table, string field, dynamic value);
        bool IsHasRecord(string table);

        /// <summary>
        /// DELETE {TABLE_NAME} FROM {TABLE_NAME}
        /// </summary>
        /// <returns></returns>
        string GetMainDeleteSQL();

        /// <summary>
        /// WHERE {TABLE_NAME}.{PRIMARY_KEY} IN ({VALUES})
        /// </summary>
        /// <returns></returns>
        string GetDeleteWhereSQL();

        /// <summary>
        /// INNER JOIN {MAIN_TABLE_NAME} ON {MAIN_TABLE_NAME}.{MAIN_PRIMARY_KEY} = {CHILD_TABLE}.{CHILD_PRIMARY_KEY}
        /// </summary>
        /// <returns></returns>
        string GetInnerJoinSQL();

        /// <summary>
        /// SELECT {PRIMARY_KEY}
        /// </summary>
        /// <returns></returns>
        string GetPrimaryKeySelect();

        /// <summary>
        /// FROM {TABLE} WHERE {RELATION_KEY} IN ({VALUES})
        /// </summary>
        /// <returns></returns>
        string GetRelationKeySQL();

        /// <summary>
        /// Kullanıcı tabloları için tanımlanan indexlerin listesini getirir.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        List<IndexItem> GetUserDefinedIndexes(string schema);

        /// <summary>
        /// Kullanıcı tarafından oluşturulan unique index listesi getirilir.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        List<IndexItem> GetUserDefinedUniqueIndexes(string schema);

        void DisposeAll();
        ColumnItem GetUserDefinedTableColumn(string schema, string tableName, string name);
        string AddBITField(CreateBITField item);
    }

}
