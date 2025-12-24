using System;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using FluentMigrator;
using FluentMigrator.Builders;
using FluentMigrator.Builders.Alter.Table;
using FluentMigrator.Builders.Create;
using FluentMigrator.Builders.Create.Table;
using FluentMigrator.Expressions;
using FluentMigrator.Infrastructure;
using Nop.Core;
using Nop.Data.Mapping;

namespace Nop.Data.Extensions
{
    public static class FluentMigratorExtensions
    {
        /// <summary>
        /// Specifies the table for the entity
        /// </summary>
        public static ICreateTableWithColumnOrSchemaSyntax TableFor<T>(this ICreateExpressionRoot expressionRoot) where T : BaseEntity
        {
            return expressionRoot.Table(NameCompatibilityManager.GetTableName(typeof(T)));
        }

        /// <summary>
        /// Specifies the table for the entity
        /// </summary>
        public static ICreateTableWithColumnOrSchemaSyntax TableFor<T>(this ICreateExpressionRoot expressionRoot, string tableName) where T : BaseEntity
        {
            return expressionRoot.Table(tableName);
        }

        /// <summary>
        /// Create the table for the entity if it does not exist
        /// </summary>
        public static void CreateTableIfNotExists<T>(this MigrationBase migration) where T : BaseEntity
        {
            var tableName = NameCompatibilityManager.GetTableName(typeof(T));
            if (!migration.Schema.Table(tableName).Exists())
            {
                migration.Create.TableFor<T>();
            }
        }

        /// <summary>
        /// Create a foreign key for the entity (Context: Create Table)
        /// </summary>
        public static ICreateTableColumnOptionOrForeignKeyCascadeOrWithColumnSyntax ForeignKey<TPrimary>(
            this IColumnOptionSyntax<ICreateTableColumnOptionOrWithColumnSyntax, ICreateTableColumnOptionOrForeignKeyCascadeOrWithColumnSyntax> columnOptionSyntax, 
            string primaryColumnName = "Id", 
            Rule onDelete = Rule.Cascade) where TPrimary : BaseEntity
        {
            var primaryTableName = NameCompatibilityManager.GetTableName(typeof(TPrimary));
            return columnOptionSyntax.ForeignKey(primaryTableName, primaryColumnName).OnDelete(onDelete);
        }

        /// <summary>
        /// Create a foreign key for the entity (Context: Alter Table / Add Column)
        /// </summary>
        public static FluentMigrator.Builders.Alter.Table.IAlterTableColumnOptionOrAddColumnOrAlterColumnOrForeignKeyCascadeSyntax ForeignKey<TPrimary>(
            this FluentMigrator.Builders.IColumnOptionSyntax<FluentMigrator.Builders.Alter.Table.IAlterTableColumnOptionOrAddColumnOrAlterColumnSyntax, FluentMigrator.Builders.Alter.Table.IAlterTableColumnOptionOrAddColumnOrAlterColumnOrForeignKeyCascadeSyntax> columnOptionSyntax, 
            string primaryColumnName = "Id", 
            Rule onDelete = Rule.Cascade) where TPrimary : BaseEntity
        {
            var primaryTableName = NameCompatibilityManager.GetTableName(typeof(TPrimary));
            return columnOptionSyntax.ForeignKey(primaryTableName, primaryColumnName).OnDelete(onDelete);
        }

        /// <summary>
        /// Deletes columns if they exist
        /// FIX: Changed MigrationBase to FluentMigrator.Migration to resolve CS1061
        /// </summary>
        public static void DeleteColumnsIfExists<T>(this FluentMigrator.Migration migration, params string[] columnNames) where T : BaseEntity
        {
            var tableName = NameCompatibilityManager.GetTableName(typeof(T));
            foreach (var columnName in columnNames)
            {
                if (migration.Schema.Table(tableName).Column(columnName).Exists())
                {
                    migration.Delete.Column(columnName).FromTable(tableName);
                }
            }
        }

        /// <summary>
        /// Retrieves expressions for building a table
        /// </summary>
        public static void RetrieveTableExpressions(this CreateTableExpressionBuilder expressionBuilder, Type type) 
        {
            var tableName = NameCompatibilityManager.GetTableName(type);
            expressionBuilder.Expression.TableName = tableName;
        }

        /// <summary>
        /// Adds or alters a column for the entity
        /// </summary>
        public static FluentMigrator.Builders.Alter.Table.IAlterTableColumnAsTypeSyntax AddOrAlterColumnFor<T>(
            this MigrationBase migration, Expression<Func<T, object>> expression) where T : BaseEntity
        {
            var tableName = NameCompatibilityManager.GetTableName(typeof(T));
            var propInfo = (expression.Body as MemberExpression ?? (expression.Body as UnaryExpression)?.Operand as MemberExpression)?.Member as PropertyInfo;
            
            if (propInfo == null)
                throw new ArgumentException("Expression must be a property access");

            var columnName = NameCompatibilityManager.GetColumnName(typeof(T), propInfo.Name);

            if (migration.Schema.Table(tableName).Column(columnName).Exists())
            {
                return migration.Alter.Table(tableName).AlterColumn(columnName);
            }
            
            return (FluentMigrator.Builders.Alter.Table.IAlterTableColumnAsTypeSyntax)migration.Alter.Table(tableName).AddColumn(columnName);
        }
    }
}