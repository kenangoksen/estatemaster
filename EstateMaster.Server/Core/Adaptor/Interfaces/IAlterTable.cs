using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System.Collections.Generic;

namespace EstateMaster.Server.Adaptor.Interfaces
{
    /// <summary>
    /// Alter Table işleminin hangi metotları içereceğini göstermektedir.
    /// </summary>
    public interface IAlterTable
    {

        List<IAlterSpecification> Specifications();

        /// <summary>
        /// Var olan tablo üzerinde yeni bir sütun ekleme.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IAlterTable Specification(IAddColumn item);

        /// <summary>
        /// Var olan birtblo alanını silme işlemi.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IAlterTable Specification(IDropColumn item);

        /// <summary>
        /// Bir index'in adını değiştirme.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IAlterTable Specification(IRenameIndex item);

        /// <summary>
        /// Yeni bir foreign key ekleme.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IAlterTable Specification(IAddConstraint item);

        /// <summary>
        /// Bir alanı primary key olarak işaretle.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IAlterTable Specification(IAddPrimaryKey item);

        /// <summary>
        /// Karakter setini güncelleme
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IAlterTable Specification(ICharacterSet item);

        /// <summary>
        /// Collate değerini güncelleme
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IAlterTable Specification(ICollate item);

        /// <summary>
        /// Engine değerini güncelleme
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IAlterTable Specification(IEngine item);

        string GetTableName();
    }
}