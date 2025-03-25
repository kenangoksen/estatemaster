using EstateMaster.Server.Adaptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;

namespace EstateMaster.Server.Adaptor.Types
{
    public class CreateDatabase : IDDLAction, ICreateDatabase, IIfNotExists
    {

        private string name { get; set; }
        private List<ICreateDatabaseSpecification> specifications { get; set; }
        private bool ifNotExistsStatus { get; set; }

        public CreateDatabase(string name)
        {
            this.name = name;
            specifications = new List<ICreateDatabaseSpecification>();
            ifNotExistsStatus = false;
        }

        public string GetDatabaseName()
        {
            return name;
        }

        public ICreateDatabase Specification(IDefaultCollate item)
        {
            specifications.Add((ICreateDatabaseSpecification)item);
            return this;
        }

        public ICreateDatabase Specification(IDefaultCharacterSet item)
        {
            specifications.Add((ICreateDatabaseSpecification)item);
            return this;
        }

        public List<ICreateDatabaseSpecification> Specifications()
        {
            return specifications;
        }

        public void IfNotExists()
        {
            ifNotExistsStatus = true;
        }

        public bool IsIfNotExists()
        {
            return ifNotExistsStatus;
        }

        public string GetDefaultCollate()
        {
            foreach (ICreateDatabaseSpecification spec in specifications)
            {
                if (spec is IDefaultCollate)
                {
                    return ((IDefaultCollate)spec).GetValue();
                }
            }
            throw new Exception("Collation information is required!");
        }

    }
}
