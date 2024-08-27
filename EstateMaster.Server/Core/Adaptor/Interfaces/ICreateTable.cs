using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using EstateMaster.Server.Adaptor.Interfaces.CreateTableParts;
using EstateMaster.Server.Adaptor.Shared;
using EstateMaster.Server.Adaptor.Types;
using System.Collections.Generic;

namespace EstateMaster.Server.Adaptor.Interfaces
{
    /// <summary>
    /// CreateTable işleminin hangi metotları içereceğini göstermektedir.
    /// </summary>
    public interface ICreateTable
    {

        /// <summary>
        /// Yeni bir alan ekleme.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ICreateTable Definition(IColumn item);

        /// <summary>
        /// Yeni bir alan ekleme.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ICreateTable Definition(List<IColumn> items);

        /// <summary>
        /// Yeni bir index ekleme.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ICreateTable Definition(IAddIndex item);

        /// <summary>
        /// Unique index tanımlama.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ICreateTable Definition(IAddUniqueIndex item);

        /// <summary>
        /// Primary key tanımlama.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ICreateTable Definition(IPrimaryKey item);

        /// <summary>
        /// Karakter setini güncelleme
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ICreateTable Definition(ICharacterSet item);

        /// <summary>
        /// Collate değerini güncelleme
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ICreateTable Definition(ICollate item);

        /// <summary>
        /// Engine değerini güncelleme
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ICreateTable Definition(IEngine item);

        List<ICreateDefinition> GetDefinitions();

        string GetTableName();

    }
}