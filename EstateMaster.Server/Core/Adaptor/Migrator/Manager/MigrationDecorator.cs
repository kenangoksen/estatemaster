using EstateMaster.Server.Adaptor.PSMigrator.Interfaces; 
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Types.DDLManipulations;
using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Helpers.Types;

namespace EstateMaster.Server.Adaptor.PSMigrator.Manager
{

    public abstract class MigrationDecorator : IMigration
    {

        public abstract void Up(Query query, DDL ddl);

        protected void AddIdAsPrimaryKey(ICreateTable command)
        {
            command.Definition(
                new Column(
                    new ColumnItem()
                    {
                        name = "id",
                        dataType = DataTypes.INT,
                        isNullable = false,
                        isPrimaryKey = true,
                        isAutoIncrement = true,
                        maxLength = 100,
                        defaultValue = "FALSE"
                    }
                )
            );
        }

        protected void AddBaseModelFields(ICreateTable command)
        {
            command.Definition(
                new Column(
                    new ColumnItem()
                    {
                        name = "id",
                        dataType = DataTypes.INT,
                        isNullable = false,
                        isPrimaryKey = true,
                        isAutoIncrement = true,
                        maxLength = 100,
                        defaultValue = "FALSE"
                    }
                )
            );

            command.Definition(new Column(new ColumnItem() {
                name = "created_at",
                dataType = DataTypes.DATETIME,
                isNullable = false
            }));

            command.Definition(new Column(new ColumnItem() {
                name = "updated_at",
                dataType = DataTypes.DATETIME,
                isNullable = true 
            }));

            command.Definition(new Column(new ColumnItem() {
                name = "create_employee_code",
                dataType = DataTypes.VARCHAR,
                maxLength = 100,
                isNullable = false 
            }));

            command.Definition(new Column(new ColumnItem() {
                name = "update_employee_code",
                dataType = DataTypes.VARCHAR,
                maxLength = 100,
                isNullable = true
            }));
        }

    }

}
