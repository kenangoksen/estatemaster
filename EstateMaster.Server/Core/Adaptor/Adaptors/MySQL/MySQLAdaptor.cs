using EstateMaster.Server.Adaptor.Helpers.Extensions;
using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.EnumTypes;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.CreateTableParts;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Shared;
using EstateMaster.Server.Adaptor.Types;
using EstateMaster.Server.Adaptor.Types.QueryTypes;
using EstateMaster.Server.Adaptor.Types.QueryTypes.JoinParts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq; 
using EstateMaster.Server.Adaptor.Types.QueryTypes.WhereTypes;
using EstateMaster.Server.Adaptor.Types.DDLManipulations;
using System.IO;

namespace EstateMaster.Server.Adaptor.Adaptors.MySQL
{


    public class MySQLAdaptor : DatabaseAdaptor
    {

        public MySQLAdaptor(IDBConnection db) : base(db)
        {
        }

        public override string ToSQL(IAlterTable item)
        {
            string sql = @"ALTER TABLE `{TABLE_NAME}` [SPECIFICATION] [PARTITION_OPTIONS]";
            sql = sql.Replace("{TABLE_NAME}", item.GetTableName())
                .Replace("[SPECIFICATION]", ToSQL(item.Specifications().ToList<dynamic>(), ","))
                .Replace("[PARTITION_OPTIONS]", "")
                .ClearString();

            return sql;
        }

        public override string ToSQL(IAddColumn item)
        {
            ColumnDefinationTemplate template = new ColumnDefinationTemplate(item.GetColumn());
            string sql = "ADD COLUMN {COLUMN_DEFINITION}";
            return sql.Replace("{COLUMN_DEFINITION}", template.ToSQL())
                .ClearString();
        }

        public override string AddBITField(CreateBITField item)
        {
            string sql = "ALTER TABLE `{TABLE_NAME}` ADD `{FIELD_NAME}` BIT(1) DEFAULT {DEFAULT_VALUE}";
            sql = sql.Replace("{TABLE_NAME}", item.GetTableName())
                     .Replace("{FIELD_NAME}", item.GetFieldName())
                     .Replace("{DEFAULT_VALUE}", item.GetDefaultValue())
                     .ClearString();

            return sql;
        }

        public override string ToSQL(IColumn item)
        {
            ColumnDefinationTemplate template = new ColumnDefinationTemplate(item.GetColumn());
            return template.ToSQL().ClearString();
        }

        public override string ToSQL(IAddIndex item)
        {
            string sql = "ALTER TABLE `{TABLE}` ADD INDEX `{INDEX_NAME}` (`{COLUMN_NAME}`)";
            return sql
                .Replace("{TABLE}", item.GetTableName())
                .Replace("{INDEX_NAME}", item.GetIndexName())
                .Replace("{COLUMN_NAME}", item.GetColumnName())
                .ClearString();
        }

        public override string ToSQL(IAddUniqueIndex item)
        {
            string sql = @"ALTER TABLE `{TABLE_NAME}` ADD UNIQUE INDEX `{INDEX_NAME}` ([COLUMN_NAMES])";
            return sql
                .Replace("{TABLE_NAME}", item.GetTableName())
                .Replace("{INDEX_NAME}", item.GetIndexName())
                .Replace("[COLUMN_NAMES]", ToSQL(item.GetColumns()))
                .ClearString();
        }

        public override void ChangeColumn(IChangeColumn item)
        {
            ColumnDefinationTemplate template = new ColumnDefinationTemplate(item.GetColumn());
            string sql = "ALTER TABLE `{TABLE_NAME}` CHANGE COLUMN `{OLD_NAME}` {COLUMN_DEFINITION}";
            sql = sql.Replace("{TABLE_NAME}", item.GetTableName())
                .Replace("{OLD_NAME}", item.GetOldName())
                .Replace("{COLUMN_DEFINITION}", template.ToSQL())
                .ClearString();
            db.Execute(sql);
        }

        public override string ToSQL(IDropColumn item)
        {
            string sql = "DROP COLUMN `{COLUMN_NAME}`";
            return sql
                .Replace("{COLUMN_NAME}", item.GetColumnName())
                .ClearString();
        }

        public override void DropForeignKey(IDropForeignKey item)
        {
            string sql = "ALTER TABLE `{TABLE_NAME}` DROP FOREIGN KEY `{FK_NAME}`";
            sql = sql
                .Replace("{TABLE_NAME}", item.GetTableName())
                .Replace("{FK_NAME}", item.GetName())
                .ClearString();
            db.Execute(sql);
        }

        public override string ToSQL(IDropIndex item)
        {
            string sql = "ALTER TABLE `{TABLE_NAME}` DROP INDEX `{INDEX_NAME}`";
            return sql
                .Replace("{TABLE_NAME}", item.GetTableName())
                .Replace("{INDEX_NAME}", item.GetIndexName())
                .ClearString();
        }

        public override void DropPrimaryKey(IDropPrimaryKey item)
        {
            string sql = "ALTER TABLE `{TABLE_NAME}` DROP PRIMARY KEY"
                .Replace("{TABLE_NAME}", item.GetTableName());
            db.Execute(sql);
        }

        public override void ModifyColumn(IModifyColumn item)
        {
            ColumnDefinationTemplate template = new ColumnDefinationTemplate(item.GetColumn());
            string sql = "ALTER TABLE `{TABLE_NAME}` MODIFY COLUMN {COLUMN_DEFINITION}";
            sql = sql
                .Replace("{TABLE_NAME}", item.GetTableName())
                .Replace("{COLUMN_DEFINITION}", template.ToSQL())
                .ClearString();
            db.Execute(sql);
        }

        public override string ToSQL(IRenameIndex item)
        {
            string sql = "RENAME INDEX `{OLD_INDEX_NAME}` TO `{NEW_INDEX_NAME}`";
            return sql.Replace("{OLD_INDEX_NAME}", item.GetOldName())
                .Replace("{NEW_INDEX_NAME}", item.GetNewName())
                .ClearString();
        }

        public override string ToSQL(IAddConstraint item)
        {
            string sql = @"ADD CONSTRAINT `{CONSTRAINT_NAME}`
                FOREIGN KEY (`{COLUMN_NAME}`) 
                REFERENCES `{REFERENCE_TABLE}`(`{REFERENCE_COLUMN}`) ";
            ForeignKeyItem fk = item.GetForeignKeyStruct();

            return sql
                .Replace("{CONSTRAINT_NAME}", fk.constraintName)
                .Replace("{COLUMN_NAME}", fk.main.columnName)
                .Replace("{REFERENCE_TABLE}", fk.referenced.tableName)
                .Replace("{REFERENCE_COLUMN}", fk.referenced.columnName)
                .ClearString();
        }

        public override string ToSQL(IRenameTable item)
        {
            string sql = "ALTER TABLE `{OLD_TABLE_NAME}` RENAME `{NEW_TABLE_NAME}`";
            return sql.Replace("{OLD_TABLE_NAME}", item.GetOldName())
                .Replace("{NEW_TABLE_NAME}", item.GetNewName())
                .ClearString();
        }

