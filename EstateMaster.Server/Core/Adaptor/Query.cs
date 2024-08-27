 using System;
using System.Collections.Generic;
using System.Linq;
using EstateMaster.Server.Adaptor.EnumTypes;
using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Shared;
using EstateMaster.Server.Adaptor.Types.QueryTypes;
using EstateMaster.Server.Adaptor.Types.QueryTypes.WhereTypes;

namespace EstateMaster.Server.Adaptor
{

    [Serializable]
    public class Query
    {

        private string table { get; set; }
        private List<Where> wheres { get; set; }
        private List<OrderBy> orderByColumns { get; set; }
        private List<Select> selects { get; set; }
        private List<MathSelect> mathSelects { get; set; }
        private List<Join> joins { get; set; }
        private int? skip { get; set; }
        private int? take { get; set; }
        private IDatabaseAdaptor connection { get; set; }
        public List<string> connectedTables { get; set; }
        private Dictionary<string, Query> subQueries { get; set; }
        private bool isTransactionOpened { get; set; }

        public Query(IDatabaseAdaptor connection)
        {
            wheres = new List<Where>();
            orderByColumns = new List<OrderBy>();
            selects = new List<Select>();
            mathSelects = new List<MathSelect>();
            joins = new List<Join>();
            connectedTables = new List<string>();
            subQueries = new Dictionary<string, Query>();
            this.connection = connection;
        }

        public AdaptorTypes GetAdaptorType()
        {
            return connection.GetAdaptorType();
        }

        public void Transaction(Func<Query, Query> callback)
        {
            BeginTransaction();
            callback(this);
            isTransactionOpened = false;
        }

        public void Commit()
        {
            if (isTransactionOpened == false)
            {
                throw new Exception("Transaction is not open!");
            }
            connection.Commit();
        }

        public void Rollback()
        {
            if (isTransactionOpened == false)
            {
                throw new Exception("Transaction is not open!");
            }
            connection.Rollback();
        }

        public void BeginTransaction()
        {
            isTransactionOpened = true;
            connection.BeginTransaction();
        }

        public string GetTable()
        {
            return table;
        }

        public Query Table(string name)
        {
            table = name;
            return this;
        }

        public Query WhereGroup(Func<Query, Query> callback)
        {
            int startedAt = wheres.Count();
            callback(this);

            if (wheres.ElementAtOrDefault(startedAt) == null)
            {
                return this;
            }

            wheres[startedAt].AddLeftBrackets();
            wheres[startedAt].SetPrefix("AND");
            wheres[wheres.Count() - 1].AddRightBrackets();
            return this;
        }

        public Query OrWhereGroup(Func<Query, Query> callback)
        {
            int startedAt = wheres.Count();
            callback(this);

            if (wheres.ElementAtOrDefault(startedAt) == null)
            {
                return this;
            }

            wheres[startedAt].AddLeftBrackets();
            wheres[startedAt].SetPrefix("OR");
            wheres[wheres.Count() - 1].AddRightBrackets();
            return this;
        }

        public Query Where(string column, string condition, dynamic value)
        {
            Where where = new Where()
                .SetType(QueryWhereType.General)
                .SetCondition(condition)
                .SetLeft(new WhereColumn(column))
                .SetRight(new WhereParam(value));
            wheres.Add(where);
            return this;
        }

        public Query Wheres(List<Where> wheres)
        {
            this.wheres = wheres;
            return this;
        }

        public Query Where(WhereColumn column, string condition, WhereColumn value)
        {
            Where where = new Where()
                .SetType(QueryWhereType.General)
                .SetCondition(condition)
                .SetLeft(column)
                .SetRight(value);
            wheres.Add(where);
            return this;
        }

        public Query Where(IQueryWhereSide column, string condition, IQueryWhereSide value)
        {
            Where where = new Where()
                .SetType(QueryWhereType.General)
                .SetCondition(condition)
                .SetLeft(column)
                .SetRight(value);
            wheres.Add(where);
            return this;
        }

        public Query OrWhere(IQueryWhereSide column, string condition, IQueryWhereSide value)
        {
            Where where = new Where()
                .SetPrefix("OR")
                .SetType(QueryWhereType.General)
                .SetCondition(condition)
                .SetLeft(column)
                .SetRight(value);
            wheres.Add(where);
            return this;
        }

