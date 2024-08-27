using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System.Collections.Generic;

namespace EstateMaster.Server.Adaptor.Types
{
    public class AlterTable : IDDLAction, IAlterTable
    {

        private List<IAlterSpecification> specifications { get; set; }

        private string tableName { get; set; }

        public AlterTable(string tableName)
        {
            this.tableName = tableName;
            specifications = new List<IAlterSpecification>();
        }

        public IAlterTable Specification(IAddColumn item)
        {
            return Add((IAlterSpecification)item);
        }

        public IAlterTable Specification(IDropColumn item)
        {
            return Add((IAlterSpecification)item);
        }

        public IAlterTable Specification(IRenameIndex item)
        {
            return Add((IAlterSpecification)item);
        }

        public IAlterTable Specification(IAddConstraint item)
        {
            return Add((IAlterSpecification)item);
        }

        public List<IAlterSpecification> Specifications()
        {
            return specifications;
        }
        public IAlterTable Specification(IAddPrimaryKey item)
        {
            return Add((IAlterSpecification)item);
        }

        public IAlterTable Specification(ICharacterSet item)
        {
            return Add((IAlterSpecification)item);
        }

        public IAlterTable Specification(ICollate item)
        {
            return Add((IAlterSpecification)item);
        }

        public IAlterTable Specification(IEngine item)
        {
            return Add((IAlterSpecification)item);
        }

        public string GetTableName()
        {
            return tableName;
        }

        private AlterTable Add(IAlterSpecification item)
        {
            specifications.Add(item);
            return this;
        }

    }

}