        public override string ToSQL(IDropTable item)
        {
            string sql = @"DROP [TEMPORARY] TABLE [IF EXISTS] `{TABLE_NAME}`";
            return sql.Replace("{TABLE_NAME}", item.GetTableName())
                .Replace("[TEMPORARY]", IsTemporary((ITemporary)item))
                .Replace("[IF EXISTS]", IsIfExists((IIfExists)item))
                .ClearString();
        }

        public override string ToSQL(List<ColumnItem> columns)
        {
            string sql = "";
            foreach (ColumnItem column in columns)
            {
                sql += "`" + column.name + "`,";
            }

            if (columns.Count() > 0)
            {
                sql = sql.Substring(0, sql.Length - 1);
            }
            return sql;
        }

        public override void Execute(string sql)
        {
            db.Execute(sql);
        }

        public override string ToSQL(ICreateTable item)
        {
            string sql = @"CREATE [TEMPORARY] TABLE [IF NOT EXISTS] `{TABLE_NAME}`
                ([DEFINITIONS])
                [OPTIONS]
                [PARTTITION_OPTIONS]";
            List<Type> optionTypes = new List<Type>()
            {
                typeof(CharacterSet),
                typeof(Collate),
                typeof(Engine)
            };

            List<ICreateDefinition> definitions = item.GetDefinitions()
                .Where(i => optionTypes.IndexOf(i.GetType()) == -1)
                .ToList();

            List<ICreateDefinition> options = item.GetDefinitions()
                .Where(i => optionTypes.IndexOf(i.GetType()) > -1)
                .ToList();

            return sql
                .Replace("[TEMPORARY]", IsTemporary((ITemporary)item))
                .Replace("[IF NOT EXISTS]", IsIfNotExists((IIfNotExists)item))
                .Replace("{TABLE_NAME}", item.GetTableName())
                .Replace("[DEFINITIONS]", ToSQL(definitions.ToList<dynamic>(), ","))
                .Replace("[OPTIONS]", ToSQL(options.ToList<dynamic>(), ","))
                .Replace("[PARTTITION_OPTIONS]", "")
                .ClearString();
        }

        public override string ToSQL(ICreateDefinitionPart item)
        {
            string sql = "";
            foreach (dynamic part in item.ToList())
            {
                sql += ToSQL(part) + ",";
            }

            if (item.Count() > 0)
            {
                sql = sql.Substring(0, sql.Length - 1);
            }
            return sql;
        }

        private string IsIfNotExists(IIfNotExists item)
        {
            if (item.IsIfNotExists())
            {
                return "IF NOT EXISTS";
            }
            return "";
        }

        private string IsIfExists(IIfExists item)
        {
            if (item.IsExists())
            {
                return "IF EXISTS";
            }
            return "";
        }

        private string IsTemporary(ITemporary item)
        {
            if (item.IsTemporary())
            {
                return "TEMPORARY";
            }
            return "";
        }

        public override string ToSQL(IPrimaryKey item)
        {
            return "PRIMARY KEY (`{FIELD_NAME}`)"
                .Replace("{FIELD_NAME}", item.GetName())
                .ClearString();
        }

        public override string ToSQL(IAddPrimaryKey item)
        {
            return "ADD PRIMARY KEY (`{FIELD_NAME}`)"
                .Replace("{FIELD_NAME}", item.GetName())
                .ClearString();
        }

        public override string ToSQL(IDefaultCharacterSet item)
        {
            return "DEFAULT CHARACTER SET {VALUE}"
                .Replace("{VALUE}", item.GetValue())
                .ClearString();
        }

        public override string ToSQL(IDefaultCollate item)
        {
            return "DEFAULT COLLATE {VALUE}"
                .Replace("{VALUE}", item.GetValue())
                .ClearString();
        }

        public override string ToSQL(ICreateDatabase item)
        {
            string sql = @"CREATE DATABASE 
                {IF_NOT_EXISTS} `{DB_NAME}`
                [SPECIFICATION]";
            return sql.Replace("{DB_NAME}", item.GetDatabaseName())
                .Replace("{IF_NOT_EXISTS}", IsIfNotExists((IIfNotExists)item))
                .Replace("[SPECIFICATION]", ToSQL(item.Specifications().ToList<dynamic>(), " "))
                .ClearString();
        }

        public override string ToSQL(List<dynamic> definitions, string endOfLine)
        {
            string sql = "";
            foreach (dynamic part in definitions.ToList())
            {
                sql += ToSQL(part) + endOfLine;
            }

            if (definitions.Count() > 0 && endOfLine.Length > 0)
            {
                sql = sql.Substring(0, sql.Length - endOfLine.Length);
            }
            return sql;
        }

        public override void DropDatabase(IDropDatabase item)
        {
            string sql = @"DROP DATABASE [IF EXISTS] `{DATABASE_NAME}`";
            sql = sql.Replace("{DATABASE_NAME}", item.GetDatabaseName())
                .Replace("[IF EXISTS]", IsIfExists((IIfExists)item))
                .ClearString();
            db.Execute(sql);
        }

        public override string ToSQL(JoinCondition item, Dictionary<string, dynamic> parameters)
        {
            string sql = "{PREFIX} {LEFT} {CONDITION} {RIGHT}";
            return sql
                .Replace("{PREFIX}", ToSQL(item.GetPrefix()))
                .Replace("{LEFT}", ToSQL(item.GetLeft(), parameters))
                .Replace("{CONDITION}", ToSQL(item.GetCondition()))
                .Replace("{RIGHT}", ToSQL(item.GetRight(), parameters))
                .ClearString();
        }

        public override string ToSQL(List<JoinCondition> items, Dictionary<string, dynamic> parameters)
        {
            string sql = "";
            foreach (JoinCondition item in items)
            {
                sql += " " + ToSQL(item, parameters);
            }
            return sql.ClearString();
        }

        public override string ToSQL(Join item, Dictionary<string, dynamic> parameters)
        {
            string sql = "{TYPE} `{TABLE_NAME}` {ALIAS} ON {CONDITION}";
            return sql
                .Replace("{TYPE}", ToSQL(item.GetJoinType()))
                .Replace("{TABLE_NAME}", item.GetTableName())
                .Replace("{ALIAS}", item.GetAlias())
                .Replace("{CONDITION}", ToSQL(item.GetConditions(), parameters))
                .ClearString();
        }

        public override string ToSQL(List<Join> items, Dictionary<string, dynamic> parameters)
        {
            string sql = "";
            foreach (Join item in items)
            {
                sql += " " + ToSQL(item, parameters) + " ";
            }
            return sql.ClearString();
        }

        public override string ToSQL(Dictionary<string, Query> subQueries, Dictionary<string, dynamic> parameters)
        {
            string template = ", ({SQL}) as {ALIAS}";
            string sql = "";
            foreach (KeyValuePair<string, Query> pair in subQueries)
            {
                CompiledQueryItem compiledQuery = ToSQL(pair.Value);
                parameters.Concat(compiledQuery.parameters);
                sql += template.Replace("{SQL}", compiledQuery.sql)
                    .Replace("{ALIAS}", pair.Key);
            }
            return sql;
        }