        public Query OrWhere(string column, string condition, dynamic value)
        {
            Where where = new Where()
                .SetType(QueryWhereType.General)
                .SetPrefix("OR")
                .SetCondition(condition)
                .SetLeft(new WhereColumn(column))
                .SetRight(new WhereParam(value));
            wheres.Add(where);
            return this;
        }

        public Query WhereBetween(string column, dynamic start, dynamic end)
        {
            Where where = new Where()
                .SetType(QueryWhereType.Between)
                .SetLeft(new WhereColumn(column))
                .SetValue1(new WhereParam(start))
                .SetValue2(new WhereParam(end));
            wheres.Add(where);
            return this;
        }

        public Query WhereNotBetween(string column, dynamic start, dynamic end)
        {
            Where where = new Where()
                .SetType(QueryWhereType.Between)
                .SetSubPrefix("NOT")
                .SetLeft(new WhereColumn(column))
                .SetValue1(new WhereParam(start))
                .SetValue2(new WhereParam(end));
            wheres.Add(where);
            return this;
        }

        public Query OrWhereBetween(string column, dynamic start, dynamic end)
        {
            Where where = new Where()
                .SetPrefix("OR")
                .SetType(QueryWhereType.Between)
                .SetLeft(new WhereColumn(column))
                .SetValue1(new WhereParam(start))
                .SetValue2(new WhereParam(end));
            wheres.Add(where);
            return this;
        }

        public Query OrWhereNotBetween(string column, dynamic start, dynamic end)
        {
            Where where = new Where()
                .SetPrefix("OR")
                .SetType(QueryWhereType.Between)
                .SetSubPrefix("NOT")
                .SetLeft(new WhereColumn(column))
                .SetValue1(new WhereParam(start))
                .SetValue2(new WhereParam(end));
            wheres.Add(where);
            return this;
        }

        public Query WhereIn(string column, List<dynamic> items)
        {
            List<IQueryWhereSide> values = new List<IQueryWhereSide>();
            foreach (dynamic item in items)
            {
                values.Add(new WhereParam(item));
            }

            Where where = new Where()
                .SetType(QueryWhereType.In)
                .SetLeft(new WhereColumn(column))
                .SetValues(values);

            wheres.Add(where);
            return this;
        }

        public Query WhereNotIn(string column, List<dynamic> items)
        {
            List<IQueryWhereSide> values = new List<IQueryWhereSide>();
            foreach (dynamic item in items)
            {
                values.Add(new WhereParam(item));
            }

            Where where = new Where()
                .SetType(QueryWhereType.In)
                .SetSubPrefix("NOT")
                .SetLeft(new WhereColumn(column))
                .SetValues(values);

            wheres.Add(where);

            return this;
        }

        public Query OrWhereIn(string column, List<dynamic> items)
        {
            List<IQueryWhereSide> values = new List<IQueryWhereSide>();
            foreach (dynamic item in items)
            {
                values.Add(new WhereParam(item));
            }

            Where where = new Where()
                .SetPrefix("OR")
                .SetType(QueryWhereType.In)
                .SetLeft(new WhereColumn(column))
                .SetValues(values);

            wheres.Add(where);
            return this;
        }

        public Query OrWhereNotIn(string column, List<dynamic> items)
        {
            List<IQueryWhereSide> values = new List<IQueryWhereSide>();
            foreach (dynamic item in items)
            {
                values.Add(new WhereParam(item));
            }

            Where where = new Where()
                .SetPrefix("OR")
                .SetType(QueryWhereType.In)
                .SetSubPrefix("NOT")
                .SetLeft(new WhereColumn(column))
                .SetValues(values);

            wheres.Add(where);

            return this;
        }

        public Query WhereNull(string column)
        {
            Where where = new Where()
                .SetType(QueryWhereType.Null)
                .SetLeft(new WhereColumn(column));
            wheres.Add(where);
            return this;
        }

        public Query WhereNotNull(string column)
        {
            Where where = new Where()
                .SetType(QueryWhereType.Null)
                .SetSubPrefix("NOT")
                .SetLeft(new WhereColumn(column));
            wheres.Add(where);
            return this;
        }

