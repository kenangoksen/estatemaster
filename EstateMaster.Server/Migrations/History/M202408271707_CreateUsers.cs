
using EstateMaster.Server.Adaptor;
using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.PSMigrator.Manager;
using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Types;
using EstateMaster.Server.Adaptor.Types.DDLManipulations;

namespace EstateMaster.server.Core.Migrations.History
{

    public class M202204081449_CreateUsers : MigrationDecorator
    {
        
        public override void Up(Query query, DDL ddl)
        {
            ICreateTable command = new CreateTable("cc_users");
            AddIdAsPrimaryKey(command);
            
            command.Definition(new Column(new ColumnItem() {
                name = "username",
                dataType = DataTypes.VARCHAR,
                maxLength = 100,
                isNullable = false
            })); 
            command.Definition(new Column(new ColumnItem() {
                name = "password",
                dataType = DataTypes.VARCHAR,
                maxLength = 100,
                isNullable = false
            })); 
            command.Definition(new Column(new ColumnItem() {
                name = "token",
                dataType = DataTypes.VARCHAR,
                maxLength = 100,
                isNullable = false
            })); 

            ddl.Execute(command);
        }

    }

}