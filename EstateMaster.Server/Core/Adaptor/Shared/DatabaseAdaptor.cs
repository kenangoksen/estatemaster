using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.CreateTableParts;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Types;
using EstateMaster.Server.Adaptor.Types.QueryTypes;
using EstateMaster.Server.Adaptor.Types.QueryTypes.JoinParts;
using System.Collections.Generic;
using System;

namespace EstateMaster.Server.Adaptor.Shared
{

    public abstract class DatabaseAdaptor: IDatabaseAdaptor
    {

        protected IDBConnection db { get; private set; }

        public DatabaseAdaptor(IDBConnection db)
        {
            this.db = db;
        }

        public abstract void BeginTransaction();

        public abstract void CloseTransaction();

        public abstract void Commit();

        public abstract void Rollback();

        public abstract string ToSQL(IAlterTable item);

        public abstract string ToSQL(List<ColumnItem> columns);

        public abstract string ToSQL(IAddColumn item);

        public abstract string ToSQL(IAddIndex item);

        public abstract string ToSQL(IAddUniqueIndex item);

        public abstract void ChangeColumn(IChangeColumn item);

        public abstract string ToSQL(IDropColumn item);

        public abstract void DropForeignKey(IDropForeignKey item);

        public abstract string ToSQL(IDropIndex item);

        public abstract void DropPrimaryKey(IDropPrimaryKey item);

        public abstract void ModifyColumn(IModifyColumn item);

        public abstract string ToSQL(IRenameIndex item);

        public abstract string ToSQL(IAddConstraint item);

        public abstract string ToSQL(IRenameTable item);

        public abstract void Execute(string sql);

        public abstract string ToSQL(ICreateTable item);

        public abstract string ToSQL(ICreateDefinitionPart item);

        public abstract string ToSQL(IColumn item);

        public abstract string ToSQL(IPrimaryKey item);

        public abstract string ToSQL(IAddPrimaryKey item);

        public abstract string ToSQL(IDefaultCharacterSet item);

        public abstract string ToSQL(IDefaultCollate item);

        public abstract string ToSQL(ICreateDatabase item);

        public abstract string ToSQL(List<dynamic> definitions, string endOfLine);

        public abstract void DropDatabase(IDropDatabase item);

        public abstract string ToSQL(IDropTable item);

        public abstract string ToSQL(JoinCondition item, Dictionary<string, dynamic> parameters);

        public abstract string ToSQL(LogicTypes? item);

        public abstract string ToSQL(ConditionTypes item);

        public abstract string ToSQL(JoinTypes item);

        public abstract string ToSQL(ICharacterSet item);

        public abstract string ToSQL(ICollate item);

        public abstract string ToSQL(IEngine item);

        public abstract string ToSQL(List<JoinCondition> items, Dictionary<string, dynamic> parameters);

        public abstract string ToSQL(Join item, Dictionary<string, dynamic> parameters);

        public abstract string ToSQL(List<Join> items, Dictionary<string, dynamic> parameters);

        public abstract string ToSQL(Dictionary<string, Query> subQueries, Dictionary<string, dynamic> parameters);

        public abstract CompiledQueryItem ToSQL(Query query);

        public abstract void CreateBasicTable(string tableName);

        public abstract string IsExists(string schema);

        public abstract List<Dictionary<string, dynamic>> Query(string sql, Dictionary<string, dynamic> arguments = null);

        public abstract List<ForeignKeyItem> GetAllForignKeys(string schema);

        public abstract List<ConstraintItem> GetSystemForignKeys(string schema);

        public abstract List<ForeignKeyItem> GetUserForignKeys(string schema);

        public abstract List<StoredProcedureItem> GetProcedures(string schema, StoredProcedureTypes type);

        public abstract string GetStoredProcedureDetailAsQuery(string schema, string name);

        public abstract List<TriggerItem> GetTriggers(string schema, TriggerTypes? eventType, TriggerTimeTypes? timeType, string tableName);

        public abstract string GetTriggerDetail(string schema, string name);

        public abstract List<string> GetSchemas();

        public abstract List<string> GetIndexNames(string schema, string tableName, string columnName);

        public abstract string GetDeleteRowsSQL(string tableName, string key, dynamic value);

        public abstract void AddNode(string table, int right);

        public abstract void DeleteNode(string table, int left, int right);

        public abstract List<TableItem> GetUserDefinedTables(string schema);

        public abstract List<ColumnItem> GetTableColumns(string schemaName, string tableName);

        public abstract Dictionary<string, dynamic> Find(string table, string key, string value);

        public abstract Dictionary<string, dynamic> Find(string table, string key, dynamic value);

        public abstract long Insert(
            string table, 
            Dictionary<string, dynamic> row, 
            AutoIncrementTypes autoIncrementType = AutoIncrementTypes.ON
        );

        public abstract void Insert(
            string table, 
            List<Dictionary<string, dynamic>> rows, 
            AutoIncrementTypes autoIncrementType = AutoIncrementTypes.ON
        );

        public abstract void Update(string table, string key, dynamic value, Dictionary<string, dynamic> row);

        public abstract void Delete(string table, List<Where> wheres);

        public abstract void DeleteForce(string table, List<Where> wheres);

        public abstract string InsertAsQuery(
            string table, 
            Dictionary<string, dynamic> row, 
            AutoIncrementTypes autoIncrementType = AutoIncrementTypes.ON
        );

        public abstract string UpdateAsQuery(string table, string key, dynamic value, Dictionary<string, dynamic> row);

        public abstract bool IsDefined(string table, string field, dynamic value);

        public abstract bool IsHasRecord(string table);

        public abstract string GetLastSQL();

        public abstract List<ColumnItem> GetAllColumns(string schema);

        public abstract List<TableSizeInformation> GetTableInformations(string schema, string tableName = null);

        public abstract List<TableRelationshipItem> GetTableRelations(string schema);

        public abstract List<IndexItem> GetUniqueIndexesByTable(string tableName);

        public abstract void Update(string table, List<Where> wheres, Dictionary<string, dynamic> row);

        public abstract void ExecuteScript(string content);

        public abstract string GetMainDeleteSQL();

        public abstract string GetDeleteWhereSQL();

        public abstract string GetInnerJoinSQL();

        public abstract string GetPrimaryKeySelect();

        public abstract string GetRelationKeySQL();

        public abstract AdaptorTypes GetAdaptorType();

        public abstract List<IndexItem> GetUserDefinedIndexes(string schema);

        public abstract List<IndexItem> GetUserDefinedUniqueIndexes(string schema);

        public abstract List<TableItem> GetTables(string schema);

        public abstract List<DataTypes> GetSupportedDataTypes();

        public abstract string ToSQL(IQueryWhereSide whereSide, Dictionary<string, dynamic> parameters);

        public abstract TableItem GetUserDefinedTable(string schema, string name);

        public abstract ColumnItem GetUserDefinedTableColumn(string schema, string tableName, string name);

        public abstract List<ColumnItem> GetUserDefinedColumns(string schema);

        public void DisposeAll()
        {
            db.DisposeAll();
        }

        public abstract string AddBITField(CreateBITField item);

        public abstract void DropAndCreateStoreProcedures();

        public abstract void ModifyColumnAsTimeStamp(IChangeColumnSpecial item);
    }

}