        public Query OrWhereNull(string column)
        {
            Where where = new Where()
                .SetPrefix("OR")
                .SetType(QueryWhereType.Null)
                .SetLeft(new WhereColumn(column));
            wheres.Add(where);
            return this;
        }

        public Query OrWhereNotNull(string column)
        {
            Where where = new Where()
                .SetPrefix("OR")
                .SetType(QueryWhereType.Null)
                .SetSubPrefix("NOT")
                .SetLeft(new WhereColumn(column));
            wheres.Add(where);
            return this;
        }

        public Query OrderBy(string column, bool descending = false)
        {
            string type = "ASC";
            if (descending)
            {
                type = "DESC";
            }
            orderByColumns.Add(new OrderBy(column, type));
            return this;
        }

        public Query Select(string column, string asName = null)
        {
            selects.Add(new Select(column, asName));
            return this;
        }

        public Query Select(string column, AggregateFunctions mathFunction, string asName = null)
        {
            selects.Add(new Select(column, mathFunction, asName));
            return this;
        }

        public Query Select(Query subQuery, string asName)
        {
            subQueries.Add(asName, subQuery);
            return this;
        }

        public Query MathSelect(
            string firstColumn,
            MathProcessTypes mathProcess,
            double value,
            string asName
        )
        {
            mathSelects.Add(new MathSelect(firstColumn, mathProcess, value, asName));
            return this;
        }

        public Query MathSelect(
            string firstColumn,
            MathProcessTypes mathProcess,
            string secondColumn,
            string asName
        )
        {
            mathSelects.Add(new MathSelect(firstColumn, mathProcess, secondColumn, asName));

            return this;
        }

        public Query Skip(int value)
        {
            skip = value;
            return this;
        }

        public Query Take(int value)
        {
            take = value;
            return this;
        }

        public Query Joins(Func<Query, Query> callback)
        {
            callback(this);
            return this;
        }

        public Query AddJoin(Join join)
        {
            joins.Add(join);
            return this;
        }

        public Join NewJoin()
        {
            joins.Add(new Join());
            return joins[joins.Count - 1];
        }

        public Join LeftJoin()
        {
            return NewJoin().Type(JoinTypes.LEFT);
        }

        public Join RightJoin()
        {
            return NewJoin().Type(JoinTypes.RIGHT);
        }

        public Join FullJoin()
        {
            return NewJoin().Type(JoinTypes.FULL);
        }

        public Join InnerJoin()
        {
            return NewJoin().Type(JoinTypes.INNER);
        }

        public List<Dictionary<string, dynamic>> ToList(Dictionary<string, dynamic> arguments = null)
        {
            if (table == null)
            {
                throw new Exception("You have to select the table!");
            }

            if (arguments == null)
            {
                arguments = new Dictionary<string, dynamic>();
            }

            CompiledQueryItem compiledQuery = connection.ToSQL(this);

            foreach (KeyValuePair<string, dynamic> pair in arguments)
            {
                compiledQuery.parameters.Add(pair.Key, pair.Value);
            }

            List<Dictionary<string, dynamic>> items = connection.Query(
                compiledQuery.sql,
                compiledQuery.parameters
            );

            ResetValues();
            return items;
        }

        /// <summary>
        /// Çalışmadan önce çalıştırılacak sorgu query'sini 
        /// almak için kullanılır.
        /// </summary>
        /// <returns></returns>
        public string GetQuerySQL()
        {
            CompiledQueryItem compiledQuery = connection.ToSQL(this);
            return compiledQuery.sql;
        }

        public Dictionary<string, dynamic> Find(int id)
        {
            Dictionary<string, dynamic> item = Find("ID", id);
            ResetValues();
            return item;
        }

        public Dictionary<string, dynamic> FindOrFail(int id)
        {
            Dictionary<string, dynamic> item = FindOrFail("ID", id);
            ResetValues();
            return item;
        }

        public Dictionary<string, dynamic> Find(string primaryKey, dynamic primaryKeyValue)
        {
            Dictionary<string, dynamic> item = connection.Find(table, primaryKey, primaryKeyValue);
            ResetValues();
            return item;
        }