        public override CompiledQueryItem ToSQL(Query query)
        {
            string sql = "SELECT {SELECT} {SUB_QUERIES} FROM `{TABLE}` {JOIN} {WHERE} {ORDERBY} {LIMIT}";

            // Ara SQL dönüşümleri gerçekleştirilir
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            string selectSQL = ToSelectSQL(query, query.GetSelects(), query.GetMathSelect());
            string mathSelect = ToMathSelectSQL(query.GetMathSelect());

            // SQL cümlesi birleştirilir
            if (!string.IsNullOrEmpty(mathSelect))
            {
                if (string.IsNullOrEmpty(selectSQL))
                {
                    selectSQL = mathSelect;
                }
                else
                {
                    selectSQL += "," + mathSelect;
                }
            }

            sql = sql.Replace("{SELECT}", selectSQL)
                .Replace("{SUB_QUERIES}", ToSQL(query.GetSubQueries(), parameters))
                .Replace("{TABLE}", query.GetTable())
                .Replace("{JOIN}", ToSQL(query.GetJoins(), parameters))
                .Replace("{WHERE}", ToWhereSQLs(query.GetWheres(), parameters))
                .Replace("{ORDERBY}", ToOrderBySQL(query, query.GetOrderBy()))
                .Replace("{LIMIT}", ToLimitSQL(query.GetSkip(), query.GetTake()))
                .ClearString();

            return new CompiledQueryItem()
            {
                sql = sql,
                parameters = parameters
            };
        }

        public override string ToSQL(LogicTypes? item)
        {
            if (item == null)
            {
                return "";
            }
            Dictionary<LogicTypes?, string> values = new Dictionary<LogicTypes?, string>()
            {
                { LogicTypes.AND, "AND" },
                { LogicTypes.OR, "OR" },
            };
            if (values.ContainsKey(item) == false)
            {
                throw new Exception("Type not found: " + item.ToString());
            }
            return values[item];
        }

        public override string ToSQL(JoinTypes item)
        {
            Dictionary<JoinTypes?, string> values = new Dictionary<JoinTypes?, string>()
            {
                { JoinTypes.FULL, "FULL JOIN" },
                { JoinTypes.INNER, "INNER JOIN" },
                { JoinTypes.LEFT, "LEFT JOIN" },
                { JoinTypes.RIGHT, "RIGHT JOIN" },
            };
            if (values.ContainsKey(item) == false)
            {
                throw new Exception("Type not found: " + item.ToString());
            }
            return values[item];
        }

        public override string ToSQL(ConditionTypes item)
        {
            Dictionary<ConditionTypes, string> values = new Dictionary<ConditionTypes, string>()
            {
                { ConditionTypes.DIFFERENT, "<>" },
                { ConditionTypes.EQUAL, "=" },
                { ConditionTypes.GREATHER_THAN, ">" },
                { ConditionTypes.GREATHER_THAN_EQUAL, ">=" },
                { ConditionTypes.LESS_THAN, "<" },
                { ConditionTypes.LESS_THAN_EQUAL, "<=" }
            };
            if (values.ContainsKey(item) == false)
            {
                throw new Exception("Type not found: " + item.ToString());
            }
            return values[item];
        }

        public override string ToSQL(ICharacterSet item)
        {
            return "CHARACTER SET = " + item.GetValue();
        }

        public override string ToSQL(ICollate item)
        {
            return "COLLATE = " + item.GetValue();
        }

        public override string ToSQL(IEngine item)
        {
            return "ENGINE = " + item.GetValue();
        }

