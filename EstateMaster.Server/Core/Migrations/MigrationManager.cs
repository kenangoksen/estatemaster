using EstateMaster.Server.Adaptor;
using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.PSMigrator.Interfaces;
using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Types;
using EstateMaster.Server.Adaptor.Types.DDLManipulations;
using EstateMaster.Server.Core.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstateMaster.Server.Core.Migrations
{

    public class MigrationManager
    {

        private Query query { get; set; }

        private DDL ddl { get; set; }

        private List<Dictionary<string, dynamic>> executedMigrations { get; set; }

        public MigrationManager(Query query, DDL ddl)
        {
            this.query = query;
            this.ddl = ddl;
            executedMigrations = new List<Dictionary<string, dynamic>>();
        }

        public void Execute()
        {
            LoadExecutedMigrations();
            foreach (Type migrationType in MigrationList.Get())
            {
                IMigration migration = (IMigration)Activator.CreateInstance(migrationType);
                RunOverDatabase(migration);
            }
        }

        private void LoadExecutedMigrations()
        {
            try
            {
                executedMigrations = query.Table("_psmigrations").ToList();
            }
            catch (Exception)
            {
                CreateMigrationTable();
            }
        }

        private void CreateMigrationTable()
        {
            ICreateTable command = new CreateTable("_psmigrations");
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

            command.Definition(new Column(new ColumnItem()
            {
                name = "name",
                dataType = DataTypes.VARCHAR,
                maxLength = 255,
                isNullable = false
            }));

            command.Definition(new Column(new ColumnItem()
            {
                name = "executed_at",
                dataType = DataTypes.DATETIME,
                isNullable = false
            }));

            ddl.Execute(command);
        }

        private void RunOverDatabase(IMigration migration)
        {
            if (IsExecuted(migration))
            {
                return;
            }

            migration.Up(query, ddl);
            if (migration.GetType().Name != "DropAndCreateStoreProcedures")
            {
                SetAsExecuted(migration);
            }
        }

        private void SetAsExecuted(IMigration migration)
        {
            query.Table("_psmigrations")
                .Insert(new Dictionary<string, dynamic>() {
                    { "name", migration.GetType().Name },
                    { "executed_at", DateTime.Now }
                });
        }

        private bool IsExecuted(IMigration migration)
        {
            string name = migration.GetType().Name;
            return executedMigrations
                .Where(i => i["name"] == name)
                .Count() > 0;
        }

    }

}