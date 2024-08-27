using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using EstateMaster.Server.Adaptor.Interfaces.CreateTableParts;
using EstateMaster.Server.Adaptor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateMaster.Server.Adaptor.Types.DDLManipulations;
using EstateMaster.Server.Adaptor.Responses;

namespace EstateMaster.Server.Adaptor.Types
{
    public class CreateTable : IDDLAction, ICreateTable, IIfNotExists, ITemporary
    {

        private List<ICreateDefinition> definitions { get; set; }

        private string tableName { get; set; }

        private bool isTemporary { get; set; }

        private bool ifNotExistsKey { get; set; }

        public CreateTable(string tableName)
        {
            this.tableName = tableName;
            isTemporary = false;
            ifNotExistsKey = false;
            definitions = new List<ICreateDefinition>();
        }

        public ICreateTable Definition(IColumn item)
        {
            ColumnItem columnItem = item.GetColumn();
            
            // Eğer söz konusu alan primary key olarak işaretlenmişse,
            // biz ek olarak bu alanı primary key manipülasyonunu
            // ekliyoruz.
            if (columnItem.isPrimaryKey)
            {
                Definition(new PrimaryKey(columnItem.name));
            }

            return Add((ICreateDefinition)item);
        }

        public ICreateTable Definition(List<IColumn> items)
        {
            foreach (IColumn item in items)
            {
                Definition(item);
            }
            return this;
        }

        public ICreateTable Definition(IAddIndex item)
        {
            return Add((ICreateDefinition)item);
        }

        public ICreateTable Definition(IAddUniqueIndex item)
        {
            return Add((ICreateDefinition)item);
        }

        public ICreateTable Definition(IPrimaryKey item)
        {
            return Add((ICreateDefinition)item);
        }

        public ICreateTable Definition(ICharacterSet item)
        {
            return Add((ICreateDefinition)item);
        }

        public ICreateTable Definition(ICollate item)
        {
            return Add((ICreateDefinition)item);
        }

        public ICreateTable Definition(IEngine item)
        {
            return Add((ICreateDefinition)item);
        }

        public List<ICreateDefinition> GetDefinitions()
        {
            return definitions;
        }

        public void IfNotExists()
        {
            ifNotExistsKey = true;
        }

        public string GetTableName()
        {
            return tableName;
        }

        private ICreateTable Add(ICreateDefinition item)
        {
            definitions.Add(item);
            return this;
        }

        public bool IsIfNotExists()
        {
            return ifNotExistsKey;
        }

        public void Temporary()
        {
            isTemporary = true;
        }

        public bool IsTemporary()
        {
            return isTemporary;
        }

    }

}