        public Dictionary<string, dynamic> FindOrFail(string primaryKey, dynamic primaryKeyValue)
        {
            Dictionary<string, dynamic> item = Find(primaryKey, primaryKeyValue);
            if (item == null)
            {
                throw new Exception("Record not found: " + primaryKeyValue.ToString());
            }
            ResetValues();
            return item;
        }

        public long Insert(Dictionary<string, dynamic> row, AutoIncrementTypes autoIncrementType = AutoIncrementTypes.ON)
        {
            long insertId = connection.Insert(table, row, autoIncrementType);
            ResetValues();
            return insertId;
        }

        public void Insert(
            List<Dictionary<string, dynamic>> rows, 
            AutoIncrementTypes autoIncrementType = AutoIncrementTypes.ON
        )
        {
            connection.Insert(table, rows, autoIncrementType);
            ResetValues();
        }

        public void Update(Dictionary<string, dynamic> row)
        {
            // Where ile filtrelenen verilerin silinmesi işlemi
            // Eğer left join uygulanmışsa bu işlem çalışmaz.
            if (joins.Count > 0 || selects.Count > 0)
            {
                throw new Exception("You cannot update the data with using JOIN or SELECT operation.");
            }

            // Liste verileri toplu olarak silinir.
            connection.Update(table, wheres, row);
            ResetValues();
        }

        //public void Update(int id, Dictionary<string, dynamic> row)
        //{
        //    Update("id", id, row);
        //}

        public void Update(string key, dynamic value, Dictionary<string, dynamic> row)
        {
            connection.Update(table, key, value, row);
            ResetValues();
        }

        public void Update(string table, string key, dynamic value, Dictionary<string, dynamic> row)
        {
            connection.Update(table, key, value, row);
            ResetValues();
        }

        public void Delete()
        {
            // Where ile filtrelenen verilerin silinmesi işlemi
            // Eğer left join uygulanmışsa bu işlem çalışmaz.
            if (joins.Count > 0 || selects.Count > 0)
            {
                throw new Exception("You cannot delete the data with using JOIN or SELECT operation.");
            }

            // Liste verileri toplu olarak silinir.
            connection.Delete(table, wheres);
            ResetValues();
        }

        public void DeleteForce()
        {
            // Where ile filtrelenen verilerin silinmesi işlemi
            // Eğer left join uygulanmışsa bu işlem çalışmaz.
            if (joins.Count > 0 || selects.Count > 0)
            {
                throw new Exception("You cannot delete the data with using JOIN or SELECT operation.");
            }

            // Liste verileri toplu olarak silinir.
            connection.DeleteForce(table, wheres);
            ResetValues();
        }

        public bool IsDefined(string field, dynamic value)
        {
            return connection.IsDefined(table, field, value);
        }

        public bool IsHasRecord()
        {
             return connection.IsHasRecord(table);
        }

        public string GetLastSQL()
        {
            return connection.GetLastSQL();
        }

        private void ResetValues()
        {
            table = null;
            wheres = new List<Where>();
            orderByColumns = new List<OrderBy>();
            selects = new List<Select>();
            joins = new List<Join>();
            skip = null;
            take = null;
        }

        public List<Select> GetSelects()
        {
            return selects;
        }

        public List<MathSelect> GetMathSelect()
        {
            return mathSelects;
        }

        public List<Join> GetJoins()
        {
            return joins;
        }

        public List<Where> GetWheres()
        {
            return wheres;
        }

        public List<OrderBy> GetOrderBy()
        {
            return orderByColumns;
        }

        public Dictionary<string, Query> GetSubQueries()
        {
            return subQueries;
        }

        public void CloseConnection()
        {
            connection.DisposeAll();
        }

        public int? GetSkip()
        {
            return skip;
        }

        public int? GetTake()
        {
            return take;
        }

        private List<string> GetDeleteSQLsThroughParent(string sql)
        {
            List<string> sqls = new List<string>();


            return sqls;
        }

        private string CreateWhereParameterString(List<dynamic> values)
        {
            string mainWhereValues = "";
            foreach (dynamic value in values)
            {
                mainWhereValues += "'" + value.ToString() + "',";
            }
            return mainWhereValues.Substring(0, mainWhereValues.Length - 1);
        }

    }
}