        public override void CreateBasicTable(string tableName)
        {
            string sql = @"CREATE TABLE `{TABLE_NAME}` (
              `id` INT NOT NULL AUTO_INCREMENT,
              `created_at` DATETIME NOT NULL,
              `updated_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
              `deleted_at` DATETIME NULL,
              `create_auth_id` INT NULL,
              `update_auth_id` INT NULL,
              `delete_auth_id` INT NULL,
              PRIMARY KEY (`id`)
            )
            ENGINE = InnoDB";
            sql = sql.Replace("{TABLE_NAME}", tableName).ClearString();
            Execute(sql);
        }

        public override string IsExists(string schema)
        {
            string sql = @"SELECT SCHEMA_NAME 
                FROM INFORMATION_SCHEMA.SCHEMATA 
                WHERE SCHEMA_NAME = '{SCHEMA}'";
            return sql.Replace("{SCHEMA}", schema)
                .ClearString();
        }

        public override List<Dictionary<string, dynamic>> Query(string sql, Dictionary<string, dynamic> arguments = null)
        {
            return db.Query(sql, arguments);
        }

        public override List<ForeignKeyItem> GetAllForignKeys(string schema)
        {
            string sql = @"SELECT U.CONSTRAINT_NAME, U.TABLE_NAME, U.COLUMN_NAME, U.REFERENCED_TABLE_NAME, U.REFERENCED_COLUMN_NAME
                FROM information_schema.KEY_COLUMN_USAGE U
                LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS C ON 
                    C.CONSTRAINT_SCHEMA = @schema AND 
                    C.CONSTRAINT_TYPE = 'FOREIGN KEY' AND 
                    C.CONSTRAINT_NAME = U.CONSTRAINT_NAME
                WHERE U.CONSTRAINT_SCHEMA = @schema
                AND C.CONSTRAINT_NAME <> 'PRIMARY'";
            sql = sql.Replace("{SCHEMA}", schema).ClearString();

            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schema }
                }
            );

            return items.ConvertAll(
                new Converter<Dictionary<string, dynamic>, ForeignKeyItem>(
                    ForeignKeyItem.MySQLConverter
                )
            );
        }

        public override List<ConstraintItem> GetSystemForignKeys(string schema)
        {
            string sql = @"SELECT *
                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                WHERE TABLE_SCHEMA = '{SCHEMA}'
                AND CONSTRAINT_TYPE = 'FOREIGN KEY'
                AND TABLE_NAME LIKE 'sys_%'";
            sql = sql.Replace("{SCHEMA}", schema).ClearString();

            return Query(sql).ConvertAll(
                new Converter<Dictionary<string, dynamic>, ConstraintItem>(
                    ConstraintItem.MySQLConverter
                )
            );
        }

        public override List<ForeignKeyItem> GetUserForignKeys(string schema)
        {
            string sql = @" SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                            WHERE CONSTRAINT_NAME IN (
                                SELECT CONSTRAINT_NAME
                                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                                WHERE TABLE_SCHEMA = '{SCHEMA}'
                                AND CONSTRAINT_TYPE = 'FOREIGN KEY'
                                AND TABLE_NAME NOT LIKE 'sys_%'
                            )";
            sql = sql.Replace("{SCHEMA}", schema).ClearString();

            return Query(sql).ConvertAll(
                new Converter<Dictionary<string, dynamic>, ForeignKeyItem>(
                    ForeignKeyItem.MySQLConverter
                )
            );
        }

        public override List<StoredProcedureItem> GetProcedures(string schema, StoredProcedureTypes type)
        {
            string sql = "SHOW " + type.ToString() + " STATUS WHERE `Db` = @schema";

            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schema }
                }
            );

            return items.ConvertAll(
                new Converter<Dictionary<string, dynamic>, StoredProcedureItem>(
                    StoredProcedureItem.MySQLConverter
                )
            );
        }

        public override string GetStoredProcedureDetailAsQuery(string schema, string name)
        {
            string sql = @" SELECT ROUTINE_DEFINITION 
                            FROM information_schema.routines 
                            WHERE routine_schema = @schema
                            AND ROUTINE_NAME = @name";
            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schema },
                    { "name", name }
                }
            );
            if (items.Count == 0)
            {
                throw new Exception("Procedure not found: " + name);
            }
            return items.First()["ROUTINE_DEFINITION"];
        }

        public override List<TriggerItem> GetTriggers(string schema, TriggerTypes? eventType, TriggerTimeTypes? timeType, string tableName)
        {
            string sql = @" SELECT *
                            FROM information_schema.triggers
                            WHERE TRIGGER_SCHEMA = @schema";

            if (eventType != null)
            {
                sql += " AND EVENT_MANIPULATION = @eventType ";
            }

            if (timeType != null)
            {
                sql += " AND ACTION_TIMING = @timeType ";
            }

            if (tableName != null)
            {
                sql += " AND EVENT_OBJECT_TABLE = @tableName ";
            }


            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schema },
                    { "eventType", eventType.ToString() },
                    { "timeType", timeType.ToString() },
                    { "tableName", tableName }
                }
            );
            return items.ConvertAll(
                new Converter<Dictionary<string, dynamic>, TriggerItem>(
                    TriggerItem.MySQLConverter
                )
            );
        }

        public override string GetTriggerDetail(string schema, string name)
        {
            string sql = @" SELECT *
                      FROM information_schema.triggers
                      WHERE TRIGGER_SCHEMA = @schema
                      AND TRIGGER_NAME = @name";

            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schema },
                    { "name", name }
                }
            );
            if (items.Count != 1)
            {
                throw new Exception("Record not found!");
            }

            return items.First()["ACTION_STATEMENT"];
        }

        public override List<string> GetSchemas()
        {
            List<string> items = new List<string>();
            foreach (Dictionary<string, dynamic> item in Query("SHOW DATABASES"))
            {
                items.Add(item["Database"]);
            }
            return items;
        }

        public override List<string> GetIndexNames(string schema, string tableName, string columnName)
        {
            string sql = @"SELECT *
                FROM INFORMATION_SCHEMA.STATISTICS
                WHERE TABLE_SCHEMA = @schema
                AND TABLE_NAME = @tableName
                AND NON_UNIQUE = false
                AND INDEX_NAME <> 'PRIMARY'
                AND COLUMN_NAME = @columnName";

            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schema },
                    { "tableName", tableName },
                    { "columnName", columnName }
                }
            );

            List<string> result = new List<string>();

            foreach (Dictionary<string, dynamic> item in items)
            {
                result.Add(item["INDEX_NAME"]);
            }

            return result;
        }

        public override string GetDeleteRowsSQL(string tableName, string key, dynamic value)
        {
            string sql = "DELETE FROM `{TABLE_NAME}` WHERE `{KEY}` = '{VALUE}'";
            sql = sql.Replace("{TABLE_NAME}", tableName)
                .Replace("{KEY}", key)
                .Replace("{VALUE}", value.ToString());
            return sql.ClearString();
        }

        public override void AddNode(string table, int right)
        {
            db.Execute(
                "UPDATE `{TABLE}` SET `lft` = `lft` + 2 WHERE `lft` > @right".Replace("{TABLE}", table),
                new Dictionary<string, dynamic>()
                {
                    { "right", right }
                }
            );

            db.Execute(
                "UPDATE `{TABLE}` SET `rght` = `rght` + 2 WHERE `rght` >= @right".Replace("{TABLE}", table),
                new Dictionary<string, dynamic>()
                {
                    { "right", right }
                }
            );
        }

        public override void DeleteNode(string table, int left, int right)
        {
            int width = right - left + 1;

            db.Execute(
                "DELETE FROM `{TABLE}` WHERE `lft` BETWEEN @left AND @right".Replace("{TABLE}", table),
                new Dictionary<string, dynamic>()
                {
                    { "left", left },
                    { "right", right }
                }
            );

            db.Execute(
                "UPDATE `{TABLE}` SET `rght` = `rght` - @width WHERE `rght` > @right".Replace("{TABLE}", table),
                new Dictionary<string, dynamic>()
                {
                    { "table", table },
                    { "width", width },
                    { "right", right }
                }
            );

            db.Execute(
                "UPDATE `{TABLE}` SET `lft` = `lft` - @width WHERE `lft` > @right".Replace("{TABLE}", table),
                // table, width, right
                new Dictionary<string, dynamic>()
                {
                    { "width", width },
                    { "right", right }
                }
            );
        }

        public override List<TableItem> GetUserDefinedTables(string schema)
        {
            string sql = @"SELECT T.*, CCSA.character_set_name AS CHARSETNAME
                FROM information_schema.TABLES T
                LEFT JOIN information_schema.`COLLATION_CHARACTER_SET_APPLICABILITY` CCSA ON CCSA.collation_name = T.table_collation
                WHERE T.TABLE_SCHEMA = @schema
                AND TABLE_TYPE = 'BASE TABLE'
                AND TABLE_NAME <> '_psmigrations'
                AND TABLe_NAME NOT LIKE 'sys_%'";
            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schema }
                }
            );
            return items.ConvertAll(
                new Converter<Dictionary<string, dynamic>, TableItem>(TableItem.MySQLConverter)
            );
        }

        public override TableItem GetUserDefinedTable(string schema, string name)
        {
            string sql = @"SELECT T.*, CCSA.character_set_name AS CHARSETNAME
                FROM information_schema.TABLES T
                LEFT JOIN information_schema.`COLLATION_CHARACTER_SET_APPLICABILITY` CCSA ON CCSA.collation_name = T.table_collation
                WHERE T.TABLE_SCHEMA = @schema
                AND TABLE_TYPE = 'BASE TABLE'
                AND TABLE_NAME = @name";
            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schema },
                    { "name", name }
                }
            );

            if (items.Count == 0)
            {
                return null;
            }

            return TableItem.MySQLConverter(items.FirstOrDefault());
        }


        public override List<ColumnItem> GetAllColumns(string schema)
        {
            string sql = @"SELECT C.*, S.INDEX_NAME AS C_INDEX_NAME
                FROM information_schema.COLUMNS C
                LEFT JOIN INFORMATION_SCHEMA.STATISTICS S ON S.TABLE_SCHEMA = C.TABLE_SCHEMA AND S.TABLE_NAME = C.TABLE_NAME AND S.COLUMN_NAME = C.COLUMN_NAME AND S.INDEX_NAME <> C.COLUMN_NAME
                WHERE C.TABLE_SCHEMA = @schema";
            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schema }
                }
            );
            return items.ConvertAll(new Converter<Dictionary<string, dynamic>, ColumnItem>(ColumnItem.MySQLConverter));
        }

        public override List<ColumnItem> GetTableColumns(string schemaName, string tableName)
        {
            string sql = @"SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS 
                WHERE TABLE_SCHEMA = @schema AND TABLE_NAME = @table";
            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schemaName },
                    { "table", tableName }
                }
            );
            return items.ConvertAll(new Converter<Dictionary<string, dynamic>, ColumnItem>(ColumnItem.MySQLConverter));
        }

        public override List<TableSizeInformation> GetTableInformations(string schema, string tableName = null)
        {
            string sql;

            // Tablo detaylarının doğru alınabilmesi için MYSQL'e özel olarak tablo bazlı 
            // analiz sorgusu çalıştırmamız gerekiyor.
            if (tableName != null)
            {
                db.Execute("analyze TABLE `{TABLE_NAME}`".Replace("{TABLE_NAME}", tableName));
            }
            else
            {
                foreach (TableItem table in GetTables(schema))
                {
                    db.Execute("analyze TABLE `{TABLE_NAME}`".Replace("{TABLE_NAME}", table.metadata.name));
                }
            }

            sql = @"SELECT T.TABLE_NAME, T.TABLE_ROWS, (T.data_length + T.index_length) TABLE_SIZE,
                (
	                SELECT COLUMN_NAME
	                FROM information_schema.key_column_usage
	                WHERE TABLE_SCHEMA = @schema AND TABLE_NAME = T.TABLE_NAME AND CONSTRAINT_NAME = 'PRIMARY'
                ) AS PRIMARY_KEY
                FROM information_schema.TABLES T
                WHERE T.table_schema = @schema
                {TABLE_NAME_QUERY}";

            string tableNameQuery = "AND TABLE_NAME LIKE 'sys_%'";
            if (tableName != null)
            {
                tableNameQuery = "AND TABLE_NAME = @tableName";
            }

            sql = sql.Replace("{TABLE_NAME_QUERY}", tableNameQuery);

            Dictionary<string, dynamic> arguments = new Dictionary<string, dynamic>()
            {
                { "schema", schema },
                { "tableName", tableName }
            };

            return Query(sql, arguments).ConvertAll(
                new Converter<Dictionary<string, dynamic>, TableSizeInformation>(
                    TableSizeInformation.MySQLConverter
                )
            );
        }

        public override List<TableRelationshipItem> GetTableRelations(string schema)
        {
            string sql = @"SELECT `TABLE_NAME`, `COLUMN_NAME`, `REFERENCED_TABLE_NAME`, `REFERENCED_COLUMN_NAME`                 
                FROM `INFORMATION_SCHEMA`.`KEY_COLUMN_USAGE`  
                WHERE `TABLE_SCHEMA` = @schema
                AND `TABLE_NAME` LIKE 'sys_%'
                AND `REFERENCED_TABLE_NAME` IS NOT NULL";

            Dictionary<string, dynamic> arguments = new Dictionary<string, dynamic>()
            {
                { "schema", schema }
            };

            return Query(sql, arguments).ConvertAll(
                new Converter<Dictionary<string, dynamic>, TableRelationshipItem>(
                    TableRelationshipItem.MySQLConverter
                )
            );
        }

        public override List<IndexItem> GetUniqueIndexesByTable(string tableName)
        {
            string sql = @"SHOW INDEX FROM {TABLE_NAME}"
                .Replace("{TABLE_NAME}", tableName);
            return Query(sql)
                .ConvertAll(new Converter<Dictionary<string, dynamic>, IndexItem>(IndexItem.MySQLConverter));
        }

        public override Dictionary<string, dynamic> Find(string table, string key, string value)
        {
            string sql = @"SELECT * FROM `{TABLE_NAME}` WHERE `{KEY}` = @value";
            sql = sql.Replace("{TABLE_NAME}", table)
                .Replace("{KEY}", key)
                .ClearString();

            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "value", value  }
                }
            );

            return items.FirstOrDefault();
        }

        public override Dictionary<string, dynamic> Find(string table, string key, dynamic value)
        {
            string sql = "SELECT * FROM `{0}` WHERE " + key + " = @p0";
            sql = String.Format(sql, table);

            Dictionary<string, dynamic> arguments = new Dictionary<string, dynamic>();
            arguments.Add("p0", value);
            return Query(sql, arguments).FirstOrDefault();
        }

        public override long Insert(
            string table,
            Dictionary<string, dynamic> row,
            AutoIncrementTypes autoIncrementType = AutoIncrementTypes.ON
        )
        {
            // Parametreler hazırlanır
            Dictionary<string, dynamic> arguments = new Dictionary<string, dynamic>();
            foreach (KeyValuePair<string, dynamic> pair in row)
            {
                arguments.Add(pair.Key, pair.Value);
            }

            return db.Insert(
                InsertAsQuery(table, row),
                arguments
            );
        }

        public override void Insert(
            string table,
            List<Dictionary<string, dynamic>> rows,
            AutoIncrementTypes autoIncrementType = AutoIncrementTypes.ON
        )
        {
            if (rows.Count == 0)
            {
                return;
            }

            // Varsayılan değerler ayarlandı.
            string sql = "INSERT INTO `{0}` ({1}) VALUES {2}";
            string columnSQLs = "";
            string paramSQLs = "";

            // Eklenecek sütunlar belirlenir
            foreach (KeyValuePair<string, dynamic> pair in rows.First())
            {
                columnSQLs += " `" + pair.Key + "`,";
            }
            columnSQLs = columnSQLs.Substring(0, columnSQLs.Length - 1);

            // Veri parametreleri hazırlanır
            int index = 0;
            foreach (Dictionary<string, dynamic> row in rows)
            {
                paramSQLs += "(";
                foreach (KeyValuePair<string, dynamic> pair in row)
                {
                    paramSQLs += " @" + pair.Key + "_" + index.ToString() + ",";
                }
                paramSQLs = paramSQLs.Substring(0, paramSQLs.Length - 1);
                paramSQLs += "),";
                index++;
            }

            paramSQLs = paramSQLs.Substring(0, paramSQLs.Length - 1);

            // SQL oluşturulur
            sql = String.Format(sql, table, columnSQLs, paramSQLs);


            // Parametreler bind edilir
            Dictionary<string, dynamic> arguments = new Dictionary<string, dynamic>();
            index = 0;
            foreach (Dictionary<string, dynamic> row in rows)
            {
                foreach (KeyValuePair<string, dynamic> pair in row)
                {
                    arguments.Add(pair.Key + "_" + index.ToString(), pair.Value);
                }
                index++;
            }

            db.Execute(sql, arguments);
        }

        public override void Update(string table, string key, dynamic value, Dictionary<string, dynamic> row)
        {
            // Parametreler bind edilir
            Dictionary<string, dynamic> arguments = new Dictionary<string, dynamic>();
            foreach (KeyValuePair<string, dynamic> pair in row)
            {
                arguments.Add(pair.Key, pair.Value);
            }
            arguments.Add("value", value);

            // Sorgu çalıştırılır
            db.Execute(
                UpdateAsQuery(table, key, value, row),
                arguments
            );
        }

        public override void Delete(string table, List<Where> wheres)
        {
            // Temel SQL komutu oluşturulur
            string sql = "UPDATE `{0}` SET `deleted_at` = @deleted_at {1}";
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

            string whereSQL = ToWhereSQLs(wheres, parameters);

            // SQL cümleciği birleştirilir
            sql = String.Format(sql, table, whereSQL);

            // Parametreler bind edilir
            Dictionary<string, dynamic> arguments = new Dictionary<string, dynamic>();
            foreach (KeyValuePair<string, dynamic> pair in parameters)
            {
                arguments.Add(pair.Key, pair.Value);
            }
            arguments.Add("deleted_at", DateTime.Now);

            // Sorgu çalıştırılır
            db.Execute(sql, arguments);
        }

        public override void DeleteForce(string table, List<Where> wheres)
        {
            // Temel SQL komutu oluşturulur
            string sql = "DELETE FROM `{0}` {1}";
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

            string whereSQL = ToWhereSQLs(wheres, parameters);

            // SQL cümleciği birleştirilir
            sql = String.Format(sql, table, whereSQL);

            // Parametreler bind edilir
            Dictionary<string, dynamic> arguments = new Dictionary<string, dynamic>();
            foreach (KeyValuePair<string, dynamic> pair in parameters)
            {
                arguments.Add(pair.Key, pair.Value);
            }
            arguments.Add("deleted_at", DateTime.Now);

            // Sorgu çalıştırılır
            db.Execute(sql, arguments);
        }

        private string ToLimitSQL(int? skip, int? take)
        {
            string sql = "";
            if (take != null)
            {
                sql += " LIMIT " + take.ToString();
            }
            if (skip != null)
            {
                sql += " OFFSET " + skip.ToString();
            }
            return sql;
        }

        private string ToOrderBySQL(Query query, List<OrderBy> items)
        {
            string sql = "";
            if (items.Count > 0)
            {
                sql = "ORDER BY ";
            }
            foreach (OrderBy item in items)
            {
                sql += ToMySQLColumn(query, item.Column()) + " " + item.Type() + ",";
            }
            if (items.Count > 0)
            {
                sql = sql.Substring(0, sql.Length - 1);
            }
            return sql;
        }

        private string ToMySQLColumn(Query query, string column)
        {
            if (column.IndexOf(".") == -1)
            {
                return "`" + query.GetTable() + "`.`" + column + "`";
            }
            string[] parts = column.Split('.');
            return "`" + parts[0] + "`.`" + parts[1] + "`";
        }

        private string ToWhereSQLs(List<Where> whereList, Dictionary<string, dynamic> parameters)
        {
            string sql = "";
            if (whereList.Count > 0)
            {
                sql = "WHERE ";
            }
            int count = 0;
            foreach (Where where in whereList)
            {
                if (count > 0)
                {
                    sql += " " + where.Prefix() + " ";
                }
                sql += where.LeftBrackets() + ToWhereSQL(where, parameters) + where.RightBrackets();
                count++;
            }
            return sql;
        }

        private string ToWhereSQL(Where where, Dictionary<string, dynamic> parameters)
        {
            switch (where.Type())
            {
                case QueryWhereType.General:
                    return ToSQL(where.Left(), parameters) + " " +
                        where.Condition() + " " +
                        ToSQL(where.Right(), parameters);
                case QueryWhereType.Between:

                    // Değerler parametre olarak belirlenir
                    string value1 = "@p" + parameters.Count.ToString();
                    parameters[value1] = where.Value1().GetValue();

                    // Değerler parametre olarak belirlenir
                    string value2 = "@p" + parameters.Count.ToString();
                    parameters[value2] = where.Value2().GetValue();

                    return where.Left().GetValue() + " " +
                        where.SubPrefix() + " BETWEEN " +
                        value1 + " AND " +
                        value2;
                case QueryWhereType.In:
                    string sql = where.Left().GetValue() + " " +
                        where.SubPrefix() + " IN ({0})";
                    string valueSQL = "";
                    foreach (IQueryWhereSide value in where.Values())
                    {
                        valueSQL += value.GetValue() + ",";
                    }
                    valueSQL = valueSQL.Substring(0, valueSQL.Length - 1);
                    return String.Format(sql, valueSQL);
                case QueryWhereType.Null:
                    return where.Left().GetValue() + " IS " +
                        where.SubPrefix() + " NULL ";
                default:
                    throw new NotImplementedException();
            }
        }

        private string ToSelectSQL(Query query, List<Select> selects, List<MathSelect> mathSelects)
        {
            if (selects.Count == 0)
            {
                if (mathSelects.Count > 0)
                {
                    return string.Empty;
                }
                else
                {
                    return "*";
                }
            }
            string sql = "";
            foreach (Select select in selects)
            {
                string column = select.Column();

                if (column.Trim() != "*" && column.IndexOf(".") == -1)
                {
                    column = query.GetTable() + "." + column;
                }

                string[] parts = column.Split('.');
                string temp = "`" + parts[0] + "`";
                if (parts.Length > 1)
                {
                    temp += ".`" + parts[1] + "`";
                }

                sql += WrapWithAggregateFunction(temp, select);

                sql = sql.Replace("`*`", "*");

                if (select.AsName() != null && select.AsName().Trim().Length > 0)
                {
                    sql += " AS `" + select.AsName() + "`";
                }

                sql += ",";
            }
            sql = sql.Replace("`*`", "*");
            return sql.Substring(0, sql.Length - 1);
        }

        private string WrapWithAggregateFunction(string sql, Select select)
        {
            Dictionary<AggregateFunctions, string> templates = new Dictionary<AggregateFunctions, string>()
            {
                { AggregateFunctions.Sum, "SUM({SQL})" },
                { AggregateFunctions.Count, "COUNT({SQL})" },
                { AggregateFunctions.Avg, "AVG({SQL})" },
                { AggregateFunctions.Min, "MIN({SQL})" },
                { AggregateFunctions.Max, "MAX({SQL})" },
                { AggregateFunctions.None, "{SQL}" }
            };

            if (templates.ContainsKey(select.MathFunction()) == false)
            {
                return string.Empty;
            }

            return templates[select.MathFunction()]
                .Replace("{SQL}", sql);
        }

        private string ToMathSelectSQL(List<MathSelect> mathSelects)
        {
            string sql = string.Empty;
            if (mathSelects.Count == 0)
            {
                return sql;
            }

            foreach (MathSelect process in mathSelects)
            {
                sql += GetSqlColumnName(process.FirstColumn());
                sql += GetMathOperator(process.MathType());

                if (string.IsNullOrEmpty(process.SecondColumn()))
                {
                    sql += process.Value();
                }
                else
                {
                    sql += GetSqlColumnName(process.SecondColumn());
                }

                if (process.AsName() != null)
                {
                    sql += " AS `" + process.AsName() + "`";
                }

                sql += ",";
            }

            return sql.Substring(0, sql.Length - 1);
        }

        private string GetSqlColumnName(string columnName)
        {
            if (columnName.IndexOf(".") == -1)
            {
                return "`" + columnName + "`";
            }
            else
            {
                string[] parts = columnName.Split('.');
                return "`" + parts[0] + "`.`" + parts[1] + "`";
            }
        }

        private string GetMathOperator(MathProcessTypes type)
        {
            Dictionary<MathProcessTypes, string> types = new Dictionary<MathProcessTypes, string>()
            {
                { MathProcessTypes.Sum, " + " },
                { MathProcessTypes.Subtract, " - " },
                { MathProcessTypes.Multiply, " * " },
                { MathProcessTypes.Divide, " / " }
            };
            if (types.ContainsKey(type) == false)
            {
                throw new Exception("Type not found: " + type.ToString());
            }
            return types[type];
        }

        public override string InsertAsQuery(
            string table,
            Dictionary<string, dynamic> row,
            AutoIncrementTypes autoIncrementType = AutoIncrementTypes.ON
        )
        {
            string sql = "INSERT INTO `{0}` ({1}) VALUES ({2})";
            string columnSQLs = "";
            string paramSQLs = "";
            foreach (KeyValuePair<string, dynamic> pair in row)
            {
                columnSQLs += " `" + pair.Key + "`,";
                paramSQLs += " @" + pair.Key + ",";
            }
            columnSQLs = columnSQLs.Substring(0, columnSQLs.Length - 1);
            paramSQLs = paramSQLs.Substring(0, paramSQLs.Length - 1);

            return String.Format(sql, table, columnSQLs, paramSQLs);
        }

        public override string UpdateAsQuery(string table, string key, dynamic value, Dictionary<string, dynamic> row)
        {
            // Temel SQL komutu oluşturulur
            string sql = "UPDATE `{0}` SET {1} WHERE `{2}` = @value";

            // Set edilecek değerler için SQL komutu oluşturulur
            string setSQL = "";
            foreach (KeyValuePair<string, dynamic> pair in row)
            {
                setSQL += " `" + pair.Key + "` = @" + pair.Key + ",";
            }
            setSQL = setSQL.Substring(0, setSQL.Length - 1);

            // SQL cümleciği birleştirilir
            return String.Format(sql, table, setSQL, key);
        }

        public override bool IsDefined(string table, string field, dynamic value)
        {
            string sql = @"SELECT *
                FROM `{TABLE_NAME}` 
                WHERE `{FIELD_NAME}` = @value";
            sql = sql.Replace("{TABLE_NAME}", table)
                .Replace("{FIELD_NAME}", field)
                .ClearString();

            List<Dictionary<string, dynamic>> items = db.Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "value", value }
                }
            );

            return items.Count > 0;
        }

        public override bool IsHasRecord(string table)
        {
            string sql = @"SELECT *
                FROM `{TABLE_NAME}`";
            sql = sql.Replace("{TABLE_NAME}", table)
                .ClearString();

            List<Dictionary<string, dynamic>> items = db.Query(sql);

            return items.Count > 0;
        }

        public override string GetLastSQL()
        {
            return db.GetLastSQL();
        }

        public override void BeginTransaction()
        {
            db.BeginTransaction();
        }

        public override void CloseTransaction()
        {
            db.CloseTransaction();
        }

        public override void Commit()
        {
            db.Commit();
        }

        public override void Rollback()
        {
            db.Rollback();
        }

        public override void Update(string table, List<Where> wheres, Dictionary<string, dynamic> row)
        {
            // Temel SQL komutu oluşturulur
            string sql = "UPDATE `{TABLE_NAME}` SET {SET_VALUES} {WHERE_VALUES}";
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

            // Set edilecek değerler için SQL komutu oluşturulur
            string setSQL = "";
            foreach (KeyValuePair<string, dynamic> pair in row)
            {
                setSQL += " `" + pair.Key + "` = @set_" + pair.Key + ",";
                parameters.Add("@set_" + pair.Key, pair.Value);
            }
            setSQL = setSQL.Substring(0, setSQL.Length - 1);

            // SQL cümleciği birleştirilir
            sql = sql.Replace("{TABLE_NAME}", table)
                .Replace("{SET_VALUES}", setSQL)
                .Replace("{WHERE_VALUES}", ToWhereSQLs(wheres, parameters))
                .ClearString();

            // Sorgu çalıştırılır
            db.Execute(sql, parameters);
        }

        public override void ExecuteScript(string content)
        {
            db.ExecuteScript(content);
        }

        public override string GetMainDeleteSQL()
        {
            return "DELETE `{TABLE_NAME}` FROM `{TABLE_NAME}`";
        }

        public override string GetDeleteWhereSQL()
        {
            return "WHERE `{TABLE_NAME}`.`{PRIMARY_KEY}` IN ({VALUES})";
        }

        public override string GetInnerJoinSQL()
        {
            return "INNER JOIN `{MAIN_TABLE_NAME}` ON `{MAIN_TABLE_NAME}`.`{MAIN_PRIMARY_KEY}` = `{CHILD_TABLE}`.`{CHILD_PRIMARY_KEY}`";
        }

        public override string GetPrimaryKeySelect()
        {
            return "SELECT `{PRIMARY_KEY}`";
        }

        public override string GetRelationKeySQL()
        {
            return "FROM `{TABLE}` WHERE `{RELATION_KEY}` IN ({VALUES})";
        }

        public override AdaptorTypes GetAdaptorType()
        {
            return AdaptorTypes.MySQL;
        }

        public override List<IndexItem> GetUserDefinedIndexes(string schema)
        {
            string sql = @"SELECT TABLE_NAME AS `Table`, INDEX_NAME AS Key_name, COLUMN_NAME AS Column_name
                FROM INFORMATION_SCHEMA.STATISTICS
                WHERE TABLE_SCHEMA = @schema
                AND TABLE_NAME NOT LIKE 'sys_%'
                AND TABLE_NAME <> '_psmigrations'
                AND NON_UNIQUE = true";
            List<Dictionary<string, dynamic>> items = db.Query(sql, new Dictionary<string, dynamic>()
            {
                { "schema", schema }
            });
            return items.ConvertAll(new Converter<Dictionary<string, dynamic>, IndexItem>(IndexItem.MySQLConverter));
        }

        public override List<ColumnItem> GetUserDefinedColumns(string schema)
        {
            string sql = @"SELECT C.*, S.INDEX_NAME AS C_INDEX_NAME, T.ENGINE AS TABLE_ENGINE, T.TABLE_COLLATION, CCSA.character_set_name AS CHARSETNAME
                FROM information_schema.COLUMNS C
                LEFT JOIN INFORMATION_SCHEMA.STATISTICS S ON S.TABLE_SCHEMA = C.TABLE_SCHEMA AND S.TABLE_NAME = C.TABLE_NAME AND S.COLUMN_NAME = C.COLUMN_NAME AND S.INDEX_NAME <> C.COLUMN_NAME
                LEFT JOIN information_schema.TABLES T ON T.TABLE_SCHEMA = C.TABLE_SCHEMA AND T.TABLE_NAME = C.TABLE_NAME
                LEFT JOIN information_schema.`COLLATION_CHARACTER_SET_APPLICABILITY` CCSA ON CCSA.collation_name = T.table_collation
                WHERE C.TABLE_SCHEMA = @schema
                AND C.TABLE_NAME NOT LIKE 'sys_%'
                AND C.TABLE_NAME <> '_psmigrations'
                ORDER BY C.TABLE_NAME";
            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schema }
                }
            );
            return items.ConvertAll(new Converter<Dictionary<string, dynamic>, ColumnItem>(ColumnItem.MySQLConverter));
        }

        public override List<IndexItem> GetUserDefinedUniqueIndexes(string schema)
        {
            string sql = @"SELECT TABLE_NAME AS `Table`, INDEX_NAME AS Key_name, COLUMN_NAME AS Column_name
                FROM INFORMATION_SCHEMA.STATISTICS
                WHERE TABLE_SCHEMA = @schema
                AND TABLE_NAME NOT LIKE 'sys_%'
                AND TABLE_NAME <> '_psmigrations' 
                AND INDEX_NAME <> 'PRIMARY'
                AND NON_UNIQUE = false";
            List<Dictionary<string, dynamic>> items = db.Query(sql, new Dictionary<string, dynamic>()
            {
                { "schema", schema }
            });
            return items.ConvertAll(new Converter<Dictionary<string, dynamic>, IndexItem>(IndexItem.MySQLConverter));
        }

        public override List<TableItem> GetTables(string schema)
        {
            string sql = @"SELECT T.*, CCSA.character_set_name AS CHARSETNAME
                FROM information_schema.TABLES T
                LEFT JOIN information_schema.`COLLATION_CHARACTER_SET_APPLICABILITY` CCSA ON CCSA.collation_name = T.table_collation
                WHERE T.TABLE_SCHEMA = @schema
                AND TABLE_TYPE = 'BASE TABLE'";
            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schema }
                }
            );
            return items.ConvertAll(
                new Converter<Dictionary<string, dynamic>, TableItem>(TableItem.MySQLConverter)
            );
        }

        public override List<DataTypes> GetSupportedDataTypes()
        {
            return new List<DataTypes>()
            {
                DataTypes.INT,
                DataTypes.SMALLINT,
                DataTypes.TINYINT,
                DataTypes.MEDIUMINT,
                DataTypes.BIGINT,
                DataTypes.DECIMAL,
                DataTypes.NUMERIC,
                DataTypes.FLOAT,
                DataTypes.DOUBLE,
                DataTypes.BIT,
                DataTypes.DATE,
                DataTypes.DATETIME,
                DataTypes.TIME,
                DataTypes.YEAR,
                DataTypes.CHAR,
                DataTypes.VARCHAR,
                DataTypes.BINARY,
                DataTypes.VARBINARY,
                DataTypes.TINYBLOB,
                DataTypes.BLOB,
                DataTypes.MEDIUMBLOB,
                DataTypes.LONGBLOB,
                DataTypes.TINYTEXT,
                DataTypes.TEXT,
                DataTypes.MEDIUMTEXT,
                DataTypes.LONGTEXT,
                DataTypes.ENUM,
                DataTypes.SET,
                DataTypes.MULTI_SELECTION
            };
        }

        public override string ToSQL(IQueryWhereSide whereSide, Dictionary<string, dynamic> parameters)
        {
            if (whereSide.GetType() == typeof(WhereColumn))
            {
                string value = "`" + whereSide.GetValue() + "`";
                return value.Replace(".", "`.`");
            }

            if (whereSide.GetType() == typeof(WhereParam))
            {
                WhereParam side = (WhereParam)whereSide;
                if (side.IsSpecial())
                {
                    return "@" + side.GetValue();
                }

                string key = "@p" + parameters.Count.ToString();
                parameters[key] = whereSide.GetValue();
                return key;
            }

            if (whereSide.GetType() == typeof(WhereValue))
            {
                if (DynamicExtension.IsNumber(whereSide.GetValue()))
                {
                    return whereSide.GetValue().ToString(CultureInfo.InvariantCulture);
                }

                return "'" + whereSide.GetValue() + "'";
            }

            throw new NotImplementedException();
        }

        public override ColumnItem GetUserDefinedTableColumn(string schema, string tableName, string name)
        {
            string sql = @"SELECT C.*, S.INDEX_NAME AS C_INDEX_NAME
                FROM information_schema.COLUMNS C
                LEFT JOIN INFORMATION_SCHEMA.STATISTICS S ON S.TABLE_SCHEMA = C.TABLE_SCHEMA AND S.TABLE_NAME = C.TABLE_NAME AND S.COLUMN_NAME = C.COLUMN_NAME AND S.INDEX_NAME <> C.COLUMN_NAME
                WHERE C.TABLE_SCHEMA = @schema
                AND C.COLUMN_NAME = @name";
            List<Dictionary<string, dynamic>> items = Query(
                sql,
                new Dictionary<string, dynamic>()
                {
                    { "schema", schema },
                    { "name", name }
                }
            );

            if (items.Count == 0)
            {
                return null;
            }

            return ColumnItem.MySQLConverter(items.FirstOrDefault());
        }

        public override void DropAndCreateStoreProcedures()
        {
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            string spFolder = baseFolder + @"\App_Data\procedures\";
            string[] allfiles = Directory.GetFiles(spFolder);
            foreach (var file in allfiles)
            {
                // Bu kısımda SQL Store Procedure ismini dosya isminden alıyoruz.
                // Bu sebeple mutlaka SP ismi ile dosya ismi aynı olmalı.
                string[] spName = file.Split("\\");
                string lastWord = spName[spName.Length - 1];

                // Öncelikle aynı isimde bir SP varsa bunu DROP ediyoruz.
                string dropFirst = "DROP PROCEDURE IF EXISTS " + lastWord.Replace(".sql", "") + ";";
                db.Execute(dropFirst);

                // SP'yi çalıştırıyoruz.
                string spContent = System.IO.File.ReadAllText(file).ClearString();
                db.ExecuteSP(spContent);
            };
        }

        public override void ModifyColumnAsTimeStamp(IChangeColumnSpecial item)
        {
            string sql = "ALTER TABLE `{TABLE_NAME}` CHANGE COLUMN `{OLD_NAME}` `{OLD_NAME}` TIMESTAMP {ISNULL} {DEFAULT}";
            sql = sql.Replace("{TABLE_NAME}", item.GetTableName())
                .Replace("{OLD_NAME}", item.GetOldName())
                .Replace("{ISNULL}", item.GetIsNull())
                .Replace("{DEFAULT}", item.GetDefault())
                .ClearString();
            db.Execute(sql);
        }
    }
}
